using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline.Validation
{
    // Validates signal-specific report fields.
    public class SignalValidator : BaseValidator
    {
        protected override ValidationResult ValidateSpecificFields(Report report)
        {
            if (report is not SignalReport signalReport)
                { 
                return ValidationResult.Failure("Report is not a SignalReport"); 
            }

            if (!ValidateFrequency(signalReport, out string rejectionReason))
                { 
                return ValidationResult.Failure(rejectionReason); 
            }

            if (!ValidateContent(signalReport, out rejectionReason))
                { 
                return ValidationResult.Failure(rejectionReason); 
            }

            if (!ValidateLanguage(signalReport, out rejectionReason))
                { 
                return ValidationResult.Failure(rejectionReason); 
            }

            if (!ValidateSignalStrength(signalReport, out rejectionReason))
                { 
                return ValidationResult.Failure(rejectionReason); 
            }

            return ValidationResult.Success();
        }


        //Verification methods

        // Frequency check
        protected bool ValidateFrequency(SignalReport report, out string rejectionReason)
        {
            const double minFrequency = 1.0;
            const double maxFrequency = 3000;

            if (report.Frequency < minFrequency || report.Frequency > maxFrequency)
            {
                rejectionReason = "Invalid Frequency: must be between 1.0 and 3000";
                return false;
            }

            rejectionReason = "";
            return true;
        }

        // Content check
        protected bool ValidateContent(SignalReport report, out string rejectionReason)
        {
            const int minContentLength = 5;
            const int maxContentLength = 1000;

            if (string.IsNullOrWhiteSpace(report.Content))
            {
                rejectionReason = "Missing required field: Content";
                return false;
            }

            if (report.Content.Length < minContentLength || report.Content.Length > maxContentLength)
            {
                rejectionReason = "Invalid Content: must be between 5 and 1000";
                return false;
            }

            rejectionReason = "";
            return true;
        }

        // Language check
        protected bool ValidateLanguage(SignalReport report, out string rejectionReason)
        {
            if (!Enum.IsDefined<Language>(report.Language))
            {
                rejectionReason = "Invalid Language. Must be: Hebrew, Arabic, English, Russian, Other";
                return false;
            }

            rejectionReason = "";
            return true;
        }

        // SignalStrength check
        protected bool ValidateSignalStrength(SignalReport report, out string rejectionReason)
        {
            const int minSignalStrength = -120;
            const int maxSignalStrength = 0;

            if (report.SignalStrength < minSignalStrength || report.SignalStrength > maxSignalStrength)
            {
                rejectionReason = "Invalid SignalStrength: must be between - 120 and 0";
                return false;
            }

            rejectionReason = "";
            return true;
        }
    }
}