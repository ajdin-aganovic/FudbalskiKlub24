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

        public virtual Task<Model.ToDo4924> Insert(ToDo4924InsertRequest request)
        {
            throw new UserException("Not allowed");
        }

        public virtual Task<Model.ToDo4924> Update(int id, ToDo4924UpdateRequest request)
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

        //public virtual Task<Model.ToDo4924> Delete(int id)
        //{
        //    throw new UserException("Not allowed");
        //}

        public BaseToDo4924State CreateState(string stateName)
        {
            switch (stateName)
            {
                case "initial":
                case null:
                    return _serviceProvider.GetService<InitialToDo4924State>();
                //break;
                case "U toku":
                    return _serviceProvider.GetService<UTokuToDo4924State>();
                case "Istekla":
                    return _serviceProvider.GetService<IstekniToDo4924State>();
                    //break;
                case "Realizovana":
                    return _serviceProvider.GetService<RealizujToDo4924State>();
                    //break;

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
