using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BRR.Application.Users.Commands.RegisterUser;
using BRR.Application.Users.Commands.LoginUser;
using BRR.Contracts.Requests.Users;
using BRR.Application.Users.Queries.GetUserProfile;
using BRR.Application.Users.Commands.AddClient;
using BRR.WebAPI.Requests;
using BRR.WebAPI.Extensions;

namespace BRR.WebAPI.Controllers;

[ApiController]
[AllowAnonymous]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator) =>
        _mediator = mediator;
    

    [HttpPost("users/register/")]
    public async Task<IActionResult> Register([FromForm] RegisterRequest request)
    {
        var command = new RegisterUserCommand(request.FirstName, request.SecondName,
            request.LastName, request.SecondLastName,
            request.Email, request.Password,
            request.Age, request.PhoneNumber,
            request.Gender, request.Role, request.ProfilePicture.ToImageUploadParams());

        var result =  await _mediator.Send(command);
        
        return Ok(result);
    }

    [HttpPost("/users/login/")]
    public async Task<IActionResult> Login([FromBody] LoginUserRequest request)
    {
        var command = new LoginUserCommand(request.Email, request.Password);

        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpGet("/users/profile")]
    [Authorize]
    public async Task<IActionResult> GetProfile()
    {
        var query = new GetUserProfileQuery();

        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpPost("users/add-client")]
    [Authorize]
    public async Task<IActionResult> AddClient([FromQuery] int clientId)
    {
        var command = new RegisterClientCommand(clientId);

        var result = await _mediator.Send(command);

        return Ok(result);
    }

}
