using IntelligencePipeline.Models.Reports;


namespace IntelligencePipeline.Validation
{
    // Validates soldier-specific report fields.
    public class SoldierValidator : BaseValidator
    {
        protected override ValidationResult ValidateSpecificFields(Report report)
        {
            if (report is not SoldierReport soldierReport)
                return ValidationResult.Failure("Report is not a soldierReport");

            if (!ValidateSoldierName(soldierReport, out string rejectionReason))
                return ValidationResult.Failure(rejectionReason);

            if (!ValidateSoldierID(soldierReport, out rejectionReason))
                return ValidationResult.Failure(rejectionReason);
            
            if (!ValidateUnit(soldierReport, out rejectionReason))
                return ValidationResult.Failure(rejectionReason);
            
            if (!ValidateConfidenceLevel(soldierReport, out rejectionReason))
                return ValidationResult.Failure(rejectionReason);

            return ValidationResult.Success();

        }


        // Verification methods

        // SoldierName check
        protected bool ValidateSoldierName(SoldierReport report, out string rejectionReason)
        {
            const int minSoldierName = 2;
            const int maxSoldierName = 50;

            if (string.IsNullOrWhiteSpace(report.SoldierName))
            {
                rejectionReason = "Missing required field: SoldierName";
                return false;
            }

            if (report.SoldierName.Length < minSoldierName || report.SoldierName.Length > maxSoldierName)
            {
                rejectionReason = "Invalid SoldierName: must be between 2 and 50";
                return false;
            }

            rejectionReason = "";
            return true;
        }

        // SoldierID check
        protected bool ValidateSoldierID(SoldierReport report, out string rejectionReason)
        {
            if (string.IsNullOrWhiteSpace(report.SoldierID))
            {
                rejectionReason = "Missing required field: SoldierID";
                return false;
            }

            // SoldierID not null or empty
            const int properSoldierId = 7;
            

            if (report.SoldierID.Length != properSoldierId)
            {
                rejectionReason = "Invalid SoldierID: must contain exactly 7 digits";
                return false;
            }
            foreach (char digit in report.SoldierID)
            {
                if (!char.IsDigit(digit))
                {
                    rejectionReason = "Invalid SoldierID: must contain only digits";
                    return false;
                }
            }

            rejectionReason = "";
            return true;
        }

        // Unit check
        protected bool ValidateUnit(SoldierReport report, out string rejectionReason)
        {
            const int minUnitname = 2;
            const int maxUnitName = 50;

            if (string.IsNullOrWhiteSpace(report.Unit))
            {
                rejectionReason = "Missing required field: Unit";
                return false;
            }

            if (report.Unit.Length < minUnitname || report.Unit.Length > maxUnitName)
            {
                rejectionReason = "Invalid Unit: must be between 2 and 50";
                return false;
            }

            rejectionReason = "";
            return true;
        }

        // ConfidenceLevel check
        protected bool ValidateConfidenceLevel(SoldierReport report, out string rejectionReason)
        {
            const int minConfidenceLevel = 1;
            const int maxConfidenceLevel = 5;

            if (report.ConfidenceLevel > maxConfidenceLevel || report.ConfidenceLevel < minConfidenceLevel)
            {
                rejectionReason = "Invalid ConfidenceLevel: must be between 1 and 5";
                return false;
            }

            rejectionReason = "";
            return true;
        }
 
    }
}