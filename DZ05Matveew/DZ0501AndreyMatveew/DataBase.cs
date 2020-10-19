using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ0501AndreyMatveew
{
    public class DataBase:IEnumerable<string>
    {
        public ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
        public ObservableCollection<Department> departments = new ObservableCollection<Department>();

        public DataBase()
        {
            Random rnd = new Random();
            for(int i = 0;i < 10;i++)
            {
                employees.Add(new Employee("Name_" + rnd.Next(1, 10), "Surname_" + rnd.Next(11, 20), "Department_" + rnd.Next(1,4)));
            }

            for(int i = 1;i < 4;i++)
            {
                departments.Add(new Department("Department_" + i));
            }
        }

        public IEnumerator<string> GetEnumerator()
        {
            foreach (var el in departments)
            {
                yield return el.DepartmentName;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
