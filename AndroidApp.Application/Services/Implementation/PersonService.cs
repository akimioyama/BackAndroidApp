using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndroidApp.Application.DTO;
using AndroidApp.Application.Services;
using AndroidApp.SQL.Repository.Implementation;
using AndroidApp.SQL.Repository.Interfaces;
using AndroidApp.Domain.Person;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using AndroidApp.Application.Services.Interfaces;

namespace AndroidApp.Application.Services.Implementation
{
    public class PersonService : IPersonService
    {
        IConfiguration _configuration;
        IPersonSelects personSelects;
        public PersonService(IConfiguration conf)
        {
            _configuration = conf;
            personSelects = new PersonSelects();
        }

        public PersonDTO CreatePerson(PersonDTO personDTO)
        {
            Person1 person = new Person1()
            {
                id = -1,
                name = personDTO.name,
                number = personDTO.number
            };
            if (personSelects.CreatePerson(person))
            {
                return personDTO;
            }
            return null;
        }

        public bool DeletePerson(int id)
        {
            return personSelects.DeletePerson(id);
        }

        public List<PersonDTO> GetAllPerson()
        {
            List<Person1> personList = personSelects.GetAllPerson();
            if (personList != null)
            {
                List<PersonDTO> personDTOs = new List<PersonDTO>();
                foreach (Person1 person in personList)
                {
                    PersonDTO personDTO = new PersonDTO()
                    {
                        id = person.id,
                        name = person.name,
                        number = person.number
                    };
                    personDTOs.Add(personDTO);
                }
                return personDTOs;
            }
            return null;
        }

        public List<PersonDTO> GetPerson(int id)
        {
            List<Person1> personList = personSelects.GetPerson(id);
            if(personList != null)
            {
                List<PersonDTO> personDTOs = new List<PersonDTO>();
                foreach (Person1 person in personList)
                {
                    PersonDTO personDTO = new PersonDTO()
                    {
                        id = person.id,
                        name = person.name,
                        number = person.number
                    };
                    personDTOs.Add(personDTO);
                }
                return personDTOs;
            }
            return null;
        }

        public bool PutPerson(int id, PersonDTO personDTO)
        {
            Person1 person = new Person1()
            {
                id = -1,
                name = personDTO.name,
                number = personDTO.number
            };
            return personSelects.PutPerson(id, person);
        }
    }
}
