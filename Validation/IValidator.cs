using IntelligencePipeline.Models.Reports;
using System.ComponentModel.DataAnnotations;

namespace IntelligencePipeline.Validation
{
    // Defines the contract for report validation.
    public interface IValidator
    {
        ValidationResult Validate(Report report);
    }
}