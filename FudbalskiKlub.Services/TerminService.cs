using AutoMapper;
using FudbalskiKlub.Model.Requests;
using FudbalskiKlub.Model.SearchObjects;
using FudbalskiKlub.Services.Database1;
using FudbalskiKlub.Services.ProizvodStateMachine;
using FudbalskiKlub.Subscriber;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using RabbitMQ.Client;
using EasyNetQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace FudbalskiKlub.Services
{
    public class TerminService :
        BaseCRUDService<Model.Termin, Database1.Termin, TerminSearchObject, TerminInsertRequest, TerminUpdateRequest>, ITerminService

    {
        protected ILogger<TerminService> _logger;
        private readonly ConnectionFactory _factory;
        private readonly string _queueName = "myQueue";

        public TerminService(ILogger<TerminService> logger, ConnectionFactory factory, MiniafkContext context, IMapper mapper) : base(context, mapper)
        {
            _logger = logger;
            _factory = factory;
        }

        public override IQueryable<Database1.Termin> AddFilter(IQueryable<Database1.Termin> query, TerminSearchObject? search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (!string.IsNullOrWhiteSpace(search?.TipTermina))
            {
                filteredQuery = filteredQuery.Where(x => x.TipTermina.Contains(search.TipTermina));
            }
            if (!string.IsNullOrWhiteSpace(search?.SifraTermina))
            {
                filteredQuery = filteredQuery.Where(x => x.SifraTermina.Contains(search.SifraTermina));
            }


            return filteredQuery;
        }

        public override IQueryable<Database1.Termin> AddInclude(IQueryable<Database1.Termin> query, TerminSearchObject? search = null)
        {
            if (search?.IsStadionIncluded == true)
            {
                query = query.Include("Stadion");
            }

            return base.AddInclude(query, search);
        }

        public override async Task AfterInsert(Database1.Termin entity, TerminInsertRequest insert)
        {
            EmailJS emailObavijest = new EmailJS();
            var sviKorisnici = _context.Set<Database1.Korisnik>();
            var formatDatuma = "dd-MM-yyyy";
            var stadioni = await _context.Stadions
                .Include(p => p.TreningStadions)
                .ThenInclude(p=>p.Trening)
                .FirstOrDefaultAsync(p => p.StadionId == entity.StadionId);
            var nazivStadiona = stadioni.NazivStadiona;
            foreach (var x in sviKorisnici)
            {
                if (!x.Email.IsNullOrEmpty()&& (x.Uloga == "Igrac" || x.Uloga.Contains("trener")))
                {
                    await emailObavijest.SendEmail(x.Email, "Obavijest Fudbalskog kluba", $"Novi termin je zakazan!\n\nTermin: {entity.TipTermina} / {entity.SifraTermina}.\nZakazan je za dan: {entity.Datum?.ToString(formatDatuma)}.\nLokacija: {nazivStadiona}");

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

        public override async Task AfterUpdate(Database1.Termin entity, TerminUpdateRequest update)
        {
            EmailJS emailObavijest = new EmailJS();
            var sviKorisnici = _context.Set<Database1.Korisnik>();
            string formatDatuma = "dd-MM-yyyy";
            var stadioni = await _context.Stadions
                .Include(p => p.TreningStadions)
                .ThenInclude(p => p.Trening)
                .FirstOrDefaultAsync(p => p.StadionId == entity.StadionId);
            var nazivStadiona = stadioni.NazivStadiona;
            foreach (var x in sviKorisnici)
            {
                if (!x.Email.IsNullOrEmpty() && (x.Uloga == "Igrac" || x.Uloga.Contains("trener")))
                {
                    await emailObavijest.SendEmail(x.Email, "Obavijest Fudbalskog kluba", $"Termin: {entity.TipTermina} / {entity.SifraTermina} je izmijenjen.\nZakazan je za dan: {entity.Datum?.ToString(formatDatuma)}.\nLokacija: {nazivStadiona}");
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
