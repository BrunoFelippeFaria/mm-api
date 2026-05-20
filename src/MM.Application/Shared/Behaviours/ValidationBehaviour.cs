
using FluentValidation;

using Mediator;

namespace MM.Application.Shared.Behaviours;

public class ValidationBehaviour<TRequest, TResponse>(
    IEnumerable<IValidator<TRequest>> validators
)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IMessage
{
    private readonly IEnumerable<IValidator<TRequest>> _validators = validators;

    public async ValueTask<TResponse> Handle(TRequest message, MessageHandlerDelegate<TRequest, TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(message);

        var failures = _validators
            .Select(v => v.Validate(context))
            .SelectMany(r => r.Errors)
            .Where(r => r != null)
            .ToList();

        if (failures.Count != 0)
            throw new ValidationException(failures);

        return await next(message, cancellationToken);
    }
}