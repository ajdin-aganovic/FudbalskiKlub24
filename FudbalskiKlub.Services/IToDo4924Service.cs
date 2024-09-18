using FudbalskiKlub.Model.Requests;
using FudbalskiKlub.Model.SearchObjects;
using FudbalskiKlub.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Services
{
    public interface IToDo4924Service:ICRUDService<Model.ToDo4924, ToDo4924SearchObject, ToDo4924Request, ToDo4924Request>
    {
        Task<ToDo4924> Realizuj(int id);
        Task<List<string>> AllowedActions(int id);
        Task<ToDo4924> Istekni(int id);


    }
}
