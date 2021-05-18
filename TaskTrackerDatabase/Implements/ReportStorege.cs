using System;
using System.Collections.Generic;
using System.Text;
using TaskTrackerBusinessLogic.Interfaces;
using TaskTrackerBusinessLogic.BindingModels;

using TaskTrackerBusinessLogic.ViewModels;

namespace TaskTrackerDatabase.Implements
{
    /*
    public class ReportStorege : IReportStorage
    {
        public List<ReportClientViewModel> GetClientInfoFiltered(ReportBindingModel model)
        {
            using (var context = new TaskTrackerContext())
            {
                
                var client = context.Client.Include(x => x.Contract).ThenInclude(x => x.Hotel)
                    .Include(x => x.Contract).ThenInclude(x => x.Route)
                    .FirstOrDefault(x => x.Clientid == model.ClientId);
                if (client == null)
                {
                    throw new Exception("Клиент не найден");
                }
                return context.Contract.Where(x => x.Datefromtravel.Date >= model.DateFrom.Value.Date
                && x.Datetotravel.Date <= model.DateTo.Value.Date).Select(ClientCreateModel).ToList();
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
    }*/
}
