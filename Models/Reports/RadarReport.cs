namespace IntelligencePipeline.Models.Reports
{
    // Represents an intelligence report from a radar system.
    public class RadarReport : Report
    {
        public int Speed { get; protected set; }
        public int Direction { get; protected set; }
        public int Distance { get; protected set; }


        // Constructor
        public RadarReport(int reportId, DateTime timestamp, double latitude, double longitude, 
                           string description, int speed, int direction, int distance)
                            : base(reportId, timestamp, latitude, longitude, description)
        {
            Speed = speed;
            Direction = direction;
            Distance = distance;
        }



        // Override Methods
        public override string GetSourceType() => "Radar";



        // Calculate radar specific reliability
        public override int CalculateReliabilityScore()
        {
            const int BaseRadarReliabilityScore = 6;

            int reliabilityScore = BaseRadarReliabilityScore;

            if (Distance >= 500 && Distance <= 30000)
            {
                reliabilityScore += 2;
            }
            else if (Distance > 70000)
            {
                reliabilityScore -= 2;
            }

            if (Speed >= 10 && Speed <= 900)
            {
                reliabilityScore += 1;
            }
            else if (Speed > 1500)
            {
                reliabilityScore -= 2;
            }

            return reliabilityScore;
        }


    }
}
