using FluentValidation;
using MediatR;

namespace MedicalChecker.Core.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        #region Fileds
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        #endregion

        #region Constructor
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        #endregion  

        #region Handel Functions
        #endregion  
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResult = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResult.SelectMany(r => r.Errors).Where(f => f != null).ToList();
                if (failures.Any())
                {
                    var message = failures.Select(f => f.PropertyName + " : " + f.ErrorMessage).FirstOrDefault();
                    throw new ValidationException(message);
                }
            }
            return await next();
        }
    }
}
