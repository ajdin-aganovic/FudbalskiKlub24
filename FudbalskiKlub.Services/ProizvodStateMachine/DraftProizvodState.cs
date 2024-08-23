using AutoMapper;
using EasyNetQ;
using FudbalskiKlub.Model;
using FudbalskiKlub.Model.Messages;
using FudbalskiKlub.Model.Requests;
using FudbalskiKlub.Subscriber;
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

namespace FudbalskiKlub.Services.ProizvodStateMachine
{
    public class DraftProizvodState : BaseProizvodState
    {
        protected ILogger<DraftProizvodState> _logger;
        private readonly ConnectionFactory _factory;
        private readonly string _queueName = "myQueue";
        public DraftProizvodState(ConnectionFactory factory, ILogger<DraftProizvodState> logger, IServiceProvider serviceProvider, Database1.MiniafkContext context, IMapper mapper) : base(serviceProvider, context, mapper)
        {
            _logger = logger;
            _factory = factory;
        }

        public override async Task<Model.Proizvod> Update(int id, ProizvodUpdateRequest request)
        {
            var set = _context.Set<Database1.Proizvod>();

            var entity = await set.FindAsync(id);

            _mapper.Map(request, entity);

            if (entity.Kolicina < 0)
            {
                throw new Exception("Kolicina ne moze biti u minusu");
            }


            if (entity.Cijena < 0)
            {
                throw new UserException("Cijena ne smije biti u minisu");
            }

            if (entity.Cijena < 1)
            {
                throw new UserException("Cijena ispod minimuma");
            }




            await _context.SaveChangesAsync();
            return _mapper.Map<Model.Proizvod>(entity);
        }

        public override async Task<Model.Proizvod> Activate(int id)
        {
            _logger.LogInformation($"Aktivacija proizvoda: {id}");

            var set = _context.Set<Database1.Proizvod>();

            var entity = await set.FindAsync(id);

            entity.StateMachine = "active";

            await _context.SaveChangesAsync();
            var mappedEntity = _mapper.Map<Model.Proizvod>(entity);


            EmailJS emailObavijest = new EmailJS();
            var sviKorisnici = _context.Set<Database1.Korisnik>();
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
                foreach(var x in sviKorisnici)
                {
                    if(!x.Email.IsNullOrEmpty())
                    { 
                        emailObavijest.SendEmail(x.Email, "Obavijest Fudbalskog kluba", $"Proizvod je dostupan na web trgovini {mappedEntity.Naziv} {mappedEntity.Sifra}. Cijena proizvoda je {mappedEntity.Cijena} KM.");
                        Console.WriteLine($"Poslana poruka u RabbitMQ za: {x.Ime}", jsonData);
                    }
                }

            }
            //}

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
