using IntelligencePipeline.Models.Reports;


namespace IntelligencePipeline.Validation
{
    // Validates drone-specific report fields

    public class RadarValidator : BaseValidator
    {
        protected override ValidationResult ValidateSpecificFields(Report report)
        {
            if (report is not RadarReport radarReport)
                return ValidationResult.Failure("Report is not a radarReport");

            //if (!ValidateSoldierName(soldierReport, out string rejectionReason))
            //    return ValidationResult.Failure(rejectionReason);

            //if (!ValidateSoldierID(soldierReport, out rejectionReason))
            //    return ValidationResult.Failure(rejectionReason);

            //if (!ValidateUnit(soldierReport, out rejectionReason))
            //    return ValidationResult.Failure(rejectionReason);

            //if (!ValidateConfidenceLevel(soldierReport, out rejectionReason))
            //    return ValidationResult.Failure(rejectionReason);

            return ValidationResult.Success();

        }


        //Verification methods

        // SoldierName check
        

    }
}