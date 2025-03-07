using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.DTOs
{
    class EmployeeProjectDTO
    {
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        public DateTime AssignedDate { get; set; }
    }
}
