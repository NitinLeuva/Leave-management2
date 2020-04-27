using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement3.Models
{
    public class CreateLeaveAllocationVM
    {
        public int Id { get; set; }
        public int NumberUpdates { get; set; }
        public List<LeaveTypeVM> leaveTypes { get; set; }

        public int MyProperty { get; set; }
    }
}
