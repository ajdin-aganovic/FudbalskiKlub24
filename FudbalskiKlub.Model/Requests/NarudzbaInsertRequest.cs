using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Model.Requests
{
    public class NarudzbaInsertRequest
    {

        //public string? BrojNarudzba { get; set; }

        public DateTime? Datum { get; set; }

        public string? Status { get; set; }

        public int? KorisnikId { get; set; }
        
        
        public List<NarudzbaStavkeInsertRequest> ListaStavki { get; set; }

    }
}
