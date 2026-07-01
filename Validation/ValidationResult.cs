namespace IntelligencePipeline.Validation
{
    // Encapsulates the result of a validation operation.
    public class ValidationResult
    {
        private bool _isValid;
        private string _errorMessage;
    

        // Properties
        public bool IsValid { get => _isValid; }
        public string ErrorMessage { get => _errorMessage; }

        
        // Constructor
        public ValidationResult(bool isValid, string errorMessage)
        {
            _isValid = isValid;
            _errorMessage = errorMessage; 
        }


        //Methods
        public static ValidationResult Success() { return new ValidationResult(true,"");  }
        public static ValidationResult Failure(string errorMessage)
        {
            return new ValidationResult(false, errorMessage);
        }





    }
}
