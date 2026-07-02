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
            List<Report> rejectedReports = new();
        }


        // Methods
        // todo: לממש
        //public void Add(Report report) { }
        //public List<Report> GetAll() { return new List<Report> }
        //public int GetTotalCount() { return 1; }
        //public List<Report> GetByReason(string reasonKeyword) { return new List<Report>; }
    }
}