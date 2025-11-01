using College.Application.DTOs;

namespace College.Application.Services.Contracts
{
    public interface IGradeService
    {
        Task<GradeDto?> GetByIdAsync(int id);
        Task<GradeDto> CreateAsync(CreateGradeDto createGradeDto);
        Task<GradeDto?> UpdateAsync(int id, UpdateGradeDto updateGradeDto);
        Task<bool> DeleteAsync(int id);
    }
}