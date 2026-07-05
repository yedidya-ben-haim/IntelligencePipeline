using IntelligencePipeline.Calculators;
using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;
using IntelligencePipeline.Storage;
using IntelligencePipeline.Validation;

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
            if (report == null)
            {
                return;
            }

            if (report.Status == ReportStatus.New)
            {
                report.Status = ReportStatus.Validating;

                ValidateReport(report);

                if (report.Status == ReportStatus.Validated)
                {
                    CalculateMetrics(report);
                }

                StoreReport(report);

            }
        }





        public ReportRepository GetValidatedReports()
        {
            return _validatedReports;
        }

        public RejectedReportRepository GetRejectedReports()
        {
            return _rejectedReports;
        }

        //public void DisplayStatistics()
        // todo: to complite



        // Private Methods

        // Returns IValidator suitable for any type
        private IValidator? GetValidator(Report report)
        {
            if (report is DroneReport)
            {
                return new DroneValidator();
            }
            else if (report is SoldierReport)
            {
                return new SoldierValidator();
            }
            else if (report is SignalReport)
            {
                return new SignalValidator();
            }
            else if (report is RadarReport)
            {
                return new RadarValidator();
            }

            return null;
        }

        private void ValidateReport(Report report)
        {
            IValidator validator = GetValidator(report);

            if (validator == null)
            {
                report.Status = ReportStatus.Rejected;
                report.RejectionReason = "Unsupported report type";
                return;
            }

            ValidationResult validationResult = validator.Validate(report);

            if (!validationResult.IsValid)
            {
                report.Status = ReportStatus.Rejected;
                report.RejectionReason = validationResult.ErrorMessage;
                return;
            }

            report.Status = ReportStatus.Validated;
        }

        private void CalculateMetrics(Report report)
        {
            report.ReliabilityScore = new ReliabilityCalculator().Calculate(report);
            report.Priority = new PriorityCalculator().Calculate(report);
            report.Classification = new ClassificationCalculator().Calculate(report);
        }

        private void StoreReport(Report report)
        {
            if (report.Status == ReportStatus.Rejected)
            {
                _rejectedReports.Add(report);
            }
            else if (report.Status == ReportStatus.Validated)
            {
                _validatedReports.Add(report);
            }
        }




    }



}