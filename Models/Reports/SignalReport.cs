namespace IntelligencePipeline.Models.Reports
{
    // Represents an intelligence report from a signal intelligence system.
    public class RadarReport : Report
    {
        private int _speed;
        private int _direction;
        private int _distance;


        //// Properties
        //public int Speed { get => _speed; protected set { _speed = value; } }
        //public int Direction { get => _direction; protected set { _direction = value; } }
        //public int Distance { get => _distance; protected set { _distance = value; } }


        //// Constructor
        //public RadarReport(int reportId, DateTime timestamp, double latitude, double longitude,
        //                   string description, int speed, int direction, int distance)
        //                    : base(reportId, timestamp, latitude, longitude, description)
        //{
        //    Speed = speed;
        //    Direction = direction;
        //    Distance = distance;
        //}



        //// Override Methods
        //public override string GetSourceType() => "Radar";



        //// Calculate radar specific reliability
        //public override int CalculateReliabilityScore()
        //{
        //    const int BaseRadarReliabilityScore = 6;

        //    int reliabilityScore = BaseRadarReliabilityScore;

        //    if (Distance >= 500 && Distance <= 3000)
        //    {
        //        reliabilityScore += 2;
        //    }
        //    else if (Distance > 70000)
        //    {
        //        reliabilityScore -= 2;
        //    }

        //    if (Speed >= 10 && Speed <= 900)
        //    {
        //        reliabilityScore += 1;
        //    }
        //    else if (Speed > 1500)
        //    {
        //        reliabilityScore -= 2;
        //    }

        //    return reliabilityScore;
        //}


    }
}
