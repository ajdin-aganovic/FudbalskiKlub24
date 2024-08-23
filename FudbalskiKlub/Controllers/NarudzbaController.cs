using FudbalskiKlub.Model;
using FudbalskiKlub.Model.Requests;
using FudbalskiKlub.Model.SearchObjects;
using FudbalskiKlub.Services;
using FudbalskiKlub.Services.Model;
using Microsoft.AspNetCore.Mvc;

namespace FudbalskiKlub.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NarudzbaController :
        BaseCRUDController<
            Narudzba,
            NarudzbaSearchObject,
            NarudzbaInsertRequest,
            NarudzbaUpdateRequest
            >
    {
        public NarudzbaController(ILogger<BaseController<Narudzba, Model.SearchObjects.NarudzbaSearchObject>> logger, INarudzbaService service) : base(logger, service)
        {

        }
    }
}
