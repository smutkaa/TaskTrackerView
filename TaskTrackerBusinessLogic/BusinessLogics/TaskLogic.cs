using System;
using System.Collections.Generic;
using System.Text;
using TaskTrackerBusinessLogic.BindingModels;
using TaskTrackerBusinessLogic.Interfaces;
using TaskTrackerBusinessLogic.ViewModels;

namespace TaskTrackerBusinessLogic.BusinessLogics
{
    public class TaskLogic
    {
        private readonly ITaskStorage _taskStorage;

        public TaskLogic(ITaskStorage taskStorage)
        {
            _taskStorage = taskStorage;
        }

        public List<TaskViewModel> Read(TaskBindingModel model)
        {
            if (model == null)
            {
                return _taskStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<TaskViewModel> { _taskStorage.GetElement(model) };
            }
            return _taskStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(TaskBindingModel model)
        {
            var element = _taskStorage.GetElement(new TaskBindingModel
            {
                Name = model.Name,
                Text = model.Text,
                Projectid = model.Projectid
            }); ;
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть такая задача");
            }
            if (model.Id.HasValue)
            {
                _taskStorage.Update(model);
            }
            else
            {
                _taskStorage.Insert(model);
            }
        }
        public void Delete(TaskBindingModel model)
        {
            var element = _taskStorage.GetElement(new TaskBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Задача не найдена");
            }
            _taskStorage.Delete(model);
        }
    }

}
