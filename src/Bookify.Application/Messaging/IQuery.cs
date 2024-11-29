using Bookify.Domain.Abstractions;
using MediatR;

namespace Bookify.Application.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{

}
