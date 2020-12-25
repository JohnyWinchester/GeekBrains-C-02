using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ0601AndreyMatveew
{
    public class Employee : INotifyPropertyChanged
    {
        private string name;
        private string surname;
        private string department;
        public string Name
        {
            get => this.name;
            set
            {
                this.name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Name)));
            }
        }
        public string Surname
        {
            get => this.surname;
            set
            {
                this.surname = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Surname)));
            }
        }
        public string Department
        {
            get => this.department;
            set
            {
                this.department = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Department)));
            }
        }
        public Employee(string name, string surname, string department)
        {
            Name = name;
            Surname = surname;
            Department = department;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
