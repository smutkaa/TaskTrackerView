using System;
using System.Collections.Generic;
using System.Text;
using TaskTrackerBusinessLogic.BindingModels;
using TaskTrackerBusinessLogic.Interfaces;
using TaskTrackerBusinessLogic.ViewModels;

namespace TaskTrackerBusinessLogic.BusinessLogics
{
    public class TaskofprojectLogic
    {
        private readonly ITaskProjectStorage _taskProjectStorage;

        public TaskofprojectLogic(ITaskProjectStorage taskProjectStorage)
        {
            _taskProjectStorage = taskProjectStorage;
        }
        public List<TaskofprojectViewModel> Read(TaskofprojectBindingModel model)
        {
            if (model == null)
            {
                return _taskProjectStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<TaskofprojectViewModel> { _taskProjectStorage.GetElement(model) };
            }
            return _taskProjectStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(TaskofprojectBindingModel model)
        {
            if (model.Id.HasValue)
            {
                _taskProjectStorage.Update(model);
            }
            else
            {
                _taskProjectStorage.Insert(model);
            }
        }
        public void Delete(TaskofprojectBindingModel model)
        {
            var element = _taskProjectStorage.GetElement(new TaskofprojectBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _taskProjectStorage.Delete(model);
        }
    }
}
