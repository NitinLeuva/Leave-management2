using LeaveManagement3.Contracts;
using LeaveManagement3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement3.Repository
{
    public class LeaveRequestRepository : ILeaveRequestRepository
    {
        private ApplicationDbContext _db;

        public LeaveRequestRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(LeaveRequest entity)
        {
            _db.LeaveRequests.Add(entity);
            return Save();
        }

        public bool Delete(LeaveRequest entity)
        {
            _db.LeaveRequests.Remove(entity);
            return Save();
        }

        public ICollection<LeaveRequest> FindAll()
        {
            return _db.LeaveRequests.ToList();
        }

        public LeaveRequest FindById(int id)
        {
            return _db.LeaveRequests.Find(id);
        }

        public bool IsExists(int id)
        {
            var value = _db.LeaveRequests.Any(q => q.Id == id);
            return value;
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return (changes > 0 ? true : false);
        }

        public bool Update(LeaveRequest entity)
        {
            _db.LeaveRequests.Update(entity);
            return Save();
        }
    }
}
