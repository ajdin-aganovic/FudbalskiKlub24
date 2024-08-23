using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Model.Requests
{
    public class NarudzbaUpdateRequest
    {

        //public string? BrojNarudzba { get; set; }

        public DateTime? Datum { get; set; }

        public string? Status { get; set; }
    }
}
