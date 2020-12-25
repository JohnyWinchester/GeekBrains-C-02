using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ0601AndreyMatveew
{
    public class DataBase
    {
        //private ObservableCollection<Employee> employees;
        //private ObservableCollection<Department> departments;

        public ObservableCollection<Employee> Employees { get; set; }
        public ObservableCollection<Department> Departments { get; set; }
        public DataBase()
        {
            Random rnd = new Random();
            Employees = new ObservableCollection<Employee>();
            Departments = new ObservableCollection<Department>();

            for (int i = 0; i < 10; i++)
            {
                Employees.Add(new Employee("Name_" + rnd.Next(1, 11), "Surname_" + rnd.Next(11, 21), "Department_" + rnd.Next(1, 5)));
            }

            for (int i = 1; i <= 4; i++)
            {
                Departments.Add(new Department("Department_" + i));
            }
        }

        public bool ContainsDepartment(string newDepName)
        {
            foreach(var el in Departments)
            {
                if (newDepName == el.DepartmentName) return true;
            }
            return false;
        }
    }
}
