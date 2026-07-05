namespace IntelligencePipeline.Validation
{
    // Encapsulates the result of a validation operation.
    public class ValidationResult
    {
        public bool IsValid { get; }
        public string ErrorMessage { get; }


        // Constructor
        public ValidationResult(bool isValid, string errorMessage)
        {
            IsValid = isValid;
            ErrorMessage = errorMessage;
        }


        //Methods
        public static ValidationResult Success() { return new ValidationResult(true,"");  }
        public static ValidationResult Failure(string errorMessage)
        {
            return new ValidationResult(false, errorMessage);
        }





    }
}
