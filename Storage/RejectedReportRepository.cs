using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline.Storage
{
    // Stores and manages rejected reports separately.
    class RejectedReportRepository
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
            _rejectedReports.Add(report);
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