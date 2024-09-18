using AutoMapper;
using FudbalskiKlub.Model;
using FudbalskiKlub.Model.Requests;
using FudbalskiKlub.Services.Database1;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Services.ToDo4924StateMachine
{
    public class BaseToDo4924State
    {
        protected MiniafkContext _context;
        protected IMapper _mapper { get; set; }
        public IServiceProvider _serviceProvider { get; set; }
        public BaseToDo4924State(IServiceProvider serviceProvider, MiniafkContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _serviceProvider = serviceProvider;
        }

        public virtual Task<Model.ToDo4924> Insert(ToDo4924Request request)
        {
            throw new UserException("Not allowed");
        }

        public virtual Task<Model.ToDo4924> Update(int id, ToDo4924Request request)
        {
            throw new UserException("Not allowed");
        }

        public virtual Task<Model.ToDo4924> Realizuj(int id)
        {
            throw new UserException("Not allowed");
        }

        public virtual Task<Model.ToDo4924> Istekni(int id)
        {
            throw new UserException("Not allowed");
        }


        public BaseToDo4924State CreateState(string stateName)
        {
            switch (stateName)
            {
                case "U toku":
                case null:
                    return _serviceProvider.GetService<UTokuToDo4924State>();
                    break;
                case "Realizirana":
                    return _serviceProvider.GetService<RealiziranaToDo4924State>();
                    break;
                case "Istekla":
                    return _serviceProvider.GetService<IsteklaToDo4924State>();
                    break;

                default:
                    throw new UserException("Not allowed");
            }
        }

        public virtual async Task<List<string>> AllowedActions()
        {
            return new List<string>();
        }

    }
}
