using AutoMapper;
//using EasyNetQ.Logging;
using FudbalskiKlub.Model.Requests;
using FudbalskiKlub.Model.SearchObjects;
using FudbalskiKlub.Services.Database1;
using Microsoft.EntityFrameworkCore;
using FudbalskiKlub.Subscriber;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;


namespace FudbalskiKlub.Services
{
    public class ClanarinaService :
        BaseCRUDService<Model.Clanarina, Database1.Clanarina, ClanarinaSearchObject, ClanarinaInsertRequest, ClanarinaUpdateRequest>, IClanarinaService

    {
        protected ILogger<ClanarinaService> _logger;
        private readonly ConnectionFactory _factory;
        private readonly string _queueName = "myQueue";

        public ClanarinaService(ILogger<ClanarinaService> logger, ConnectionFactory factory, MiniafkContext context, IMapper mapper) : base(context, mapper)
        {
            _logger = logger;
            _factory = factory;
        }



        public override IQueryable<Database1.Clanarina> AddFilter(IQueryable<Database1.Clanarina> query, ClanarinaSearchObject? search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (!string.IsNullOrWhiteSpace(search?.MinIznosClanarine.ToString()))
            {
                filteredQuery = filteredQuery.Where(x => x.IznosClanarine>search.MinIznosClanarine);
            }
            if (!string.IsNullOrWhiteSpace(search?.MaxIznosClanarine.ToString()))
            {
                filteredQuery = filteredQuery.Where(x => x.IznosClanarine < search.MaxIznosClanarine);
            }
            if (search.Placena.HasValue)
            {
                filteredQuery = filteredQuery.Where(x => x.Placena == search.Placena);
            }

            return filteredQuery;
        }

        public override async Task AfterInsert(Database1.Clanarina entity, ClanarinaInsertRequest insert)
        {
            EmailJS emailObavijest = new EmailJS();
            var sviKorisnici = _context.Set<Database1.Korisnik>();
            var formatDatuma = "dd-MM-yyyy";
            var specificniKorisnikEmail = await sviKorisnici.Where(x => x.KorisnikId == entity.KorisnikId).FirstAsync();

            string data = "Poslan email";

            using (var connection = _factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

                var jsonData = JsonConvert.SerializeObject(data);
                var body = Encoding.UTF8.GetBytes(jsonData);

                channel.BasicPublish(exchange: "", routingKey: _queueName, basicProperties: null, body: body);


                if (entity.Dug > 0)
                {
                    await emailObavijest.SendEmail(specificniKorisnikEmail.Email,
                        "Obavijest Fudbalskog kluba",
                        $"Članarina: \nPoštovani {specificniKorisnikEmail.KorisnickoIme}, šaljemo Vam ovu obavijest povodom plaćanja članarine." +
                        $"\nDatum evidencije: {entity.DatumPlacanja?.ToString(formatDatuma)}." +
                        $"\nIznos članarine: {entity.IznosClanarine}KM" +
                        $"\nPrethodno dugovanje: {entity.Dug}KM" +
                        $"$\nUkupno: {entity.Dug + entity.IznosClanarine}KM.");
                }
                else
                    await emailObavijest.SendEmail(specificniKorisnikEmail.Email,
                        "Obavijest Fudbalskog kluba",
                        $"Članarina: \nPoštovani {specificniKorisnikEmail.KorisnickoIme}, šaljemo Vam ovu obavijest povodom plaćanja članarine." +
                        $"\nDatum evidencije: {entity.DatumPlacanja?.ToString(formatDatuma)}." +
                        $"\nIznos članarine: {entity.IznosClanarine}KM.");
                Console.WriteLine($"Poslana poruka u RabbitMQ: {specificniKorisnikEmail.KorisnickoIme}", jsonData);
            }
        }

        public override async Task AfterUpdate(Database1.Clanarina entity, ClanarinaUpdateRequest update)
        {
            EmailJS emailObavijest = new EmailJS();
            var sviKorisnici = _context.Set<Database1.Korisnik>();
            string formatDatuma = "dd-MM-yyyy";
            var specificniKorisnikEmail = await sviKorisnici.Where(x => x.KorisnikId == entity.KorisnikId).FirstAsync();

            string data = "Poslan email";
            using (var connection = _factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

                var jsonData = JsonConvert.SerializeObject(data);
                var body = Encoding.UTF8.GetBytes(jsonData);

                channel.BasicPublish(exchange: "", routingKey: _queueName, basicProperties: null, body: body);

                if(entity.Dug>0)
                {
                    await emailObavijest.SendEmail(specificniKorisnikEmail.Email, 
                        "Obavijest Fudbalskog kluba", 
                        $"Članarina: \nPoštovani {specificniKorisnikEmail.KorisnickoIme}, šaljemo Vam ovu obavijest povodom plaćanja članarine." +
                        $"\nDatum evidencije: {entity.DatumPlacanja?.ToString(formatDatuma)}." +
                        $"\nIznos članarine: {entity.IznosClanarine}KM"+
                        $"\nPrethodno dugovanje: {entity.Dug}KM"+
                        $"$\nUkupno: {entity.Dug+entity.IznosClanarine}KM.");
                }
                else
                    await emailObavijest.SendEmail(specificniKorisnikEmail.Email,
                        "Obavijest Fudbalskog kluba",
                        $"Članarina: \nPoštovani {specificniKorisnikEmail.KorisnickoIme}, šaljemo Vam ovu obavijest povodom plaćanja članarine." +
                        $"\nDatum evidencije: {entity.DatumPlacanja?.ToString(formatDatuma)}." +
                        $"\nIznos članarine: {entity.IznosClanarine}KM.");
                Console.WriteLine($"Poslana poruka u RabbitMQ: {specificniKorisnikEmail.KorisnickoIme}", jsonData);

            }
        }
    }
}
