namespace College.Application.DTOs
{
    public class GradeDto
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public DateTime DateRecorded { get; set; }
        public int StudentId { get; set; }
        public string CourseCode { get; set; } = string.Empty;
    }
}