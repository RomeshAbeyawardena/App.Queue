using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shared.Contracts;
using Shared.Services.Attributes;
using System.Threading.Tasks;

namespace App.Queue.WebApi.Controllers
{
    [BadRequestOnInvalidModelState]
    public abstract class ControllerBase : Controller
    {
        protected TService GetRequiredService<TService>() => HttpContext.RequestServices.GetRequiredService<TService>();
        
        protected ControllerBase()
        {

        }
    }
}