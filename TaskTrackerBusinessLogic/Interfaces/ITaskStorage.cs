using System;
using System.Collections.Generic;
using System.Text;
using TaskTrackerBusinessLogic.BindingModels;
using TaskTrackerBusinessLogic.ViewModels;

namespace TaskTrackerBusinessLogic.Interfaces
{
    public interface ITaskStorage
    {
        List<TaskViewModel> GetFullList();
        List<TaskViewModel> GetFilteredList(TaskBindingModel model);
        TaskViewModel GetElement(TaskBindingModel model);
        void Insert(TaskBindingModel model);
        void Update(TaskBindingModel model);
        void Delete(TaskBindingModel model);
    }
}
