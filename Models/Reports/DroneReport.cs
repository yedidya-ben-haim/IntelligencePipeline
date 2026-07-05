namespace IntelligencePipeline.Models.Reports
{
    // Represents an intelligence report from a drone source
    public class DroneReport : Report
    {
        public int Altitude { get; protected set; }
        public int ImageQuality { get; protected set; }


        // Constructor
        public DroneReport(int reportId, DateTime timestamp, double latitude, double longitude,
                            string description, int altitude, int imageQuality)
                            : base(reportId, timestamp, latitude, longitude, description)
        {
            Altitude = altitude;
            ImageQuality = imageQuality;
        }

        // Override Methods
        public override string GetSourceType() => "Drone";


        // Calculate drone specific reliability
        public override int CalculateReliabilityScore()
        {
            int reliabilityScore = 5; // Base drone reliability score = 5

            if (ImageQuality >= 80)
            {
                reliabilityScore += 3;
            }
            else if (ImageQuality >= 50)
            { 
                reliabilityScore += 2; 
            }

            if (Altitude >= 500 && Altitude <= 3000) 
            {
                reliabilityScore += 2;
            }
            else if (Altitude > 7000)
            {
                reliabilityScore -= 2;
            }

            return reliabilityScore;
        }







    }
}

