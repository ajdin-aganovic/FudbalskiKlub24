using AutoMapper;
using FudbalskiKlub.Model.Requests;
using FudbalskiKlub.Model.SearchObjects;
using FudbalskiKlub.Services.Database1;
using FudbalskiKlub.Services.ProizvodiStateMachine;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Services
{
    public class NarudzbaService:
        BaseCRUDService<Model.Narudzba, Database1.Narudzba, NarudzbaSearchObject, NarudzbaInsertRequest, NarudzbaUpdateRequest>, INarudzbaService

    {
        public NarudzbaService(MiniafkContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<Model.Narudzba> Insert(NarudzbaInsertRequest request)
        {

            var set = _context.Set<Narudzba>();

            Narudzba entity = _mapper.Map<Narudzba>(request);

            set.Add(entity);
            await BeforeInsert(entity, request);

            await _context.SaveChangesAsync();


            foreach (var proizvod in request.ListaStavki)
            {
                Database1.NarudzbaStavke Proizvod = new Database1.NarudzbaStavke();
                Proizvod.ProizvodId = proizvod.ProizvodId;
                Proizvod.Kolicina = proizvod.Kolicina;
                Proizvod.NarudzbaId = entity.NarudzbaId;
                _context.Add(Proizvod);
            }
            await _context.SaveChangesAsync();
            return _mapper.Map<Model.Narudzba>(entity);

        }

        public override async Task BeforeInsert(Narudzba entity, NarudzbaInsertRequest insert )
        {
            
            entity.BrojNarudzba = Guid.NewGuid().ToString();
            entity.Status = "Kreirano";
            entity.KorisnikId = insert.KorisnikId ?? 0;
            entity.Datum = DateTime.Now;
        }

        public override async Task AfterUpdate(Narudzba entity, NarudzbaUpdateRequest update)
        {
            entity.Status = "Modifikovano";
        }



        public override IQueryable<Database1.Narudzba> AddFilter(IQueryable<Database1.Narudzba> query, NarudzbaSearchObject? search = null)
        {
            if (!string.IsNullOrWhiteSpace(search.BrojNarudzba))
            {
                query = query.Where(x => x.BrojNarudzba.StartsWith(search.BrojNarudzba));
            }

            if (search.KorisnikId.HasValue)
            {
                query = query.Where(x => x.KorisnikId == search.KorisnikId);
            }


            var filteredQuery = base.AddFilter(query, search);

            
            return filteredQuery;
        }

        public override IQueryable<Database1.Narudzba> AddInclude(IQueryable<Database1.Narudzba> query, NarudzbaSearchObject? search = null)
        {
            if (search.IncludeKorisnik == true)
            {
                query = query.Include(x => x.Korisnik);
            }

            if (search.IncludeNarudzbaStavke == true)
            {
                query = query.Include(x => x.Korisnik).Include(x => x.NarudzbaStavkes).ThenInclude(x => x.Proizvod);
            }

            return query;
        }
    }
}
