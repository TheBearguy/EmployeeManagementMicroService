namespace EmployeeManagement
{
    public class Grade
    { 
        public Grade()
        {
            this.Students = new HashSet<Student>();
        }
        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public string Section { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
