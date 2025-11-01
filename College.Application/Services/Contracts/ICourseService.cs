using College.Application.DTOs;

namespace College.Application.Services.Contracts
{
    public interface ICourseService
    {
        Task<CourseDto?> GetByIdAsync(int id);
        Task<CourseDto> CreateAsync(CreateCourseDto createCourseDto);
        Task<CourseDto?> UpdateAsync(int id, UpdateCourseDto updateCourseDto);
        Task<bool> DeleteAsync(int id);
    }
}