using AutoMapper;
using FudbalskiKlub.Model.Requests;
using FudbalskiKlub.Model.SearchObjects;
using FudbalskiKlub.Services.Database1;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML.Trainers;
using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;
using FudbalskiKlub.Services.ToDo4924StateMachine;
using Microsoft.IdentityModel.Tokens;

namespace FudbalskiKlub.Services
{
    public class ToDo4924Service :
        BaseCRUDService<Model.ToDo4924, Database1.ToDo4924, ToDo4924SearchObject, ToDo4924Request, ToDo4924Request>, IToDo4924Service

    {
        public BaseToDo4924State _baseState { get; set; }
        public ToDo4924Service(BaseToDo4924State baseState, MiniafkContext context, IMapper mapper) : base(context, mapper)
        {
            _baseState = baseState;
        }

        public override IQueryable<Database1.ToDo4924> AddFilter(IQueryable<Database1.ToDo4924> query, ToDo4924SearchObject? search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (!string.IsNullOrWhiteSpace(search?.korisnikid))
            {
                filteredQuery = filteredQuery.Where(x => x.korisnikid.ToString()==search.korisnikid);
            }
            if (!string.IsNullOrWhiteSpace(search?.statemachine))
            {
                filteredQuery = filteredQuery.Where(x => x.statemachine==search.statemachine);
            }
            if(search.datumzavrsenja.HasValue)
            {
                filteredQuery = filteredQuery.Where(x => x.datumzavrsenja < search.datumzavrsenja);
            }    

           

            return filteredQuery;
        }


        public override Task<Model.ToDo4924> Insert(ToDo4924Request insert)
        {
            var state = _baseState.CreateState("U toku");

            return state.Insert(insert);

        }

        public override async Task<Model.ToDo4924> Update (int id, ToDo4924Request update)
        {
            var entity = await _context.ToDo4924.FindAsync(id);
            var state = _baseState.CreateState(entity.statemachine);

            return await state.Update(id, update);
        }

        public async Task<Model.ToDo4924> Realizuj(int id)
        {
            var entity = await _context.ToDo4924.FindAsync(id);

            var state = _baseState.CreateState(entity.statemachine);

            return await state.Realizuj(id);
        }

        public async Task<Model.ToDo4924> Istekni(int id)
        {
            var entity = await _context.ToDo4924.FindAsync(id);

            var state = _baseState.CreateState(entity.statemachine);

            return await state.Istekni(id);
        }

        public async Task<List<string>> AllowedActions(int id)
        {
            var entity = await _context.ToDo4924.FindAsync(id);
            var state = _baseState.CreateState(entity?.statemachine ?? "U toku");
            return await state.AllowedActions();
        }

    }
}
