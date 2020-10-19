using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ0501AndreyMatveew
{
    public class Employee
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Department { get; set; }

        public Employee(string name,string surname,string department)
        {
            Name = name;
            Surname = surname;
            Department = department;
        }
    }
}
