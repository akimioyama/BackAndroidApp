using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndroidApp.Domain.Person;
using Microsoft.AspNetCore.Mvc;

namespace AndroidApp.SQL.Repository.Interfaces
{
    public interface IPersonSelects
    {
        public bool CreatePerson(Person1 perosn);
        public bool DeletePerson(int id);
        public List<Person1> GetPerson(int id);
        public List<Person1> GetAllPerson();
        public bool PutPerson(int id, Person1 person);

    }
}
