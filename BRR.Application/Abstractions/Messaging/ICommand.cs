using MediatR;

namespace BRR.Application.Abstractions.Messaging;

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}
