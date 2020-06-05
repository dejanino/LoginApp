using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApplication
{
    class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public IList<Student> GetStudents()
        {
            // Student collection
            IList<Student> studentList = new List<Student>() {
                new Student() { ID = 1, Name = "Darko", Age = 13 },
                new Student() { ID = 2, Name = "Milos", Age = 13 },
                new Student() { ID = 3, Name = "Marko",  Age = 21 } ,
                new Student() { ID = 4, Name = "Zarko",  Age = 18 } ,
                new Student() { ID = 5, Name = "Jovan",  Age = 18 } ,
                new Student() { ID = 6, Name = "Janko" , Age = 20 } ,
                new Student() { ID = 7, Name = "Branko" , Age = 20 }
            };
            return studentList;
        }
    }
}
