﻿using System;
using System.Collections.Generic;

namespace FudbalskiKlub.Services.Model
{
    public partial class Termin
    {
        public int TerminId { get; set; }

        public string? SifraTermina { get; set; }

        public string? TipTermina { get; set; }

        public int? StadionId { get; set; }
        public string? Rezultat { get; set; }
        public bool? Izbrisan { get; set; }
        public DateTime? Datum { get; set; }

        public virtual Stadion? Stadion { get; set; }
    }
}


