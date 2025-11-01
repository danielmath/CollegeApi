using College.Domain.Entities;
using College.Domain.Repositories;
using College.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace College.Infrastructure.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly CollegeDbContext _context;

        public ProfessorRepository(CollegeDbContext context)
        {
            _context = context;
        }

        public async Task<Professor?> GetByIdAsync(int id)
        {
            return await _context.Professors.FindAsync(id);
        }

        public async Task<IEnumerable<Professor>> GetAllAsync()
        {
            return await _context.Professors.ToListAsync();
        }

        public async Task<Professor> AddAsync(Professor professor)
        {
            _context.Professors.Add(professor);
            await _context.SaveChangesAsync();
            return professor;
        }

        public async Task UpdateAsync(Professor professor)
        {
            _context.Professors.Update(professor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Professor? professorEntity = await GetByIdAsync(id);
            if (professorEntity != null)
            {
                _context.Professors.Remove(professorEntity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
