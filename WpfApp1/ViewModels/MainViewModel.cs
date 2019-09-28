using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Infrasructure;
using WpfApp1.Json;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    class MainViewModel: NotifyChanged
    {
        #region Properties

      
        private ObservableCollection<Student> students;
        public ObservableCollection<Student> Students
        {
            get => students;
            set
            {
                students = value;
                Notify();
            }
        }
        public Student SelectedStudent { get; set; }

        public bool Desc { get; set; }

        JsonDataService Json = new JsonDataService("Student.json");
        #endregion

        #region Commands 

        public System.Windows.Input.ICommand AddCommand { get; set; }
        public System.Windows.Input.ICommand RemoveCommand { get; set; }
        public System.Windows.Input.ICommand SaveCommand { get; set; }
        public System.Windows.Input.ICommand LoadCommand { get; set; }
        public System.Windows.Input.ICommand SortSurNameCommand { get; set; }
        public System.Windows.Input.ICommand SortNameCommand { get; set; }
        public System.Windows.Input.ICommand SortYearCommand { get; set; }
        public System.Windows.Input.ICommand SortGroupCommand { get; set; }
        #endregion

        #region SortedMethods
        public void SortSurName()
        {
            Student[] studentsArr = Students.ToArray<Student>();
            Array.Sort(studentsArr, (x, y) =>Desc ? y.SurName.CompareTo(x.SurName) : x.SurName.CompareTo(y.SurName));
            Students.Clear();
            foreach (var stud in studentsArr)
                Students.Add(stud);            
        }
        public void SortName()
        {
            Student[] studentsArr = Students.ToArray<Student>();
            Array.Sort(studentsArr, (x, y) => Desc ? y.Name.CompareTo(x.Name) : x.Name.CompareTo(y.Name));
            Students.Clear();
            foreach (var stud in studentsArr)
                Students.Add(stud);
        }
        public void SortYear()
        {
            Student[] studentsArr = Students.ToArray<Student>();
            Array.Sort(studentsArr, (x, y) => Desc ? y.Year-x.Year : x.Year-y.Year);
            Students.Clear();
            foreach (var stud in studentsArr)
                Students.Add(stud);
        }
        public void SortGroup()
        {
            Student[] studentsArr = Students.ToArray<Student>();
            Array.Sort(studentsArr, (x, y) => Desc ? y.Group.CompareTo(x.Group) : x.Group.CompareTo(y.Group));
            Students.Clear();
            foreach (var stud in studentsArr)
                Students.Add(stud);
        }



        #endregion

        public void SetStudents(ObservableCollection<Student> students)
        {
            Students = students; //
            Notify();
        }

        public void AddStudent()
        {             
            Students.Add(new Student { Name = "void", SurName = "void", Year = 1980, Group = "void" });
        }
        public void RemoveSelectedStudent()
        {
            Students.Remove(SelectedStudent);
        }

        public MainViewModel()
        {
            Students = new ObservableCollection<Student>() {
                new Student{SurName="11", Name="22",Year=1111, Group="asds" }
            };
           
            AddCommand = new RelayCommand(x =>
            {
                AddStudent();
            });
            RemoveCommand = new RelayCommand(x =>
            {
                RemoveSelectedStudent();
            });
            SaveCommand = new RelayCommand(x =>
            {               
                Json.Save(Students);
            });
            LoadCommand = new RelayCommand(x =>
            {
                var students = Json.Load();
                SetStudents(students);
            });
            SortSurNameCommand= new RelayCommand(x =>
            {
                SortSurName();
            });
            SortNameCommand = new RelayCommand(x =>
            {
                SortName();
            });
            SortYearCommand = new RelayCommand(x =>
            {
                SortYear();
            });
            SortGroupCommand = new RelayCommand(x =>
            {
                SortGroup();
            });
            Desc = false;
        }


    }
}
