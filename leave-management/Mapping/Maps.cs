using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Mappers;
using AutoMapper;
using leave_management.Models;
using leave_management.Data;

namespace leave_management.Mapping
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<DetailsLeaveTypeVM, LeaveType>().ReverseMap();
            CreateMap<CreateLeaveTypeVM, LeaveType>().ReverseMap();
            CreateMap<LeaveAllocationVM, LeaveAllocation>().ReverseMap();
            CreateMap<LeaveHIstoryVM, LeaveHistory>().ReverseMap();
            CreateMap<EmployeeVM, Employee>().ReverseMap();
        }

        
    }
}
