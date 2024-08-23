using AutoMapper;
using EasyNetQ;
using FudbalskiKlub.Model;
using FudbalskiKlub.Model.Messages;
using FudbalskiKlub.Model.Requests;
using FudbalskiKlub.Subscriber;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FudbalskiKlub.Services.ProizvodiStateMachine
{
    public class DraftPlatumState : BaseState
    {
        protected ILogger<DraftPlatumState> _logger;
        private readonly ConnectionFactory _factory;
        private readonly string _queueName = "myQueue";

        public DraftPlatumState(ConnectionFactory factory, ILogger<DraftPlatumState> logger, IServiceProvider serviceProvider, Database1.MiniafkContext context, IMapper mapper) : base(serviceProvider, context, mapper)
        {
            _logger = logger;
            _factory = factory;
        }

        public override async Task<Model.Platum> Update(int id, PlatumUpdateRequest request)
        {
            var set = _context.Set<Database1.Platum>();

            var entity = await set.FindAsync(id);

            _mapper.Map(request, entity);

            if (entity.Iznos < 0)
            {
                throw new Exception("Cijena ne moze biti u minusu");
            }


            if (entity.Iznos < 1)
            {
                throw new UserException("Cijena ispod minimuma");
            }


            

            await _context.SaveChangesAsync();
            return _mapper.Map<Model.Platum>(entity);
        }

        public override async Task<Model.Platum> Activate(int id)
        {
            //var putanja = Environment.GetEnvironmentVariable("RABBITMQ_FULL_CRED"); //Kad proradi .env
            //var putanja = "host=localhost;username=guest;password=guest";

            _logger.LogInformation($"Deaktivacija plate: {id}");


            var set = _context.Set<Database1.Platum>();

            var entity = await set.FindAsync(id);

            entity.StateMachine = "active";

            await _context.SaveChangesAsync();
            

            var mappedEntity = _mapper.Map<Model.Platum>(entity);

            var platum = await _context.Plata
                    .Include(p => p.TransakcijskiRacun)
                        .ThenInclude(tr => tr.Korisnik)
                    .FirstOrDefaultAsync(p => p.PlataId == entity.PlataId);

            if (platum == null || platum.TransakcijskiRacun == null || platum.TransakcijskiRacun.Korisnik == null)
            {
                Console.WriteLine("Unable to find the specified platum, transakcijski racun, or korisnik.");
            }

            var email = platum.TransakcijskiRacun.Korisnik.Email;

            if (string.IsNullOrEmpty(email))
            {
                Console.WriteLine("The korisnik does not have a valid email address.");
            }

            EmailJS emailObavijest = new EmailJS();
        


        string data = "Poslan email";

            using (var connection = _factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

                var jsonData = JsonConvert.SerializeObject(data);
                var body = Encoding.UTF8.GetBytes(jsonData);

                channel.BasicPublish(exchange: "", routingKey: _queueName, basicProperties: null, body: body);
                emailObavijest.SendEmail(email, "Plata - Fudbalski Klub", $"Plata za mjesec {DateTime.UtcNow.Month.ToString()} je aktivirana. Vrijeme obračuna: {platum.DatumSlanja}. Saldo: {platum.Iznos} KM. Vrijeme slanja: {DateTime.Now.ToString("dd/MM/yyyy")}");

                Console.WriteLine($"Poslana poruka u RabbitMQ za: {email}", jsonData);
            }
            

            return mappedEntity;
        }

        public override async Task<List<string>> AllowedActions()
        {
            var list = await base.AllowedActions();

            list.Add("Update");
            list.Add("Activate");

            return list;
        }
    }
}


//Kod ispod je išao iznad deklaracije mappedEntity-a

//var factory = new ConnectionFactory { HostName = "localhost" };
//using var connection = factory.CreateConnection();
//using var channel = connection.CreateModel();


//string message = "";

////JSON$"{entity.ProizvodId}, {entity.Sifra}, {entity.Naziv}";
//var body = Encoding.UTF8.GetBytes(message);

//channel.BasicPublish(exchange: string.Empty,
//                     routingKey: "product_added",
//                     basicProperties: null,
//                     body: body);
