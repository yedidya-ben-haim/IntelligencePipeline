using IntelligencePipeline.Models.Reports;


namespace IntelligencePipeline.Validation
{
    // Validates drone-specific report fields.

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
            int minSoldierName = 2;
            int maxSoldierName = 50;

            if (report.SoldierName.Length < minSoldierName || report.SoldierName.Length > maxSoldierName)
            {
                rejectionReason = "Invalid SoldierName: must be between 2 and 50";
                return false;
            }

            rejectionReason = null;
            return true;
        }

        // SoldierID check
        protected bool ValidateSoldierID(SoldierReport report, out string rejectionReason)
        {
            int properSoldierId = 7;
            

            if (report.SoldierID.Length != properSoldierId)
            {
                rejectionReason = "Invalid SoldierID: must be between 7 digits";
                return false;
            }
            if (!int.TryParse(report.SoldierID, out int result))
            {
                rejectionReason = "Invalid SoldierID. Must be: digits";
                return false;
            }

            rejectionReason = null;
            return true;
        }

        // Unit check
        protected bool ValidateUnit(SoldierReport report, out string rejectionReason)
        {
            int minUnitname = 2;
            int maxUnitName = 50;

            if (report.Unit.Length < minUnitname || report.Unit.Length > maxUnitName)
            {
                rejectionReason = "Invalid Unit: must be between 2 and 50";
                return false;
            }

            rejectionReason = null;
            return true;
        }

        // ConfidenceLevel check
        protected bool ValidateConfidenceLevel(SoldierReport report, out string rejectionReason)
        {
            int minConfidenceLevel = 1;
            int maxConfidenceLevel = 5;

            if (report.ConfidenceLevel > 1 || report.ConfidenceLevel < 5)
            {
                rejectionReason = "Invalid ConfidenceLevel: must be between 1 and 5";
                return false;
            }

            rejectionReason = null;
            return true;
        }

    }
}