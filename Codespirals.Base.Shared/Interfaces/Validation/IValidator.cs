using Codespirals.Base.Results;

namespace Codespirals.Base.Validation;

public interface IValidator<TValidationBuilder, TValidationResult, TErrorCode>
    where TValidationBuilder : IValidationBuilder<TValidationResult, TErrorCode>, new()
    where TValidationResult : IResult<TErrorCode>
{
    public TValidationBuilder BeginValidation<TAdditionalData>();
}
