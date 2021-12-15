using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Controllers
{

    [ApiController]
    public class BaseController : ControllerBase
    {
        private IMediator mediator;
        private IMapper mapper;
        protected IMediator _mediator => mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        protected IMapper _mapper => mapper ??= HttpContext.RequestServices.GetService<IMapper>();
    }
}
