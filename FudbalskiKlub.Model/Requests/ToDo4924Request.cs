using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Model.Requests
{
    public class ToDo4924Request
    {
        public int? todo4924id { get; set; }

        public string? nazivaktivnosti { get; set; }

        public string? opisaktivnosti { get; set; }

        public DateTime? datumzavrsenja { get; set; }

        public int korisnikid { get; set; }
        public string? statemachine { get; set; }

    }
}
