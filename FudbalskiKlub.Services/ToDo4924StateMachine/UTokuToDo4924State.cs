using AutoMapper;
using FudbalskiKlub.Model;
using FudbalskiKlub.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Services.ToDo4924StateMachine
{
    public class UTokuToDo4924State : BaseToDo4924State
    {
        public UTokuToDo4924State(IServiceProvider serviceProvider, Database1.MiniafkContext context, IMapper mapper) : base(serviceProvider, context, mapper)
        {
        }

        public override async Task<Model.ToDo4924> Insert(ToDo4924InsertRequest request)
        {
            //TODO: EF CALL
            var set = _context.Set<Database1.ToDo4924>();

            var entity = _mapper.Map<Database1.ToDo4924>(request);

            entity.stateMachine = "U toku";

            set.Add(entity);

            await _context.SaveChangesAsync();
            return _mapper.Map<Model.ToDo4924>(entity);
        }

        public override async Task<Model.ToDo4924> Realizuj(int id)
        {

            var set = _context.Set<Database1.ToDo4924>();

            var entity = await set.FindAsync(id);

            if (DateTime.Now > entity.datumZavrsenja)
                throw new Exception("Bad request");

            entity.stateMachine = "Realizovana";

            await _context.SaveChangesAsync();
            var mappedEntity = _mapper.Map<Model.ToDo4924>(entity);

            return mappedEntity;
        }

        public override async Task<Model.ToDo4924> Istekni(int id)
        {

            var set = _context.Set<Database1.ToDo4924>();

            var entity = await set.FindAsync(id);

            entity.stateMachine = "Istekla";

            await _context.SaveChangesAsync();
            var mappedEntity = _mapper.Map<Model.ToDo4924>(entity);



            return mappedEntity;
        }


        public override async Task<Model.ToDo4924> Update(int id, ToDo4924UpdateRequest request)
        {
            var set = _context.Set<Database1.ToDo4924>();

            var entity = await set.FindAsync(id);

            _mapper.Map(request, entity);

            await _context.SaveChangesAsync();
            return _mapper.Map<Model.ToDo4924>(entity);
        }

        //public override async Task<Model.ToDo4924> Hide(int id)
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

            list.Add("Update");
            list.Add("Realizuj");
            list.Add("Istekni");

            return list;
        }
    }
}
