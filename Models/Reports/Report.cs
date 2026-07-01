using IntelligencePipeline.Models.Enums;

namespace IntelligencePipeline.Models.Reports
{

    // Models the shared concept of an intelligence report regardless of source type.
    public abstract class Report
    {
        // todo: להכניס ערכים דיפולטיבים לשדות שמחושבים אח"כ
        private int _reportId;
        private DateTime _timestamp;
        private double _latitude;
        private double _longitude;
        private string _description;
        private ReportStatus _status;
        private Priority _priority;
        private Classification _classification;
        private int _reliabilityScore;
        private string _rejectionReason;


        // Properties
        public int ReportId { get => _reportId; protected set; }
        public DateTime Timestamp { get => _timestamp; protected set { _timestamp = value; } }
        public double Latitude { get => _latitude; protected set { _latitude = value; } }
        public double Longitude { get => _longitude; protected set { _longitude = value; } }
        public string Description { get => _description; protected set { _description = value; } }
        public ReportStatus Status { get => _status; set { _status = value; } }
        public Priority Priority { get => _priority; set { _priority = value; } }
        public Classification Classification { get => _classification; set { _classification = value; } }
        public int ReliabilityScore { get => _reliabilityScore; set { _reliabilityScore = value; } }
        public string RejectionReason { get => _rejectionReason; set { _rejectionReason = value; } }


        // Constructor
        protected Report(int reportId, DateTime timestamp, double latitude, double longitude, string description)
        {
            ReportId = reportId;
            Timestamp = timestamp;
            Latitude = latitude;
            Longitude = longitude;
            Description = description;
            Status = ReportStatus.New;

        }


        //Abstract Methods
        public abstract string GetSourceType();
        public abstract int CalculateReliabilityScore();


        //Virtual Methods
        // todo: לערוך
        public virtual string GetSummary()
        {
            return $"ReportId: {ReportId}|Time: {Timestamp}|Description: {Description}|";
                   

        }


        // Override Methods
        // todo: להסיר שדות שמחושבים אח"כ
        public override string ToString()
        {
            return $"ReportId: {ReportId}|Time: {Timestamp}|Latitude:{Latitude},Longitude:{Longitude}|Description: {Description}|" +
                  $"Report Status: {Status}|Priority: {Priority}|Classification: {Classification}|reliability Score: {ReliabilityScore}";

        }


    }

}