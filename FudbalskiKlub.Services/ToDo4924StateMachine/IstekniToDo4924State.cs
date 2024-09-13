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

namespace FudbalskiKlub.Services.ToDo4924StateMachine
{
    public class IstekniToDo4924State : BaseToDo4924State
    {
        protected ILogger<IstekniToDo4924State> _logger;
        private readonly ConnectionFactory _factory;
        private readonly string _queueName = "myQueue";
        public IstekniToDo4924State(ConnectionFactory factory, ILogger<IstekniToDo4924State> logger, IServiceProvider serviceProvider, Database1.MiniafkContext context, IMapper mapper) : base(serviceProvider, context, mapper)
        {
            _logger = logger;
            _factory = factory;
        }

        

        //public override async Task<Model.ToDo4924> Istekni(int id)
        //{

        //    var set = _context.Set<Database1.ToDo4924>();

        //    var entity = await set.FindAsync(id);

        //    entity.stateMachine = "Istekla";

        //    await _context.SaveChangesAsync();
        //    var mappedEntity = _mapper.Map<Model.ToDo4924>(entity);


            
        //    return mappedEntity;
        //}

        public override async Task<List<string>> AllowedActions()
        {
            var list = await base.AllowedActions();


            return list;
        }
    }
}
