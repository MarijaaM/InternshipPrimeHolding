using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using System.Net;

namespace Server.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("/Error")]
        public IActionResult Error()
        {
            var exeptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = exeptionHandlerFeature?.Error;
            var result = new ObjectResult(exception?.Message ?? "Unknown exception occured")
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
            };
            if (exception is BadRequestException)
            {
                result.StatusCode = (int)HttpStatusCode.BadRequest;
            } 
            return result;
        }
    }
} 
