using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AK_Classes.Models
{
    class FilesAccess
    {
        public static FilesAccess Instance { get; } = Instance == null ? new FilesAccess() : Instance;
        public const string ClassesFileName = "classes.json";
        public const string StudentsFileName = "students.json";
        public string ClassesFilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + Path.DirectorySeparatorChar + ClassesFileName;
        public string StudentsFilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + Path.DirectorySeparatorChar + StudentsFileName;

        public ObservableCollection<Class> Classes = new ObservableCollection<Class>();
        public ObservableCollection<Student> Students = new ObservableCollection<Student>();

        public void LoadClasses()
        {
            try { 
                string jsonData;
            
                if (File.Exists(ClassesFilePath))
                {
                    jsonData = File.ReadAllText(ClassesFilePath);
                    this.Classes = JsonSerializer.Deserialize<ObservableCollection<Class>>(jsonData) ?? this.Classes;
                }
                else
                {
                    Console.WriteLine($"File {ClassesFileName} does not exist, creating...");
                    jsonData = JsonSerializer.Serialize(this.Classes);
                    File.WriteAllText(ClassesFilePath, jsonData);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erroe loading prducts: {ex.Message}");
            }

        }

        public void LoadStudents()
        {
            try
            {
                string jsonData;

                if (File.Exists(StudentsFilePath))
                {
                    jsonData = File.ReadAllText(StudentsFilePath);
                    this.Students = JsonSerializer.Deserialize<ObservableCollection<Student>>(jsonData) ?? this.Students;
                }
                else
                {
                    Console.WriteLine($"File {StudentsFileName} does not exist, creating...");
                    jsonData = JsonSerializer.Serialize(this.Students);
                    File.WriteAllText(StudentsFilePath, jsonData);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erroe loading prducts: {ex.Message}");
            }

        }

        public ObservableCollection<Student> GetThisClassStudents(string targetClass)
        {
            var studentsInTargetClass = new ObservableCollection<Student>(Students.Where(student => student.Class == targetClass));
            return studentsInTargetClass;

        }
    }
}
