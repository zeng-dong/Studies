using EventSourcingTaskApp.Infrastructure;
using Microsoft.AspNetCore.Mvc;

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
    }
}
