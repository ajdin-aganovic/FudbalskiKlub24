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

namespace FudbalskiKlub.Services.ToDo4924StateMachine
{
    public class RealizujToDo4924State : BaseToDo4924State
    {
        protected ILogger<RealizujToDo4924State> _logger;
        private readonly ConnectionFactory _factory;
        private readonly string _queueName = "myQueue";

        public RealizujToDo4924State(ConnectionFactory factory, ILogger<RealizujToDo4924State> logger, IServiceProvider serviceProvider, Database1.MiniafkContext context, IMapper mapper) : base(serviceProvider, context, mapper)
        {
            _logger = logger;
            _factory = factory;
        }


        //public override async Task<Model.ToDo4924> Realizuj(int id)
        //{

        //    var set = _context.Set<Database1.ToDo4924>();

        //    var entity = await set.FindAsync(id);

        //    entity.stateMachine = "Realizovana";

        //    await _context.SaveChangesAsync();
        //    var mappedEntity = _mapper.Map<Model.ToDo4924>(entity);



        //    return mappedEntity;
        //}

        //public override async Task<Model.ToDo4924> Update(int id, ToDo4924UpdateRequest request)
        //{
        //    var set = _context.Set<Database1.ToDo4924>();

        //    var entity = await set.FindAsync(id);

        //    entity.stateMachine = "U toku";

        //    _mapper.Map(request, entity);

        //    await _context.SaveChangesAsync();
        //    return _mapper.Map<Model.ToDo4924>(entity);
        //}


        public override async Task<List<string>> AllowedActions()
        {
            var list = await base.AllowedActions();

            return list;
        }
    }
}
