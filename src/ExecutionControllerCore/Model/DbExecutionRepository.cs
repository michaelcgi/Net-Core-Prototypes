using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExecutionCore.Model;
using ExecutionControllerCore.Model;
using Microsoft.EntityFrameworkCore;

namespace ExecutionControllerCore.Model
{
    public class DbExecutionRepository : IExecutionRepository
    {
        private DatabaseContext _db;

        public DbExecutionRepository()
        {
            _db = new DatabaseContext();
        }

        public void Add(ExecutionJob item)
        {
            _db.ExecutionJobs.Add(item);
            _db.SaveChanges();
        }

        public ExecutionJob Find(int id)
        {
            var query = _db.ExecutionJobs.Where(i => i.Id == id);

            return query
                .Include(ej => ej.Requests)
                .Include(ej => ej.Results)
                .First();
        }

        public IEnumerable<ExecutionJob> FindByStatus(ExecutionStatus status)
        {
            return _db.ExecutionJobs.Where(i => i.Status == status)
                .Include(ej => ej.Requests)
                .Include(ej => ej.Results)
                .ToList();
        }

        public IEnumerable<ExecutionJob> GetAll()
        {
            return _db.ExecutionJobs
                .Include(ej => ej.Requests)
                .Include(ej => ej.Results)
                .ToList();
        }

        public ExecutionJob Remove(int id)
        {
            var i = Find(id);
            var changeTracking = _db.ExecutionJobs.Remove(i);
            _db.SaveChanges();
            return changeTracking.Entity;
        }

        public void Update(ExecutionJob item)
        {
            _db.SaveChanges();
        }
    }
}
