using System;
using System.Collections.Generic;
using System.Text;
using TaskTrackerBusinessLogic.BindingModels;
using TaskTrackerBusinessLogic.ViewModels;

namespace TaskTrackerBusinessLogic.Interfaces
{
    public interface IProjectStorage
    {
        List<ProjectViewModel> GetFullList();

        List<ProjectViewModel> GetFilteredList(ProjectBindingModel model);

        ProjectViewModel GetElement(ProjectBindingModel model);

        void Insert(ProjectBindingModel model);

        void Update(ProjectBindingModel model);

        void Delete(ProjectBindingModel model);
    }
}
