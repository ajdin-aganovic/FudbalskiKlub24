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
    public class RealiziranaToDo4924State : BaseToDo4924State
    {

        public RealiziranaToDo4924State(IServiceProvider serviceProvider, Database1.MiniafkContext context, IMapper mapper) : base(serviceProvider, context, mapper)
        {
        }


        public override async Task<List<string>> AllowedActions()
        {
            var list = await base.AllowedActions();
            

            return list;
        }
    }
}
