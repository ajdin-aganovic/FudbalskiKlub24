using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace FudbalskiKlub.Services.Model
{
    public partial class Narudzba
    {
        public int NarudzbaId { get; set; }

        public string? BrojNarudzba { get; set; }

        public DateTime? Datum { get; set; }
        public int? KorisnikId { get; set; }

        public string? Status { get; set; }
        
        public virtual ICollection<NarudzbaStavke> NarudzbaStavke { get; set; }
        
        //public string KorisnikIme => $"{Korisnik?.Ime} {Korisnik?.Prezime}";
        //public string NarudzbaProizvodi => string.Join(", ", NarudzbaStavke?.Select(x => $"{x.Proizvod?.Naziv} x{x.Kolicina}")?.ToList());
        //[DisplayName("Ukupna cijena")]
        //public double UkupnaCijena => NarudzbaStavke.Sum(x => x.Proizvod.Cijena??0 * x.Kolicina??0);
        public virtual Korisnik? Korisnik { get; set; }

    }

}

