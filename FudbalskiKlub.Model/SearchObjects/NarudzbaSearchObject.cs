using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Model.SearchObjects
{
    public class NarudzbaSearchObject : BaseSearchObject
    {
        public string? BrojNarudzba { get; set; }
        public bool? IncludeKorisnik { get; set; }
        public bool? IncludeNarudzbaStavke { get; set; }
        public int? KorisnikId { get; set; }
    }
}
