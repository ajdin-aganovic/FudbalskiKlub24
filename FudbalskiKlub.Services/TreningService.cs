using AutoMapper;
using FudbalskiKlub.Model.Requests;
using FudbalskiKlub.Model.SearchObjects;
using FudbalskiKlub.Services.Database1;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System;
using EasyNetQ;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FudbalskiKlub.Subscriber;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace FudbalskiKlub.Services
{
    public class TreningService :
        BaseCRUDService<Model.Trening, Database1.Trening, TreningSearchObject, TreningInsertRequest, TreningUpdateRequest>, ITreningService

    {
        protected ILogger<TreningService> _logger;
        private readonly ConnectionFactory _factory;
        private readonly string _queueName = "myQueue";

        public TreningService(ILogger<TreningService> logger, ConnectionFactory factory, MiniafkContext context, IMapper mapper) : base(context, mapper)
        {
            _logger = logger;
            _factory = factory;
        }

        public override IQueryable<Database1.Trening> AddFilter(IQueryable<Database1.Trening> query, TreningSearchObject? search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (!string.IsNullOrWhiteSpace(search?.NazivTreninga))
            {
                filteredQuery = filteredQuery.Where(x => x.NazivTreninga.Contains(search.NazivTreninga));
            }
            if (!string.IsNullOrWhiteSpace(search?.TipTreninga))
            {
                filteredQuery = filteredQuery.Where(x => x.TipTreninga.Contains(search.TipTreninga));
            }
            return filteredQuery;
        }

        public override IQueryable<Database1.Trening> AddInclude(IQueryable<Database1.Trening> query, TreningSearchObject? search = null)
        {
            if (search?.IsStadionIncluded == true)
            {
                query = query.Include("TreningStadions");
            }
            return base.AddInclude(query, search);
        }

        public override async Task AfterInsert(Database1.Trening entity, TreningInsertRequest insert)
        {
            EmailJS emailObavijest = new EmailJS();
            var sviKorisnici = _context.Set<Database1.Korisnik>();
            foreach (var x in sviKorisnici)
            {
                if (!x.Email.IsNullOrEmpty() && (x.Uloga == "Igrac" || x.Uloga.Contains("trener")))
                {
                    await emailObavijest.SendEmail(x.Email, "Obavijest Fudbalskog kluba", $"Novi trening je zakazan!\n\nPodaci o treningu: {entity.NazivTreninga} / {entity.TipTreninga}.\nZakazan je za dan: {entity.DatumTreninga}.");
                }
            }

            string data = "Poslan email";

            //void SendMessageToQueue(data)
            //{
            using (var connection = _factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

                var jsonData = JsonConvert.SerializeObject(data);
                var body = Encoding.UTF8.GetBytes(jsonData);

                channel.BasicPublish(exchange: "", routingKey: _queueName, basicProperties: null, body: body);

                Console.WriteLine("Poslana poruka u RabbitMQ: {0}", jsonData);
            }
        }

        public override async Task AfterUpdate(Database1.Trening entity, TreningUpdateRequest update)
        {
            EmailJS emailObavijest = new EmailJS();
            var sviKorisnici = _context.Set<Database1.Korisnik>();
            foreach (var x in sviKorisnici)
            {
                if (!x.Email.IsNullOrEmpty() && (x.Uloga == "Igrac" || x.Uloga.Contains("trener")))
                {
                    await emailObavijest.SendEmail(x.Email, "Obavijest Fudbalskog kluba", $"Trening: {entity.NazivTreninga} / {entity.TipTreninga} je izmijenjen.\nZakazan je za dan: {entity.DatumTreninga}.");
                }
            }

            string data = "Poslan email";

            //void SendMessageToQueue(data)
            //{
            using (var connection = _factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

                var jsonData = JsonConvert.SerializeObject(data);
                var body = Encoding.UTF8.GetBytes(jsonData);

                channel.BasicPublish(exchange: "", routingKey: _queueName, basicProperties: null, body: body);

                Console.WriteLine("Poslana poruka u RabbitMQ: {0}", jsonData);
            }
        }
    }
}
