using AutoMapper;
using BRR.Application.Auth.Login;
using BRR.Application.Auth.Register;
using BRR.Contracts.Requests.Users;
using BRR.WebAPI.Extensions;
using BRR.WebAPI.Mapping;
using BRR.WebAPI.Requests;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BRR.WebAPI.Controllers;

public class AuthController : ApiController
{
    public AuthController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    [HttpPost(ApiRoutes.Auth.RegisterAgent)]
    public async Task<IActionResult> RegisterAgent([FromForm] RegisterRequest request)
    {
        var command = request.ToCommand();

        var result = await Sender.Send(command);

        return Ok(result);
    }

    [HttpPost(ApiRoutes.Auth.Login)]
    public async Task<IActionResult> Login([FromBody] LoginUserRequest request)
    {
        var command = request.Adapt<LoginCommand>();

        var result = await Sender.Send(command);

        return Ok(result);
    }
}
