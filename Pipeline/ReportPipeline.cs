using IntelligencePipeline.Calculators;
using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;
using IntelligencePipeline.Storage;
using IntelligencePipeline.Validation;
using IntelligencePipeline.Calculators;

namespace IntelligencePipeline.Pipeline
{
    // Orchestrates the complete report processing workflow.
    public class ReportPipeline
    {
        private ReportRepository _validatedReports;
        private RejectedReportRepository _rejectedReports;
        private int _nextReportId;


        // Constructor
        public ReportPipeline()
        {
            _validatedReports = new ReportRepository();
            _rejectedReports = new RejectedReportRepository();
            _nextReportId = 1;
        }

        //Methods
        public void ProcessReport(Report report)
        {
            if (report.Status == ReportStatus.New)
            {
                report.Status = ReportStatus.Validating;

                ValidateReport(report);

                if (report.Status == ReportStatus.Validated)
                {
                    report.ReliabilityScore = R
                }

            }
        }





        public ReportRepository GetValidatedReports()
        {
            ReportRepository reportRepository = 
        }
        //public RejectedReportRepository GetRejectedReports()
        //public void DisplayStatistics()

        // Private Methods

        // Returns IValidator suitable for any type
        private IValidator GetValidator(Report report)
        {
            if (report is DroneReport droneReport)
            {
                return new DroneValidator();
            }
            if (report is SoldierReport soldierReport)
            {
                return new SoldierValidator();
            }
            if (report is SignalReport signalReport)
            {
                return new SignalValidator();
            }
            if (report is RadarReport radarReport)
            {
                return new RadarValidator();
            }
            return null;
        }


        private void ValidateReport(Report report)
        {
            IValidator validator = GetValidator(report);

            ValidationResult validationResult = validator.Validate(report);

            if (!validationResult.IsValid)
            {
                report.Status = ReportStatus.Rejected;
                report.RejectionReason = validationResult.ErrorMessage;

            }
            if (validationResult.IsValid)
            {
                report.Status = ReportStatus.Validated;
            }

        }


        private void CalculateMetrics(Report report)
        {
            report.ReliabilityScore = ReliabilityCalculator.cco
        }
        private void StoreReport(Report report)
        {
            if (report.Status == ReportStatus.Rejected)
            {
                _rejectedReports.Add(report);
            }
            if (report.Status == ReportStatus.Validated)
            {
                _validatedReports.Add(report);
            }
        }




    }



}