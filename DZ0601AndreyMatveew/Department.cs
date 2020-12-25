using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ0601AndreyMatveew
{
    public class Department : INotifyPropertyChanged
    {
        private string departmentName;
        public string DepartmentName
        {
            get => this.departmentName;
            set
            {
                this.departmentName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.DepartmentName)));
            }
        }
        public Department(string name)
        {
            DepartmentName = name;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
