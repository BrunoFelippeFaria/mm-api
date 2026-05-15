
using Mediator;

using MM.Application.Shared.Interfaces;

namespace MM.Application.Shared.Behaviours;

public class TranslacionalBehaviour<TRequest, TResponse> (
    IUnityOfWork uow
)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IMessage
{
    private readonly IUnityOfWork _uow = uow;

    public async ValueTask<TResponse> Handle(TRequest message, MessageHandlerDelegate<TRequest, TResponse> next, CancellationToken cancellationToken)
    {
        if (message is not ITranslacionalRequest)
            return await next(message, cancellationToken);

        var response = await next(message, cancellationToken);

        await _uow.CommitAsync();

        return response;
    }
}