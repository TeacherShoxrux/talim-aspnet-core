namespace  Talim.Data.Entity;
public class Enrollment
{
    public int EnrollmentId { get; set; }
    public int UserId { get; set; }
    public int SubjectId { get; set; }
    public DateTime EnrolledAt { get; set; } = DateTime.Now;
    public User User { get; set; }
    public Subject Subject { get; set; }
}