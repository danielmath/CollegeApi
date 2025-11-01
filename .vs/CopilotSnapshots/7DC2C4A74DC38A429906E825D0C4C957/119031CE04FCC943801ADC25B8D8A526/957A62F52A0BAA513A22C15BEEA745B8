using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using College.Domain.Entities;

namespace College.Domain.Repositories
{
    public interface IStudentRepository
    {
        Task<Student?> GetByIdAsync(int id);
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student> AddAsync(Student student);
        Task UpdateAsync(Student student);
        Task DeleteAsync(int id);
    }
}
