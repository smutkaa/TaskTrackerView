using System;
using System.Collections.Generic;
using System.Text;
using TaskTrackerBusinessLogic.BindingModels;
using TaskTrackerBusinessLogic.ViewModels;

namespace TaskTrackerBusinessLogic.Interfaces
{
    public interface IExecutorStorage
    {
        List<ExecutorViewModel> GetFullList();
        List<ExecutorViewModel> GetFilteredList(ExecutorBindingModel model);
        ExecutorViewModel GetElement(ExecutorBindingModel model);
        void Insert(ExecutorBindingModel model);
        void Update(ExecutorBindingModel model);
        void Delete(ExecutorBindingModel model);
    }
}
