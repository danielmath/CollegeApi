using College.Domain.Entities;
using College.Domain.Repositories;
using College.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace College.Infrastructure.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        private readonly CollegeDbContext _context;

        public GradeRepository(CollegeDbContext context)
        {
            _context = context;
        }

        public async Task<Grade?> GetByIdAsync(int id)
        {
            return await _context.Grades
                .FirstOrDefaultAsync(gradeEntity => gradeEntity.Id == id);
        }

        public async Task<IEnumerable<Grade>> GetAllAsync()
        {
            return await _context.Grades
                .ToListAsync();
        }

        public async Task<IEnumerable<Grade>> GetByCourseIdAsync(int courseId)
        {
            return await _context.Grades
                .Where(gradeEntity => gradeEntity.CourseCode == courseId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Grade>> GetByStudentIdAsync(int studentId)
        {
            return await _context.Grades
                .Where(gradeEntity => gradeEntity.StudentId == studentId)
                .ToListAsync();
        }

        public async Task<Grade> AddAsync(Grade grade)
        {
            await _context.Grades.AddAsync(grade);
            await _context.SaveChangesAsync();
            return grade;
        }

        public async Task UpdateAsync(Grade grade)
        {
            _context.Grades.Update(grade);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Grade? gradeEntity = await _context.Grades
                .FirstOrDefaultAsync(gradeEntity => gradeEntity.Id == id);

            if (gradeEntity != null)
            {
                _context.Grades.Remove(gradeEntity);
                await _context.SaveChangesAsync();
            }
        }
    }
}