using leave_management.Contracts;
using leave_management.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Repository
{
    public class LeaveHistoryRepository : ILeaveHistoryRepository
    {
        private ApplicationDbContext _db;

        public LeaveHistoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(LeaveHistory entity)
        {
            _db.LeaveHistorys.Add(entity);
            return Save();
        }

        public bool Delete(LeaveHistory entity)
        {
            _db.LeaveHistorys.Remove(entity);
            return Save();
        }

        public ICollection<LeaveHistory> FindAll()
        {
            return _db.LeaveHistorys.ToList();
        }

        public LeaveHistory FindById(int id)
        {
            return _db.LeaveHistorys.Find(id);
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return (changes > 0 ? true : false);
        }

        public bool Update(LeaveHistory entity)
        {
            _db.LeaveHistorys.Update(entity);
            return Save();
        }
    }
}
