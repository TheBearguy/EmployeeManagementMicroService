using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement
{
    public class StudentAddress
    {
        [ForeignKey("Student")]
        public int StudentAddressId { get; set; }
        public string Address1 { get; set; }
        public string Addresss2 { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
