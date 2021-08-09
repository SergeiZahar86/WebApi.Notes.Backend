using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Security.Claims;

namespace Notes.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class BaseController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator
        {
            get
            {
                return _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
            }
        }

        internal Guid UserIdBase
        {
            get
            {
                return User.Identity.IsAuthenticated
                    ? Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value)
                    : Guid.Empty;
            }
        }
    }
}
