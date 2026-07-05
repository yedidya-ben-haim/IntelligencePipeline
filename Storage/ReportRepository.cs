using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;


namespace IntelligencePipeline.Storage
{
    // Stores and manages validated reports.
    public class ReportRepository
    {
        private List<Report> _reports;

         
        // Constructor
        public ReportRepository()
        {
            _reports = new List<Report>();
        }


        //Methods
        public void Add(Report report)
        {
            _reports.Add(report);
        }

        public List<Report> GetAll()
        {
            return _reports;
        }

        public List<Report> GetByStatus(ReportStatus status)
        {
            List<Report> byStatusList = new();

            foreach (Report report in _reports)
            {
                if (report.Status == status)
                {
                    byStatusList.Add(report);
                }
            }

            return byStatusList;
        }

        public List<Report> GetByPriority(Priority priority)
        {
            List<Report> byPriorityList = new();

            foreach (Report report in _reports)
            {
                if (report.Priority == priority)
                {
                    byPriorityList.Add(report);
                }
            }

            return byPriorityList;
        }


        public List<Report> Search(string keyword)
        {
            List<Report> searchByKeywordList = new();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                return searchByKeywordList;
            }

            foreach (Report report in _reports)
            {
                if (report.Description.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                {
                    searchByKeywordList.Add(report);
                }
            }

            return searchByKeywordList;
        }

        public Report? GetById(int reportId)
        {
            foreach (Report report in _reports)
            {
                if (report.ReportId == reportId)
                {
                    return report;
                }

            }
            return null;
        }

        public void UpdateStatus(int reportId, ReportStatus newStatus)
        {
            if (newStatus != ReportStatus.InProgress && newStatus != ReportStatus.Completed)
            {
                return;
            }

            Report? reportToUpdate = GetById(reportId);
            
            if (reportToUpdate != null)
            {
                reportToUpdate.Status = newStatus;
            }
        }

        public int GetTotalCount()
        {
            return _reports.Count;
        }

        public int GetCountByStatus(ReportStatus status)
        {
            List<Report> byStatusList = GetByStatus(status);

            return byStatusList.Count;
        }

    }
}