using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.Domain.Entities
{
    public class Student
    {
        public int Id { get; private set; }
        public string FullName { get; private set; }
        public string? CourseCode { get; private set; }

        private readonly List<Grade> _grades = new();
        public IReadOnlyCollection<Grade> Grades => _grades.AsReadOnly();

        private Student()
        {
            FullName = string.Empty;
        }

        public Student(string fullName, Course? course = null)
        {
            FullName = fullName;
            CourseCode = course?.Code;
        }

        public void UpdateFullName(string fullName)
        {
            FullName = fullName;
        }

        public void UpdateCourse(Course? course)
        {
            CourseCode = course?.Code;
        }
    }
}
