using System;
using System.Collections.Generic;
using System.Text;
using TaskTrackerBusinessLogic.Interfaces;
using TaskTrackerBusinessLogic.BindingModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TaskTrackerBusinessLogic.ViewModels;

namespace TaskTrackerDatabase.Implements
{
 
    public class ReportStorege : IReportStorage
    {
        public List<ReportClientViewModel> GetClientInfoFiltered(ReportBindingModel model)
        {
            using (var context = new TaskTrackerContext())
            {
                
                
                return context.Project
                  
                 .Where(x => x.Deadline.Date <= model.DateTo.Value.Date)
                .Select(ClientCreateModel)
                .ToList();
            }
        }
        private ReportClientViewModel ClientCreateModel(Project project)
        {
            return new ReportClientViewModel
            {
                Name = project.Name,
                Price = project.Price,
                Deadline = project.Deadline
            };
        }
    }
}
