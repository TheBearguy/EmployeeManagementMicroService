namespace EmployeeManagement
{
    public class Student
    {
        public Student()
        {
            this.Courses = new HashSet<Course>(); 
        }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte[] photo { get; set; }
        public decimal Height { get; set; }
        public float Weight { get; set; }
        public Grade Grade { get; set; }

        public virtual StudentAddress  Address {get; set;}
        public virtual ICollection<Course> Courses { get; set; }
    }
}
