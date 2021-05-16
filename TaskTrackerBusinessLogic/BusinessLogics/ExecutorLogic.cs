using System;
using System.Collections.Generic;
using System.Text;
using TaskTrackerBusinessLogic.BindingModels;
using TaskTrackerBusinessLogic.Interfaces;
using TaskTrackerBusinessLogic.ViewModels;

namespace TaskTrackerBusinessLogic.BusinessLogics
{
    public class ExecutorLogic
    {
        private readonly IExecutorStorage _executorStorage;

        public ExecutorLogic(IExecutorStorage executorStorage)
        {
            _executorStorage = executorStorage;
        }

        public List<ExecutorViewModel> Read(ExecutorBindingModel model)
        {
            if (model == null)
            {
                return _executorStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<ExecutorViewModel> { _executorStorage.GetElement(model) };
            }
            return _executorStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(ExecutorBindingModel model)
        {
            var element = _executorStorage.GetElement(new ExecutorBindingModel
            {
                Name = model.Name,
                Company=model.Company
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть исполнитель");
            }
            if (model.Id.HasValue)
            {
                _executorStorage.Update(model);
            }
            else
            {
                _executorStorage.Insert(model);
            }
        }
        public void Delete(ExecutorBindingModel model)
        {
            var element = _executorStorage.GetElement(new ExecutorBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Исполнитель не найден");
            }
            _executorStorage.Delete(model);
        }
    }
}
