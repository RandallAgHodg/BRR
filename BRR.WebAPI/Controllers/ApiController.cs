using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BRR.WebAPI.Controllers;

[ApiController]
public abstract class ApiController : ControllerBase
{
    protected IMediator Sender { get; }
    protected IMapper Mapper { get; }

    public ApiController(IMediator mediator, IMapper mapper)
    {
        Sender = mediator;
        Mapper = mapper;
    }
    
}
