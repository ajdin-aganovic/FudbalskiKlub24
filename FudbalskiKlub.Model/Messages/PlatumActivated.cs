﻿using FudbalskiKlub.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Model.Messages
{
    public class PlatumActivated
    {
        public Platum? PlatumPoruka { get; set; }
        public Korisnik? KorisnikPlatumPoruka { get; set; }
    }
}
