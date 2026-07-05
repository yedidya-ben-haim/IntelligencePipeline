using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline.Validation
{
    // Defines the contract for report validation.
    public interface IValidator
    {
        ValidationResult Validate(Report report);
    }
}