using AutoMapper;
using EasyNetQ;
using FudbalskiKlub.Model;
using FudbalskiKlub.Model.Messages;
using Microsoft.Extensions.Logging;
using FudbalskiKlub.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using Newtonsoft.Json;
using FudbalskiKlub.Subscriber;
using Microsoft.IdentityModel.Tokens;

namespace FudbalskiKlub.Services.ProizvodStateMachine
{
    public class ActiveProizvodState : BaseProizvodState
    {
        protected ILogger<ActiveProizvodState> _logger;
        private readonly ConnectionFactory _factory;
        private readonly string _queueName = "myQueue";

        public ActiveProizvodState(ConnectionFactory factory, ILogger<ActiveProizvodState> logger, IServiceProvider serviceProvider, Database1.MiniafkContext context, IMapper mapper) : base(serviceProvider, context, mapper)
        {
            _logger = logger;
            _factory = factory;
        }

        public override async Task<Model.Proizvod> Hide(int id)
        {
            

            _logger.LogInformation($"Deaktivacija proizvoda: {id}");

            var set = _context.Set<Database1.Proizvod>();

            var entity = await set.FindAsync(id);

            entity.StateMachine = "draft";

            await _context.SaveChangesAsync();


            var mappedEntity = _mapper.Map<Model.Proizvod>(entity);

            EmailJS emailObavijest = new EmailJS();
            //emailObavijest.SendEmail("aydox09@gmail.com", "Obavijest Fudbalskog kluba", $"Proizvod više nije dostupan na web trgovini {mappedEntity.Naziv} {mappedEntity.Sifra}.");
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

                foreach (var x in sviKorisnici)
                {
                    if (!x.Email.IsNullOrEmpty())
                    {
                        emailObavijest.SendEmail(x.Email, "Obavijest Fudbalskog kluba", $"Proizvod više nije dostupan na web trgovini {mappedEntity.Naziv} {mappedEntity.Sifra}.");
                        Console.WriteLine($"Poslana poruka u RabbitMQ za: {x.Ime}", jsonData);
                    }
                }

            }
            //}



            return _mapper.Map<Model.Proizvod>(entity);
        }

        public override async Task<List<string>> AllowedActions()
        {
            var list = await base.AllowedActions();
            list.Add("Hide");

            return list;
        }
    }
}
