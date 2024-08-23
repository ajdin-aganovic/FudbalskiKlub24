using System;
using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FudbalskiKlub.Services.Database1;

public partial class Narudzba
{
    public int NarudzbaId { get; set; }

    public string? BrojNarudzba { get; set; }

    public int? KorisnikId { get; set; }
    public DateTime? Datum { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<NarudzbaStavke> NarudzbaStavkes { get; set; }

    //public Narudzba()
    //{
    //    NarudzbaProizvodis = new HashSet<NarudzbaProizvodi>();
    //}

    public virtual Korisnik? Korisnik { get; set; } = null;
}
