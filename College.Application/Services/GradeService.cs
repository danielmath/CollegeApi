using College.Application.DTOs;
using College.Application.Services.Contracts;
using College.Domain.Entities;
using College.Domain.Repositories;

namespace College.Application.Services
{
    public class GradeService : IGradeService
    {
        private readonly IGradeRepository _gradeRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;

        public GradeService(IGradeRepository gradeRepository, IStudentRepository studentRepository, ICourseRepository courseRepository)
        {
            _gradeRepository = gradeRepository;
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
        }

        public async Task<GradeDto?> GetByIdAsync(int id)
        {
            Grade? gradeEntity = await _gradeRepository.GetByIdAsync(id);
            if (gradeEntity == null)
                return null;

            return new GradeDto
            {
                Id = gradeEntity.Id,
                Value = gradeEntity.Value,
                DateRecorded = gradeEntity.DateRecorded,
                StudentId = gradeEntity.StudentId,
                CourseCode = gradeEntity.CourseCode.ToString()
            };
        }

        public async Task<IEnumerable<GradeDto>> GetAllAsync()
        {
            IEnumerable<Grade> gradesCollection = await _gradeRepository.GetAllAsync();
            
            return gradesCollection.Select(gradeEntity => new GradeDto
            {
                Id = gradeEntity.Id,
                Value = gradeEntity.Value,
                DateRecorded = gradeEntity.DateRecorded,
                StudentId = gradeEntity.StudentId,
                CourseCode = gradeEntity.CourseCode.ToString()
            });
        }

        public async Task<GradeDto> CreateAsync(CreateGradeDto createGradeDto)
        {
            Student? studentEntity = null;
            if (createGradeDto.StudentId > 0)
            {
                studentEntity = await _studentRepository.GetByIdAsync(createGradeDto.StudentId);
                if (studentEntity == null)
                    throw new InvalidOperationException($"El estudiante con ID {createGradeDto.StudentId} no existe.");
            }

            Course? courseEntity = null;
            if (!string.IsNullOrEmpty(createGradeDto.CourseCode))
            {
                courseEntity = await _courseRepository.GetByCodeAsync(createGradeDto.CourseCode);
                if (courseEntity == null)
                {
                    throw new InvalidOperationException($"El curso con código {createGradeDto.CourseCode} no existe.");
                }
            }

            Grade gradeEntity = new Grade(createGradeDto.Value, studentEntity, courseEntity);
            Grade createdGradeEntity = await _gradeRepository.AddAsync(gradeEntity);

            return new GradeDto
            {
                Id = createdGradeEntity.Id,
                Value = createdGradeEntity.Value,
                DateRecorded = createdGradeEntity.DateRecorded,
                StudentId = createdGradeEntity.StudentId,
                CourseCode = createdGradeEntity.CourseCode.ToString()
            };
        }

        public async Task<GradeDto?> UpdateAsync(int id, UpdateGradeDto updateGradeDto)
        {
            Grade? gradeEntity = await _gradeRepository.GetByIdAsync(id);
            if (gradeEntity == null)
                return null;

            gradeEntity.UpdateGrade(updateGradeDto.Value);
            await _gradeRepository.UpdateAsync(gradeEntity);

            return new GradeDto
            {
                Id = gradeEntity.Id,
                Value = gradeEntity.Value,
                DateRecorded = gradeEntity.DateRecorded,
                StudentId = gradeEntity.StudentId,
                CourseCode = gradeEntity.CourseCode.ToString()
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Grade? gradeEntity = await _gradeRepository.GetByIdAsync(id);
            if (gradeEntity == null)
                return false;

            await _gradeRepository.DeleteAsync(id);
            return true;
        }
    }
}