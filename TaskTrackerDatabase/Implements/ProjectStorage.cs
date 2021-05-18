using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskTrackerBusinessLogic.BindingModels;
using TaskTrackerBusinessLogic.Interfaces;
using TaskTrackerBusinessLogic.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace TaskTrackerDatabase.Implements
{
    public class ProjectStorage : IProjectStorage
    {
        public List<ProjectViewModel> GetFullList()
        {

            using (var context = new TaskTrackerContext())
            {
                return context.Project
                .Include(x => x.Taskofproject)
                .ThenInclude(rec => rec.Task)
                .Select(CreateModel)
                .ToList();

            }
        }
        public List<ProjectViewModel> GetFilteredList(ProjectBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new TaskTrackerContext())
            {
                return context.Project
                 .Where(rec => (rec.Customerid == model.Clientid))
                 .Select(CreateModel)
                 .ToList();
            }
        }
        public ProjectViewModel GetElement(ProjectBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new TaskTrackerContext())
            {
                var project = context.Project
               .Include(x => x.Taskofproject)
                .ThenInclude(rec => rec.Task)
                .FirstOrDefault(rec => rec.Projectid == model.Id);
                return project != null ?
               CreateModel(project, new TaskTrackerContext()) :
                null;
            }
        }
        public ProjectViewModel GetElementClient(ProjectBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new TaskTrackerContext())
            {
                var order = context.Project
                .FirstOrDefault(rec => rec.Customerid == model.Clientid);
                return order != null ?
                new ProjectViewModel
                {
                    Id = order.Projectid,
                    Name = order.Name,
                    Deadline = order.Deadline,
                    Price = order.Price,
                    Clientid = order.Customerid
                    
            } :
                null;
            }
        }

        public void Insert(ProjectBindingModel model)
        {
            using (var context = new TaskTrackerContext())
            {
                context.Project.Add(CreateModel(model, new Project()));
                context.SaveChanges();
            }
        }

        public void Update(ProjectBindingModel model)
        {
            using (var context = new TaskTrackerContext())
            {
                var element = context.Project.FirstOrDefault(rec => rec.Projectid == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        public void Delete(ProjectBindingModel model)
        {
            using (var context = new TaskTrackerContext())
            {
                Project element = context.Project.FirstOrDefault(rec => rec.Projectid == model.Id);
                if (element != null)
                {
                    context.Project.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        private Project CreateModel(ProjectBindingModel model, Project project)
        {
            Project pr = new Project();
            project.Projectid = model.Id;
            project.Name = model.Name;
            project.Price = model.Price;
            project.Deadline = model.Deadline;
            project.Customerid = model.Clientid;
           
            return project;
        }

        private ProjectViewModel CreateModel(Project project)
        {
           
            ProjectViewModel model = new ProjectViewModel();
            model.Id = project.Projectid;
            model.Name = project.Name;
            model.Price = project.Price;
            model.Deadline = project.Deadline;
            model.Clientid = project.Customerid;
            return model;
        }
        private ProjectViewModel CreateModel(Project project, TaskTrackerContext context)
        {

            ProjectViewModel model = new ProjectViewModel();
            model.Id = project.Projectid;
            model.Name = project.Name;
            model.Price = project.Price;
            model.Deadline = project.Deadline;
            model.Clientid = project.Customerid;
      
            if(model.TaskodProject == null)
            {
                model.TaskodProject = context
                .Taskofproject
                .Where(x => x.Projectid == project.Projectid)
                .ToDictionary(x => x.Projectid, x => x.Taskid);
            }
            
                
            
            model.Tasks = project
               .Taskofproject.Where(x => x.Projectid == project.Projectid)
              .ToDictionary(rec => rec.Task.Taskid, recPC => (recPC.Task.Name, recPC.Task.Startdate, recPC.Task.Enddate, recPC.Task.Text,
               recPC.Task.Priority, recPC.Task.State));


            return model;
        }
    }
}
