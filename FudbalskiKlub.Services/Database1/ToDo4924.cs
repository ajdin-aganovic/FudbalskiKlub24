using System;
using System.Collections.Generic;

namespace FudbalskiKlub.Services.Database1;

public partial class ToDo4924
{
    public int todo4924Id { get; set; }
    public int? korisnikId { get; set; }
    public virtual Korisnik? Korisnik { get; set; }
    public string? nazivAktivnosti { get; set; }
    public string? opisAktivnosti { get; set; }

    public DateTime? datumZavrsenja { get; set; }
    public string? stateMachine { get; set; }


}
