namespace IntelligencePipeline.Models.Reports
{
    // Represents an intelligence report from a soldier in the field.
    public class SoldierReport : Report
    {
        public string SoldierName { get; protected set; }
        public string SoldierID { get; protected set; }
        public string Unit { get; protected set; }
        public int ConfidenceLevel { get; protected set; }


        // Constructor
        public SoldierReport(int reportId, DateTime timestamp, double latitude, double longitude, 
                            string description, string soldierName, string soldierID, string unit,
                            int confidenceLevel): base(reportId, timestamp, latitude, longitude, description)
        {
            SoldierName = soldierName;
            SoldierID = soldierID;
            Unit = unit;
            ConfidenceLevel = confidenceLevel;
        }



        // Override Methods
        public override string GetSourceType() => "Soldier";


        // Auxiliary functions
        public bool ContainSuspiciousWord()
        {
            string[] suspiciousWords = { "weapon", "vehicle", "movement", "explosion" };

            foreach (string suspiciousWord in suspiciousWords )
            {
                if (Description.Contains(suspiciousWord, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }

            }

            return false;
        }


        // Calculate soldier specific reliability
        public override int CalculateReliabilityScore()
        {
            int reliabilityScore = 4; // Base Soldier reliability score = 4

            reliabilityScore += ConfidenceLevel;

            if (ContainSuspiciousWord())
            {
                reliabilityScore += 1;
            }

            return reliabilityScore;
        }


    }
}
