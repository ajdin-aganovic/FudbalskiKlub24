using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Model.Requests
{
    public class ToDo4924Request
    {

        public string? nazivaktivnosti { get; set; }

        public string? opisaktivnosti { get; set; }
        public string? statemachine { get; set; }

        public DateTime datumzavrsenja { get; set; }
        public int korisnikid { get; set; }

    }
}
