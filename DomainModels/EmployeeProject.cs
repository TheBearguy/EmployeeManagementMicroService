using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
    public class EmployeeProject
    {
        public int EmployeeId { get; set; }
        public int ProjectId { get; set;  }
        public DateTime AssignedDate { get; set; }
    }
}
