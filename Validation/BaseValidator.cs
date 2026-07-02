using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline.Validation
{

    // Provides common validation logic for all report types and eliminates code duplication.
    public abstract class BaseValidator: IValidator
    {

        public ValidationResult Validate(Report report)
        {
            ValidationResult commonValidation = ValidateCommonFields(report);
            
            if (!commonValidation.IsValid)
            {
                return commonValidation;
            }

            return ValidateSpecificFields(report);
        }


        protected ValidationResult ValidateCommonFields(Report report)
        {
            string rejectionReason;

            
            if (!ValidateTimestamp(report, out rejectionReason)) 
            { 
                return ValidationResult.Failure(rejectionReason); 
            }
            if (!ValidateLatitude(report, out rejectionReason)) 
            { 
                return ValidationResult.Failure(rejectionReason); 
            }
            if (!ValidateLongitude(report, out rejectionReason)) 
            { 
                return ValidationResult.Failure(rejectionReason); 
            }
            if (!ValidateDescription(report, out rejectionReason)) 
            { 
                return ValidationResult.Failure(rejectionReason); 
            }

            
            return ValidationResult.Success();
        }

        protected abstract ValidationResult ValidateSpecificFields(Report report);



        // Verification methods

        // Timestamp check
        protected bool ValidateTimestamp(Report report, out string rejectionReason)
        {
            DateTime currentTime = DateTime.Now;
            DateTime minTime = new DateTime(2020, 1, 1);

            if (report.Timestamp < minTime || report.Timestamp > currentTime)
            {
                rejectionReason = "Invalid Timestamp: must be between 2020-01-01 and current time";
                return false;
            }
            
            rejectionReason = null;
            return true;
        }


        // Latitude check
        protected bool ValidateLatitude(Report report, out string rejectionReason)
        {
            double minLatitude = 29.5000;
            double maxLatitude = 33.5000;
            

            if (report.Latitude < minLatitude || report.Latitude > maxLatitude)
            {
                rejectionReason = "Invalid Latitude: must be between 29.5000 and 33.5000";
                return false;
            }
            
            rejectionReason = null;
            return true;
        }


        // Longitude check
        protected bool ValidateLongitude(Report report, out string rejectionReason)
        {
            double minLongitude = 34.0000;
            double maxLongitude = 36.0000;
            

            if (report.Longitude < minLongitude || report.Longitude > maxLongitude)
            {
                rejectionReason = "Invalid Longitude: must be between 34.0000 and 36.0000";
                return false;
            }
            
            rejectionReason = null;
            return true;
        }


        // Description check
        protected bool ValidateDescription(Report report, out string rejectionReason)
        {
            int minDescriptionLength = 10;
            int maxDescriptionLength = 500;



            if (string.IsNullOrWhiteSpace(report.Description))
            {
                rejectionReason = "Missing required field: Description";
                return false;
            }
            if (report.Description.Length < minDescriptionLength || report.Description.Length > maxDescriptionLength)
            {
                rejectionReason = "Invalid Description: must be between 10 and 500 characters";
                return false;
            }

            rejectionReason = null;
            return true;
        }





    }
}