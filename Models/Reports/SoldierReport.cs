namespace IntelligencePipeline.Models.Reports
{
    // Represents an intelligence report from a soldier in the field.
    public class SoldierReport : Report
    {
        private string _soldierName;
        private string _soldierID;
        private string _unit;
        private int _confidenceLevel;


        // Properties
        public string SoldierName { get => _soldierName; protected set { _soldierName = value; } }
        public string SoldierID { get => _soldierID; protected set { _soldierID = value; } }
        public string Unit { get => _unit; protected set { _unit = value; } }
        public int ConfidenceLevel { get => _confidenceLevel; protected set { _confidenceLevel = value; } }


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

            bool isContainSuspiciousWord = false;

            foreach (string suspiciousWord in suspiciousWords )
            {
                if (Description.Contains(suspiciousWord, StringComparison.OrdinalIgnoreCase))
                {
                    isContainSuspiciousWord = true;
                }

            }

            return isContainSuspiciousWord;
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
