using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement3.Models
{
    public class LeaveTypeVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Default Leave Days")]
        [Range(1,12,ErrorMessage ="Pleaase enter proper range")]
        public int DefaultDays { get; set; }

        [Display (Name = "Date Created")]
        public DateTime? DateCreated { get; set; }
    }

    
}
