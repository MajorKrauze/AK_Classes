using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AK_Classes.Models
{
    class Class
    {
        public string ClassName { get; set; }
        public ObservableCollection<Student> StudentsInThisClass;
        public int StudentsCount => StudentsInThisClass.Count();

        public Class(string className) 
        {
            ClassName = className;
            StudentsInThisClass = FilesAccess.Instance.GetThisClassStudents(targetClass: ClassName);
        }

        public void AddStudent(Student student)
        {
            StudentsInThisClass.Add(student);
            
        }
    }
}
