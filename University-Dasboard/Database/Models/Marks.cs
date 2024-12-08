namespace University_Dasboard.Database.Models
{
    public class Marks
    {
        public Guid Id { get; set; }
        public int Grade { get; set; }
        public DateTime GradeDate { get; set; }
        public required string ExamType { get; set; }
        public Guid StudentId { get; set; }
        public Student? Student { get; set; }
        public Guid SubjectId { get; set; }
        public Discipline? Subject { get; set; }
    }
}
