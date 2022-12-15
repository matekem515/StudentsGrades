using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeApp
{
   public class Person
    {
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public Person(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }
    }
}
