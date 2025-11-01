using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using College.Domain.Entities;

namespace College.Domain.Repositories
{
    public interface IProfessorRepository
    {
        Task<Professor?> GetByIdAsync(int id);
        Task<Professor> AddAsync(Professor professor);
        Task UpdateAsync(Professor professor);
        Task DeleteAsync(int id);
        Task<IEnumerable<Professor>> GetAllAsync();
    }
}
