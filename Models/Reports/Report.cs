using IntelligencePipeline.Models.Enums;

namespace IntelligencePipeline.Models.Reports
{

    // Models the shared concept of an intelligence report regardless of source type.
    public abstract class Report
    {
        public int ReportId { get; protected set; }
        public DateTime Timestamp { get; protected set; }
        public double Latitude { get; protected set; }
        public double Longitude { get; protected set; }
        public string Description { get; protected set; }

        public ReportStatus Status { get; set; }
        public Priority Priority { get; set; }
        public Classification Classification { get; set; }
        public int ReliabilityScore { get; set; }
        public string RejectionReason { get; set; }



        // Constructor
        protected Report(int reportId, DateTime timestamp, double latitude, double longitude, string description)
        {
            ReportId = reportId;
            Timestamp = timestamp;
            Latitude = latitude;
            Longitude = longitude;
            Description = description;

            Status = ReportStatus.New;
            RejectionReason = "";
        }


        //Abstract Methods
        public abstract string GetSourceType();
        public abstract int CalculateReliabilityScore();


        //Virtual Methods

        public virtual string GetSummary()
        {
            return $"ReportId: {ReportId}|Time: {Timestamp}|Description: {Description}|";
        }


        // Override Methods

        public override string ToString()
        {
            string reportDetails =
                $"ReportId: {ReportId}\n" +
                $"Source Type: {GetSourceType()}\n" +
                $"Time: {Timestamp}\n" +
                $"Location: Latitude {Latitude}, Longitude {Longitude}\n" +
                $"Description: {Description}\n" +
                $"Status: {Status}\n" +
                $"Priority: {Priority}\n" +
                $"Classification: {Classification}\n" +
                $"Reliability Score: {ReliabilityScore}";

            if (Status == ReportStatus.Rejected)
            {
                reportDetails += $"\nRejection Reason: {RejectionReason}";
            }

            return reportDetails;
        }
    }

}