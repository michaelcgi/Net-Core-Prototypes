using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProgramWrapperCore;
using ExecutionServiceCore.Models;

namespace ExecutionServiceCore.Controllers
{
    [Route("api/[controller]")]
    public class ExecutionsController : Controller
    {
        private IExecutionRepository _repository;

        public ExecutionsController(IExecutionRepository repository)
        {
            _repository = repository;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<ExecutionJob> GetAll()
        {
            return _repository.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetExecution")]
        public IActionResult GetById(int id)
        {
            var execution = _repository.Find(id);
            if (execution == null)
            {
                return NotFound();
            }
            return new ObjectResult(execution);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Create([FromBody] ExecutionJob executionJob)
        {
            if (executionJob == null)
            {
                return BadRequest();
            }

            _repository.Add(executionJob);

            var programWrapper = new ProgramWrapper();
            var task = programWrapper.Execute(executionJob.Request);
            task.Wait();
            executionJob.Result = task.Result;

            executionJob.Status = ExecutionStatus.Finished;

            return CreatedAtRoute("GetExecution", new { id = executionJob.Id }, executionJob);
        }
    }
}
