using ValidationResult = FluentValidation.Results.ValidationResult;

namespace EventModular.Shared.Extensions;
public static class ValidationExtensions
{
    public static string GetAllErrorsString(this ValidationResult result, string separator = " | ")
    {
        if (result == null)
            throw new ArgumentNullException(nameof(result));

        if (result.IsValid || result.Errors == null || !result.Errors.Any())
            return string.Empty;

        return string.Join(separator, result.Errors.Select(x => x.ErrorMessage));
    }
}
