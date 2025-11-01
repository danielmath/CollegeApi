using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.Domain.Entities
{
    public class Course
    {
        public int Id { get; private set; }
        public string Code { get; private set; }

        private readonly List<Grade> _grades = new();
        public IReadOnlyCollection<Grade> Grades => _grades.AsReadOnly();

        private readonly List<Student> _students = new();
        public IReadOnlyCollection<Student> Students => _students.AsReadOnly();

        private Course()
        {
            Code = string.Empty;
        }

        public Course(string code)
        {
            Code = code;
        }

        public void UpdateDetails(string code)
        {
            Code = code;
        }

        public void AddStudent(Student student)
        {
            _students.Add(student);
        }

        public void AddGrade(Grade grade)
        {
            _grades.Add(grade);
        }
    }
}
