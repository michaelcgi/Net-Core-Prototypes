using ExecutionCore.Model;
using System.Collections.Generic;

namespace ExecutionCore.Model
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