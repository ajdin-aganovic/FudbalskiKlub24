using AutoMapper;
using EasyNetQ;
using FudbalskiKlub.Model;
using FudbalskiKlub.Model.Messages;
using FudbalskiKlub.Model.Requests;
using FudbalskiKlub.Services.Database1;
using FudbalskiKlub.Subscriber;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Services.ProizvodiStateMachine
{
    public class ActivePlatumState : BaseState
    {
        ILogger<ActivePlatumState> _logger;
        private readonly ConnectionFactory _factory;
        private readonly string _queueName = "myQueue";
        public ActivePlatumState(ConnectionFactory factory, ILogger<ActivePlatumState>logger, IServiceProvider serviceProvider, Database1.MiniafkContext context, IMapper mapper) : base(serviceProvider, context, mapper)
        {
            _logger = logger;
            _factory = factory;
        }

        public override async Task<Model.Platum> Hide(int id)
        {
            //var putanja = Environment.GetEnvironmentVariable("RABBITMQ_FULL_CRED"); //Kad proradi .env
            //var putanja = "host=localhost;port=15672;username=guest;password=guest"; 
            //var putanja = "host=localhost;username=guest;password=guest";


            _logger.LogInformation($"Deaktivacija plate: {id}");

            var set = _context.Set<Database1.Platum>();

            var entity = await set.FindAsync(id);

            entity.StateMachine = "draft";

            await _context.SaveChangesAsync();

            var mappedEntity = _mapper.Map<Model.Platum>(entity);

            //try
            //{

            //    var bus = RabbitHutch.CreateBus(putanja??"error");
            //    var set1 = _context.Set<Database1.TransakcijskiRacun>();
            //    var pronadjeniTransakcijskiRacun = set1.FindAsync(entity.TransakcijskiRacunId);
            //    var set2 = _context.Set<Database1.Korisnik>();
            //    var pronadjeniKorisnickiRacun = set2.FindAsync(pronadjeniTransakcijskiRacun.Result.KorisnikId);
            //    var mappedEntity1 = new Model.Korisnik();

            //    PlatumActivated poruka = new PlatumActivated();

            //    if (pronadjeniKorisnickiRacun != null)
            //    {
            //        mappedEntity1 = _mapper.Map<Model.Korisnik>(pronadjeniKorisnickiRacun);
            //        poruka.KorisnikPlatumPoruka = mappedEntity1;
            //    }

            //    else
            //        _logger.LogError("Nije pronađen korisnik");

            //    poruka.PlatumPoruka = mappedEntity;
            //    bus.PubSub.Publish(poruka);

            //}
            //catch
            //{
            //    _logger.LogError("Nije mogla da se posalje poruka jer RabbitMQ mikroservis ne radi!");
            //}

            //EmailJS emailObavijest = new EmailJS();
            //emailObavijest.SendEmail("aydox09@gmail.com", "Plata - Fudbalski Klub", $"Plata za mjesec {DateTime.UtcNow.Month.ToString()} je aktivirana. Vrijeme aktivacije: {mappedEntity.DatumSlanja}. Saldo: {mappedEntity.Iznos}");

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
            //}



            return _mapper.Map<Model.Platum>(entity);
        }

        public override async Task<List<string>> AllowedActions()
        {
            var list = await base.AllowedActions();
            list.Add("Hide");

            return list;
        }
    }
}
