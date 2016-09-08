using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExecutionServiceCore.Models
{
    public class DictionaryExecutionRepository : IExecutionRepository
    {
        private static ConcurrentDictionary<int, ExecutionJob> _executions =
              new ConcurrentDictionary<int, ExecutionJob>();

        public DictionaryExecutionRepository()
        {
        }

        public IEnumerable<ExecutionJob> GetAll()
        {
            return _executions.Values;
        }

        public void Add(ExecutionJob item)
        {
            item.Id = _executions.Count;
            _executions[item.Id] = item;
        }

        public ExecutionJob Find(int id)
        {
            ExecutionJob item;
            _executions.TryGetValue(id, out item);
            return item;
        }

        public ExecutionJob Remove(int id)
        {
            ExecutionJob item;
            _executions.TryRemove(id, out item);
            return item;
        }

        public void Update(ExecutionJob item)
        {
            _executions[item.Id] = item;
        }
    }
}

