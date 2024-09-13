using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Model.Requests
{
    public class ToDo4924UpdateRequest
    {
        public string? OpisAktivnosti { get; set; }

        public string? NazivAktivnosti { get; set; }

        public DateTime? DatumZavrsenja { get; set; }
        public int? KorisnikId { get; set; }
        //public string? StateMachine { get; set; }


    }
}
