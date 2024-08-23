using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FudbalskiKlub.Model.Requests;

namespace FudbalskiKlub.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BolestInsertRequest, Database1.Bolest>();
            CreateMap<BolestUpdateRequest, Database1.Bolest>();
            CreateMap<ClanarinaInsertRequest, Database1.Clanarina>();
            CreateMap<ClanarinaUpdateRequest, Database1.Clanarina>();
            CreateMap<KorisnikInsertRequest, Database1.Korisnik>();
            CreateMap<KorisnikChangePasswordRequest, Database1.Korisnik>();
            CreateMap<KorisnikPozicijaInsertRequest, Database1.KorisnikPozicija>();
            CreateMap<KorisnikPozicijaUpdateRequest, Database1.KorisnikPozicija>();
            CreateMap<KorisnikUlogaInsertRequest, Database1.KorisnikUloga>();
            CreateMap<KorisnikUlogaUpdateRequest, Database1.KorisnikUloga>();
            CreateMap<KorisnikUpdateRequest, Database1.Korisnik>();
            CreateMap<NarudzbaInsertRequest, Database1.Narudzba>();
            CreateMap<NarudzbaUpdateRequest, Database1.Narudzba>();
            CreateMap<NarudzbaStavkeInsertRequest, Database1.Narudzba>();
            CreateMap<PlatumInsertRequest, Database1.Platum>();
            CreateMap<PlatumUpdateRequest, Database1.Platum>();
            CreateMap<PozicijaInsertRequest, Database1.Pozicija>();
            CreateMap<PozicijaUpdateRequest, Database1.Pozicija>();
            CreateMap<StadionInsertRequest, Database1.Stadion>();
            CreateMap<StadionUpdateRequest, Database1.Stadion>();
            CreateMap<StatistikaInsertRequest, Database1.Statistika>();
            CreateMap<StatistikaUpdateRequest, Database1.Statistika>();
            CreateMap<TerminInsertRequest, Database1.Termin>();
            CreateMap<TerminUpdateRequest, Database1.Termin>();
            CreateMap<TransakcijskiRacunInsertRequest, Database1.TransakcijskiRacun>();
            CreateMap<TransakcijskiRacunUpdateRequest, Database1.TransakcijskiRacun>();
            CreateMap<TreningInsertRequest, Database1.Trening>();
            CreateMap<TreningUpdateRequest, Database1.Trening>();
            CreateMap<UlogaInsertRequest, Database1.Uloga>();
            CreateMap<UlogaUpdateRequest, Database1.Uloga>();
            CreateMap<ProizvodInsertRequest, Database1.Proizvod>();
            CreateMap<ProizvodUpdateRequest, Database1.Proizvod>();



            ////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////

            CreateMap<Database1.Bolest, Model.Bolest>();
            CreateMap<Database1.Clanarina, Model.Clanarina>();
            CreateMap<Database1.Korisnik, Model.Korisnik>();
            CreateMap<Database1.KorisnikBolest, Model.KorisnikBolest>();
            CreateMap<Database1.KorisnikPozicija, Model.KorisnikPozicija>();
            CreateMap<Database1.KorisnikTransakcijskiRacun, Model.KorisnikTransakcijskiRacun>();
            CreateMap<Database1.KorisnikUloga, Model.KorisnikUloga>();
            CreateMap<Database1.Narudzba, Model.Narudzba>();
            CreateMap<Database1.NarudzbaStavke, Model.NarudzbaStavke>();
            CreateMap<Database1.Platum, Model.Platum>();
            CreateMap<Database1.Pozicija, Model.Pozicija>();
            CreateMap<Database1.Proizvod, Model.Proizvod>();
            CreateMap<Database1.Stadion, Model.Stadion>();
            CreateMap<Database1.Statistika, Model.Statistika>();
            CreateMap<Database1.Termin, Model.Termin>();
            CreateMap<Database1.TransakcijskiRacun, Model.TransakcijskiRacun>();
            CreateMap<Database1.Trening, Model.Trening>();
            CreateMap<Database1.TreningStadion, Model.TreningStadion>();
            CreateMap<Database1.Uloga, Model.Uloga>();


        }
    }

    //public UserProfile()
    //{
    //    CreateMap<User, UserViewModel>();
    //}
}
