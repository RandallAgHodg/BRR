using BRR.Domain.Entities;

namespace BRR.Application.Abstractions.Authentication;

public interface IJWTProvider
{
    string Create(AppUser user);
}
