using System;
using System.Collections.Generic;
using System.Text;
using TaskTrackerBusinessLogic.BindingModels;
using TaskTrackerBusinessLogic.Interfaces;
using TaskTrackerBusinessLogic.ViewModels;

namespace TaskTrackerBusinessLogic.BusinessLogics
{
    public class ProjectLogic
    {
        private readonly IProjectStorage _projectStorage;

        public ProjectLogic(IProjectStorage projectStorage)
        {
            _projectStorage = projectStorage;
        }

        public List<ProjectViewModel> Read(ProjectBindingModel model)
        {
            if (model == null)
            {
                return _projectStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<ProjectViewModel> { _projectStorage.GetElement(model) };
            }
            if (model.Clientid.HasValue)
            {
                return new List<ProjectViewModel> { _projectStorage.GetElement(model) };
            }
            return _projectStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(ProjectBindingModel model)
        {
            var element = _projectStorage.GetElement(new ProjectBindingModel
            {
                Name = model.Name,
                Clientid = model.Clientid
            }); ;
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть такой проект");
            }
            if (model.Id.HasValue)
            {
                _projectStorage.Update(model);
            }
            else
            {
                _projectStorage.Insert(model);
            }
        }
        public void Delete(ProjectBindingModel model)
        {
            var element = _projectStorage.GetElement(new ProjectBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Проект не найден");
            }
            _projectStorage.Delete(model);
        }
    }
}
