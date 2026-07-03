using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;
using System;

namespace IntelligencePipeline.Calculators
{
    public class PriorityCalculator
    {
        // Calculates report priority based on business rules.
        public Priority Calculate(Report report)
        {
            if (IsCritical(report)) { return Priority.Critical; }

            if (IsHigh(report)) { return Priority.High; }

            if (IsMedium(report)) {return Priority.Medium;}

            // default Priority.Low
            return Priority.Low;
        }

        private bool IsCritical(Report report)
        {
            if (ContainsKeyword(report.Description, "missile", "explosion", "attack", "fire"))
            {
                return true;
            }

            if (report is RadarReport radarReport && radarReport.Speed <= 800)
            {
                return true;
            }

            if (report is SignalReport signalReport &&
                signalReport.Content.Contains("attack", StringComparison.OrdinalIgnoreCase) &&
                signalReport.Content.Contains("target", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return false;
        }

        private bool IsHigh(Report report)
        {
            if (ContainsKeyword(report.Description, "weapon", "suspicious", "border"))
            {
                return true;
            }

            if (report is DroneReport droneReport && droneReport.Altitude > 500)
            {
                return true;
            }

            if (report is RadarReport radarReport && radarReport.Speed <= 400)
            {
                return true;
            }

            if (report is SoldierReport soldierReport &&
                soldierReport.ConfidenceLevel < 4 &&
                soldierReport.Description.Contains("movement", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return false;
        }

        private bool IsMedium(Report report)
        {
            if (ContainsKeyword(report.Description, "movement", "vehicle", "activity"))
            {
                return true;
            }

            if (report is RadarReport radarReport && radarReport.Speed <= 120)
            {
                return true;
            }

            if (report.ReliabilityScore >= 7)
            {
                return true;
            }

            return false;
        }

        private bool ContainsKeyword(string text, params string[] keywords)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return false;
            }

            foreach (string keyword in keywords)
            {
                if (text.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
    }
}