using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndroidApp.Application.DTO;

namespace AndroidApp.Application.Services.Interfaces
{
    public interface IPersonService
    {
        public PersonDTO CreatePerson(PersonDTO personDTO);
        public List<PersonDTO> GetPerson(int id);
        public List<PersonDTO> GetAllPerson();
        public bool DeletePerson(int id);
        public bool PutPerson(int id, PersonDTO personDTO);
    }
}
