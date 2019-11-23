using Shared.Contracts;
using Shared.Domains;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Queue.App
{
    internal class Startup
    {
        private readonly IMediator mediator;

        public async Task<int> Begin()
        {
            await mediator.Push(DefaultEvent.Create(new Domains.Queue {
                
                }));
            return await Task.FromResult(1210);
        }

        public Startup(IMediator mediator)
        {
            this.mediator = mediator;
        }
    }
}
