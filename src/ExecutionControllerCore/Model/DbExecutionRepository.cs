using System.Collections.Generic;
using System.Linq;
using ExecutionCore.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace ExecutionControllerCore.Model
{
    public class DbExecutionRepository : IExecutionRepository, IDisposable
    {
        private DatabaseContext _db;
        private object changesLock = new object();

        public DbExecutionRepository()
        {
            _db = new DatabaseContext();
        }
        public void Dispose()
        {
            _db.Dispose();
        }

        public void Add(ExecutionJob item)
        {
            lock (changesLock)
            {
                _db.ExecutionJobs.Add(item);
                _db.SaveChanges();
            }
        }

        public ExecutionJob Find(int id)
        {
            return _db.ExecutionJobs.Where(i => i.Id == id)
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
            lock (changesLock)
            {
                var changeTracking = _db.ExecutionJobs.Remove(i);
                _db.SaveChanges();
                return changeTracking.Entity;
            }
        }

        public void Update(ExecutionJob item)
        {
            lock (changesLock)
            {
                _db.SaveChanges();
            }
        }
    }
}
