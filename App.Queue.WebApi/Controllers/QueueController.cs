using App.Queue.Domains.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Shared.Contracts;
using Shared.Services.Extensions;
using System.Threading.Tasks;

namespace App.Queue.WebApi
{
    public class QueueController : ControllerBase
    {
        private readonly IMediator _mediator;

        public QueueController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> CreateQueue(QueueViewModel queue)
        {
            var newQueue = await _mediator.Push(queue);
            
            return Ok(newQueue);
        }
    }
}