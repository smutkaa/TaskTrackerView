using System;
using System.Collections.Generic;
using System.Text;
using TaskTrackerBusinessLogic.BindingModels;
using TaskTrackerBusinessLogic.ViewModels;

namespace TaskTrackerBusinessLogic.Interfaces
{
    public interface ITaskProjectStorage
    {
        List<TaskofprojectViewModel> GetFullList();

        List<TaskofprojectViewModel> GetFilteredList(TaskofprojectBindingModel model);

        TaskofprojectViewModel GetElement(TaskofprojectBindingModel model);

        void Insert(TaskofprojectBindingModel model);

        void Update(TaskofprojectBindingModel model);

        void Delete(TaskofprojectBindingModel model);
    }
}
