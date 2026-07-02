using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline.Validation
{
    // Validates drone-specific report fields.
    public class DroneValidator : BaseValidator
    {
        protected override ValidationResult ValidateSpecificFields(Report report)
        {
            if (report is not DroneReport droneReport)
                return ValidationResult.Failure("Report is not a DroneReport");

            if (!ValidateAltitude(droneReport, out string rejectionReason))
                return ValidationResult.Failure(rejectionReason);

            if (!ValidateImageQuality(droneReport, out rejectionReason))
                return ValidationResult.Failure(rejectionReason);

            return ValidationResult.Success();
        }

        // Verification methods

        // Altitude check
        protected bool ValidateAltitude(DroneReport report, out string rejectionReason)
        {
            int minAltitude = 100;
            int maxAltitude = 10000;

            if (report.Altitude < minAltitude || report.Altitude > maxAltitude)
            {
                rejectionReason = "Invalid Altitude: must be between 100 and 10000";
                return false;
            }

            rejectionReason = null;
            return true;
        }

        // ImageQuality check
        protected bool ValidateImageQuality(DroneReport report, out string rejectionReason)
        {
            if (report.ImageQuality < 1 || report.ImageQuality > 100)
            {
                rejectionReason = "Invalid Image Quality: must be between 1 and 100";
                return false;
            }

            rejectionReason = null;
            return true;
        }
    }
}