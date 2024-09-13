using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKlub.Model.SearchObjects
{
    public class ToDo4924SearchObject:BaseSearchObject
    {
        public string? ToDoKorisnikId { get; set; }
        //public string? ToDoKorisnickoIme { get; set; }

        public DateTime? ToDoDatumZavrsenja { get; set; }
        public string? ToDoStateMachine { get; set; } 
    }
}
