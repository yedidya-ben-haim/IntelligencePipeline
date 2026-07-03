using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline.Calculators
{
    // Centralized location for reliability score calculation logic.
    public class ReliabilityCalculator
    {
        public int Calculate(Report report)
        {
            int maxreliabilityScore = 10;
            int minreliabilityScore = 1;

            int reliabilityScore = report.CalculateReliabilityScore();

            if (reliabilityScore > maxreliabilityScore) reliabilityScore = maxreliabilityScore;
            if (reliabilityScore < minreliabilityScore) reliabilityScore = minreliabilityScore;

            return reliabilityScore;
        }
    }
}