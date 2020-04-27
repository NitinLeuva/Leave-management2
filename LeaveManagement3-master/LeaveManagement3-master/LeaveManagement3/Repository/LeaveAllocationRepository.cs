﻿using LeaveManagement3.Contracts;
using LeaveManagement3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement3.Repository
{
    public class LeaveAllocationRepository : ILeaveAllocationRepository
    {

        private ApplicationDbContext _db;

        public LeaveAllocationRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool CheckLeaveAllocation(int LeaveTypeId, string EmployeeID)
        {
            var period = DateTime.Now.Year;
            return FindAll().Where(q => q.EmployeeId == EmployeeID && q.LeaveTypeId == LeaveTypeId && q.Period == period).Any();
                } 

        public bool Create(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Add(entity);
            return Save();
        }

        public bool Delete(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Remove(entity);
            return Save();
        }

        public ICollection<LeaveAllocation> FindAll()
        {
            return _db.LeaveAllocations.ToList();
        }

        public LeaveAllocation FindById(int id)
        {
            return _db.LeaveAllocations.Find(id);
        }

        public bool IsExists(int id)
        {
            var value = _db.LeaveAllocations.Any(q => q.Id == id);
            return value;
        }
        public bool Save()
        {
            var changes = _db.SaveChanges();
            return (changes > 0 ? true : false);
        }
        public bool Update(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Update(entity);
            return Save();
        }
    }
}
