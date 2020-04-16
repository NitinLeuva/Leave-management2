using LeaveManagement3.Contracts;
using LeaveManagement3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement3.Repository
{
    public class LeaveTypeRepository : ILeaveTypeRepository
    {
        private ApplicationDbContext _db;

        public LeaveTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(LeaveType entity)
        {
            _db.LeaveTypes.Add(entity);
            return Save();
        }

        public bool Delete(LeaveType entity)
        {
            _db.LeaveTypes.Remove(entity);
            return Save();
        }
        
        public ICollection<LeaveType> FindAll()
        {
          var leaveTypes = _db.LeaveTypes.ToList();
            return leaveTypes;
        }

        public LeaveType FindById(int id)
        {
            var leaveType = _db.LeaveTypes.Find(id);
            return leaveType;
        }

        public ICollection<LeaveType> GetEmployeesByLeaveType(int id)
        {
            throw new NotImplementedException();
        }

        public bool IsExists(int id)
        {
            var value =  _db.LeaveTypes.Any(q => q.Id == id);
            return value;
        }

        public bool Save()
        {
            var changes =_db.SaveChanges();
            return (changes > 0 ? true : false);
        }

        public bool Update(LeaveType entity)
        {
            _db.LeaveTypes.Update(entity);
            return Save();
        }
    }
}
