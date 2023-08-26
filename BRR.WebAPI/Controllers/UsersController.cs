using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BRR.Contracts.Users;
using BRR.Application.Users.Commands;

namespace BRR.WebAPI.Controllers;

[ApiController]
[AllowAnonymous]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("users/login/")]
    public async Task<IActionResult> Login([FromBody] UserRequest request)
    {
        var command = new RegisterUserCommand(request.FirstName, request.SecondName,
            request.LastName, request.SecondLastName,
            request.Email, request.Password,
            request.Age, request.PhoneNumber,
            request.Gender, request.Role);

        var result =  await _mediator.Send(command);
        
        return Ok(result);
    }
}
