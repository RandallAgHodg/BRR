using BRR.Application.Abstractions.Authentication;
using BRR.Application.Abstractions.Messaging;
using BRR.Application.Core.Exceptions.User;
using BRR.Application.Mapping;
using BRR.Contracts.Responses.Users;
using BRR.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BRR.Application.Users.Commands.LoginUser;

public sealed class LoginUserCommandHandler : ICommandHandler<LoginUserCommand, AuthResponse>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly IJWTProvider _jwtProvider;

    public LoginUserCommandHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IJWTProvider jwtProvider)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtProvider = jwtProvider;
    }

    public async Task<AuthResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var result = await _signInManager
            .PasswordSignInAsync(request.email, request.password,
            isPersistent: false, lockoutOnFailure: false);

        if (!result.Succeeded)
            throw new InvalidUserLoginException("Credenciales no validas");

        var user = await _userManager.FindByEmailAsync(request.email);

        string token = _jwtProvider.Create(user);

        var response = user.ToUserResponse();

        return new AuthResponse(token, response);
    }
}
