using FudbalskiKlub.Model;
using FudbalskiKlub.Model.Requests;
using FudbalskiKlub.Services;
using FudbalskiKlub.Services.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FudbalskiKlub.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class ToDo4924Controller :
        BaseCRUDController<
            ToDo4924,
            Model.SearchObjects.ToDo4924SearchObject, Model.Requests.ToDo4924Request, Model.Requests.ToDo4924Request>
    {
        public ToDo4924Controller(ILogger<BaseController<ToDo4924, Model.SearchObjects.ToDo4924SearchObject>> logger, IToDo4924Service service) : base(logger, service)
        {

        }

        [HttpPut("{id}/realizuj")]
        public virtual async Task<ToDo4924> Realizuj(int id)
        {
            return await (_service as IToDo4924Service).Realizuj(id);
        }

        [HttpPut("{id}/istekni")]
        public virtual async Task<ToDo4924> Istekni(int id)
        {
            return await (_service as IToDo4924Service).Istekni(id);
        }


        [HttpGet("{id}/allowedActions")]
        public virtual async Task<List<string>> AllowedActions(int id)
        {
            return await (_service as IToDo4924Service).AllowedActions(id);
        }



    }
}
