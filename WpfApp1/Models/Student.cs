using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Infrasructure;

namespace WpfApp1.Models
{
    class Student : NotifyChanged
    {
        private string name;
        private string surname;
        private int year;
        private string group;

        public string Name
        {
            get => name;
            set
            {
                name = value;
                Notify();
            }
        }
        public string SurName
        {
            get => surname;
            set
            {
                surname = value;
                Notify();
            }
        }
        public int Year
        {
            get => year;
            set
            {
                year = value;
                Notify();
            }
        }
        public string Group
        {
            get => group;
            set
            {
                group = value;
                Notify();
            }
        }

      
    }
}
