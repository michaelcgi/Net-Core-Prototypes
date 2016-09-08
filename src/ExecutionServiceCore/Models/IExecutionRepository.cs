using ExecutionServiceCore.Models;
using System.Collections.Generic;

namespace ExecutionServiceCore.Models
{
    public interface IExecutionRepository
    {
        void Add(ExecutionJob item);
        IEnumerable<ExecutionJob> GetAll();
        ExecutionJob Find(int id);
        ExecutionJob Remove(int id);
        void Update(ExecutionJob item);
    }
}