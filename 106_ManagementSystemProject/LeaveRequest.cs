using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _106_ManagementSystemProject
{
    public class LeaveRequest
    {
        public int RequestId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string LeaveType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int HoursRequested { get; set; }
        public string Status { get; set; }
    }
}
