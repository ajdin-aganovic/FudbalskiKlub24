using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Model.SearchObjects
{
    public class ToDo4924SearchObject : BaseSearchObject
    {
        public string? korisnikid { get; set; }
        public DateTime? datumzavrsenja { get; set; }
        public string? statemachine { get; set; }
    }
}
