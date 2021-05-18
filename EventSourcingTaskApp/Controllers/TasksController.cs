using EventSourcingTaskApp.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EventSourcingTaskApp.Controllers
{
    [Route("api/tasks/{id}")]
    [ApiController]
    [Consumes("application/x-www-form-urlencoded")]
    public class TasksController : ControllerBase
    {
        private readonly AggregateRepository _aggregateRepository;

        public TasksController(AggregateRepository aggregateRepository)
        {
            _aggregateRepository = aggregateRepository;
        }

        [HttpPost, Route("create")]
        public async Task<IActionResult> Create(Guid id, [FromForm] string title)
        {
            var aggregate = await _aggregateRepository.LoadAsync<Core.Task>(id);
            aggregate.Create(id, title, "Fresh Bite");

            await _aggregateRepository.SaveAsync(aggregate);

            return Ok();
        }

        [HttpPatch, Route("assign")]
        public async Task<IActionResult> Assign(Guid id, [FromForm] string assignedTo)
        {
            var aggregate = await _aggregateRepository.LoadAsync<Core.Task>(id);
            aggregate.Assign(assignedTo, "Fresh Bite");

            await _aggregateRepository.SaveAsync(aggregate);

            return Ok();
        }
    }
}
