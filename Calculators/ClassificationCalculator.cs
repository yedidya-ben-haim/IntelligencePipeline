using System;
using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline.Calculators
{
    public class ClassificationCalculator
    {
        
        public Classification Calculate(Report report)
        {
            if (IsTopSecret(report)) {return Classification.TopSecret;}

            
            if (IsSecret(report)) {return Classification.Secret;}

            if (IsRestricted(report)) {return Classification.Restricted;}

            // default Classification.Unclassified
            return Classification.Unclassified;
        }

        private bool IsTopSecret(Report report)
        {
            if (report.Priority == Priority.Critical)
            {
                return true;
            }

            if (report is SignalReport signalReport && ContainsKeyword(signalReport.Content, "target", "attack", "missile"))
            {
                return true;
            }

            return false;
        }

        private bool IsSecret(Report report)
        {
            if (report.Priority == Priority.High)
            {
                return true;
            }

            if (report is SignalReport)
            {
                return true;
            }

            if (ContainsKeyword(report.Description, "weapon", "border"))
            {
                return true;
            }

            return false;
        }

        private bool IsRestricted(Report report)
        {
            if (report.Priority == Priority.Medium)
            {
                return true;
            }

            if (report is SoldierReport)
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