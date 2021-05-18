using System;
using System.Collections.Generic;
using System.Text;
using TaskTrackerBusinessLogic.BindingModels;
using TaskTrackerBusinessLogic.ViewModels;

namespace TaskTrackerBusinessLogic.Interfaces
{
    public interface IReportStorage
    {
        List<ReportClientViewModel> GetClientInfoFiltered(ReportBindingModel model);

    }
}
