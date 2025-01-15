namespace University_Dasboard.Database.Models
{
    public class Marks
    {
        public Guid Id { get; set; }
        public int Mark { get; set; }
        public DateTime GradeDate { get; set; }
        public required string markType { get; set; }
        public int Semester {  get; set; }

        public Guid StudentId { get; set; }
        public Student? Student { get; set; }

        public Guid SubjectId { get; set; }
        public Subject? Subject { get; set; }
    }
}
