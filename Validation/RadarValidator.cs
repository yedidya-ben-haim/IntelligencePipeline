using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline.Validation
{
    // Validates radar-specific report fields.
    public class RadarValidator : BaseValidator
    {
        protected override ValidationResult ValidateSpecificFields(Report report)
        {
            if (report is not RadarReport radarReport)
                return ValidationResult.Failure("Report is not a RadarReport");

            if (!ValidateSpeed(radarReport, out string rejectionReason))
                return ValidationResult.Failure(rejectionReason);

            if (!ValidateDirection(radarReport, out rejectionReason))
                return ValidationResult.Failure(rejectionReason);

            if (!ValidateDistance(radarReport, out rejectionReason))
                return ValidationResult.Failure(rejectionReason);

            return ValidationResult.Success();
        }




        //Verification methods

        // Speed check
        protected bool ValidateSpeed(RadarReport report, out string rejectionReason)
        {
            int minSpeed = 0;
            int maxSpeed = 2000;

            if (report.Speed < minSpeed || report.Speed > maxSpeed)
            {
                rejectionReason = "Invalid Speed: must be between 0 and 2000";
                return false;
            }

            rejectionReason = null;
            return true;
        }

        // Direction check
        protected bool ValidateDirection(RadarReport report, out string rejectionReason)
        {
            int minDirection = 0;
            int maxDirection = 360;

            if (report.Direction < minDirection || report.Direction > maxDirection)
            {
                rejectionReason = "Invalid Direction: must be between 0 and 360";
                return false;
            }

            rejectionReason = null;
            return true;
        }

        // Distance check
        protected bool ValidateDistance(RadarReport report, out string rejectionReason)
        {
            int minDistance = 100;
            int maxDistance = 100000;

            if (report.Distance < minDistance || report.Distance > maxDistance)
            {
                rejectionReason = "Invalid Distance: must be between 0 and 100000";
                return false;
            }

            rejectionReason = null;
            return true;
        }
    }
}