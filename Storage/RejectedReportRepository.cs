using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline.Storage
{
    // Stores and manages rejected reports separately.
    public class RejectedReportRepository
    {
        private List<Report> _rejectedReports;


        // Constructor
        public RejectedReportRepository()
        {
            _rejectedReports = new List<Report>();
        }


        // Methods
        public void Add(Report report) 
        {
            if (report.Status == ReportStatus.Rejected)
            {
                _rejectedReports.Add(report);
            }
        }

        public List<Report> GetAll() 
        {
            return _rejectedReports;
        }

        public int GetTotalCount() 
        {
            return _rejectedReports.Count; 
        }

        public List<Report> GetByReason(string reasonKeyword) 
        {
            List<Report> getByReasonList = new();

            if (string.IsNullOrWhiteSpace(reasonKeyword))
            {
                return getByReasonList;
            }

            foreach (Report report in _rejectedReports)
            {
                if (report.RejectionReason.Contains(reasonKeyword, StringComparison.OrdinalIgnoreCase))
                {
                    getByReasonList.Add(report);
                }
            }
            return getByReasonList;
        }
    }
}