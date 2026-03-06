using Codespirals.Base.Results;
namespace Codespirals.Base.Validation;

public interface IValidationBuilder<TValidationResult, TErrorCode>
    where TValidationResult : IResult<TErrorCode>
{
    public TValidationResult Validate();
}

public interface IValidationBuilderAsync<TValidationResult, TErrorCode>
    where TValidationResult : IResult<TErrorCode>
{
    public Task<TValidationResult> Validate();
}