using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline.Validation
{

    // Provides common validation logic for all report types and eliminates code duplication.
    public abstract class BaseValidator: IValidator
    {
        //Methods
        public ValidationResult Validate(Report report)
        {

        }

        protected ValidationResult ValidateCommonFields(Report report)
        {

        }

        protected abstract ValidationResult ValidateSpecificFields(Report report){ }








    }
}