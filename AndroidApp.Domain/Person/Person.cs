using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidApp.Domain.Person
{
    public class Person
    {
        public int id;
        public string name;
        public string number;
        public Person(int id, string name, string number)
        {
            this.id = id;
            this.name = name;
            this.number = number;
        }
    }
}
