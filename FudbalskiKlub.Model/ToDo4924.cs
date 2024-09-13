using System;
using System.Collections.Generic;

namespace FudbalskiKlub.Services.Model
{
        public partial class ToDo4924
    {
        public int todo4924Id { get; set; }

        public int? korisnikId { get; set; }
        public string? nazivAktivnosti { get; set; }
        public string? opisAktivnosti { get; set; }

        public DateTime? datumZavrsenja { get; set; }
        public string? stateMachine { get; set; }


    }
}

