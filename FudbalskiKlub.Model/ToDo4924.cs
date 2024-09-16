using System;
using System.Collections.Generic;

namespace FudbalskiKlub.Services.Model
{
    public partial class ToDo4924
    {
        public int todo4924id { get; set; }

        public string? nazivaktivnosti { get; set; }

        public string? opisaktivnosti { get; set; }

        public DateTime datumzavrsenja { get; set; }

        public int korisnikid { get; set; }
        public string? statemachine { get; set; }

    }

}

