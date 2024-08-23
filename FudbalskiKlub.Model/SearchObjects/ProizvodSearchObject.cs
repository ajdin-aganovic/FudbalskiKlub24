using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Model.SearchObjects
{
    public class ProizvodSearchObject:BaseSearchObject
    {
        public string? NazivProizvoda { get; set; }

        public string? SifraProizvoda { get; set; }
        //public bool? StateMachineProizvoda { get; set; } = false; //Možda pretvoriti u checkbox
    }
}
