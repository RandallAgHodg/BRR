﻿using BRR.Application.Abstractions.Messaging;
using BRR.Contracts.Users;

namespace BRR.Application.Users.Commands;

public sealed record RegisterUserCommand(
    string FirstName,
    string SecondName,
    string LastName,
    string SecondLastName,
    string Email,
    string Password,
    int Age,
    string PhoneNumber,
    string Gender,
    string Role
) : ICommand<AuthResponse>;