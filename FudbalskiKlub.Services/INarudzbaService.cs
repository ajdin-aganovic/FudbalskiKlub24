using FudbalskiKlub.Model.Requests;
using FudbalskiKlub.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Services
{
    public interface INarudzbaService:ICRUDService<Model.Narudzba, NarudzbaSearchObject,
        NarudzbaInsertRequest, NarudzbaUpdateRequest>
    {
    }
}
