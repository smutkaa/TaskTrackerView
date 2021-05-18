using System;
using System.Collections.Generic;
using System.Text;
using TaskTrackerBusinessLogic.BindingModels;
using TaskTrackerBusinessLogic.Interfaces;
using TaskTrackerBusinessLogic.ViewModels;

namespace TaskTrackerBusinessLogic.BusinessLogics
{
    public class ReportLogic
    {
        public readonly IReportStorage storage;

        public ReportLogic(IReportStorage report)
        {
            storage = report;
        }

        public List<ReportClientViewModel> GetClientInfoFiltered(ReportBindingModel model)
        {
            if (model == null)
                return null;
            if (!model.DateTo.HasValue || !model.DateFrom.HasValue)
                return null;
            return storage.GetClientInfoFiltered(model);

        }
    }
}
