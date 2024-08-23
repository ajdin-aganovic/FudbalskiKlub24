using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Model.Requests
{
    public class NarudzbaStavkeInsertRequest
    {

        public int ProizvodId { get; set; }
        public int Kolicina { get; set; }
    }
}
