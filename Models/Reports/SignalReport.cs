using IntelligencePipeline.Models.Enums;

namespace IntelligencePipeline.Models.Reports
{
    // Represents an intelligence report from a signal intelligence system.
    public class SignalReport : Report
    {
        public double Frequency { get; protected set; }
        public string Content { get; protected set; }
        public Language Language { get; protected set; }
        public int SignalStrength { get; protected set; }


        // Constructor
        public SignalReport(int reportId, DateTime timestamp, double latitude, double longitude, 
                            string description, double frequency, string content, Language language,
                            int signalStrength)
                            : base(reportId, timestamp, latitude, longitude, description)
        {
            Frequency = frequency;
            Content = content;
            Language = language;
            SignalStrength = signalStrength;
        }



        // Override Methods
        public override string GetSourceType() => "Signal";


        // Auxiliary functions
        public bool ContainSuspiciousWord()
        {
            if (string.IsNullOrWhiteSpace(Content))
            {
                return false;
            }

            string[] suspiciousWords = { "attack", "target", "border", "vehicle" };


            foreach (string suspiciousWord in suspiciousWords)
            {
                if (Content.Contains(suspiciousWord, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }

            }

            return false;
        }


        // Calculate Signal specific reliability
        public override int CalculateReliabilityScore()
        {
            const int BaseSignalReliabilityScore = 5;

            int reliabilityScore = BaseSignalReliabilityScore;

            // check SignalStrength
            if (SignalStrength >= -40)
            {
                reliabilityScore += 3;
            }
            else if (SignalStrength >= -70)
            {
                reliabilityScore += 2;
            }
            else if (SignalStrength < -100)
            {
                reliabilityScore -= 2;
            }


            // check suspicious word
            if (ContainSuspiciousWord())
            {
                reliabilityScore += 1;
            }
            

            return reliabilityScore;
        }


    }
}
