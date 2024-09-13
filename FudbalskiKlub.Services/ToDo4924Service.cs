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
        BaseCRUDService<Model.ToDo4924, Database1.ToDo4924, ToDo4924SearchObject, ToDo4924InsertRequest, ToDo4924UpdateRequest>, IToDo4924Service

    {
        public BaseToDo4924State _baseState { get; set; }
        public ToDo4924Service(BaseToDo4924State baseState, MiniafkContext context, IMapper mapper) : base(context, mapper)
        {
            _baseState = baseState;
        }

        public override IQueryable<Database1.ToDo4924> AddFilter(IQueryable<Database1.ToDo4924> query, ToDo4924SearchObject? search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (search?.ToDoKorisnikId!=null)
            {
                filteredQuery = filteredQuery.Where(x => x.korisnikId.ToString().StartsWith(search.ToDoKorisnikId));
            }
            //if(search.ToDoKorisnickoIme!=null)
            //{
            //    filteredQuery = filteredQuery.Include(x => x.Korisnik).Where(x => x.Korisnik.KorisnickoIme == search.ToDoKorisnickoIme);
            //}
            if (!string.IsNullOrWhiteSpace(search?.ToDoStateMachine))
            {
                filteredQuery = filteredQuery.Where(x => x.stateMachine.Contains(search.ToDoStateMachine));
            }
            if (search.ToDoDatumZavrsenja.HasValue)
            {
                filteredQuery = filteredQuery.Where(x => x.datumZavrsenja<search.ToDoDatumZavrsenja);
            }



            return filteredQuery;
        }

        
        public override Task<Model.ToDo4924> Insert(ToDo4924InsertRequest insert)
        {
            //ToDo4924 novi = new ToDo4924();

            var state = _baseState.CreateState("initial");

            return state.Insert(insert);

        }

        public override Task<Model.ToDo4924> Update(int id, ToDo4924UpdateRequest update)
        {
            var entity =  _context.ToDo4924.Find(id);
            var state = _baseState.CreateState(entity.stateMachine);

            return state.Update(id, update);
        }

        public async Task<Model.ToDo4924> Realizuj(int id)
        {
            var entity = await _context.ToDo4924.FindAsync(id);

            var state = _baseState.CreateState(entity.stateMachine);

            return await state.Realizuj(id);
        }

        public async Task<Model.ToDo4924> Istekni(int id)
        {
            var entity = await _context.ToDo4924.FindAsync(id);

            var state = _baseState.CreateState(entity.stateMachine);

            return await state.Istekni(id);
        }

        public async Task<List<string>> AllowedActions(int id)
        {
            var entity = await _context.ToDo4924.FindAsync(id);
            var state = _baseState.CreateState(entity?.stateMachine ?? "U toku");
            return await state.AllowedActions();
        }

    }
}
