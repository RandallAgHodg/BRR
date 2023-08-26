using BRR.Application.Abstractions.Authentication;
using BRR.Application.Abstractions.Messaging;
using BRR.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BRR.Application.Users.Commands;

public class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, string>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IJWTProvider _jwtProvider;

    public RegisterUserCommandHandler(UserManager<AppUser> userManager, IJWTProvider jwtProvider)
    {
        _userManager = userManager;
        _jwtProvider = jwtProvider;
    }

    public async Task<string> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var userDb = await _userManager.FindByEmailAsync(request.Email);

        var user = AppUser.Create(request.FirstName, request.SecondName,
                                request.LastName, request.SecondLastName
                                ,request.Email, request.Password, request.Age,
                                request.PhoneNumber, request.Gender);

        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
            return result.Errors.First()?.Description;

        var token = _jwtProvider.Create(user);

        return token;
    }
}
