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
    public class TaskStorage: ITaskStorage
    {
        public List<TaskViewModel> GetFullList()
        {
            using (var context = new TaskTrackerContext())
            {
                return context.Tasks.Select(rec => new TaskViewModel
                {
                    Id = rec.Taskid,
                })
                .ToList();
            }
        }

        public List<TaskViewModel> GetFilteredList(TaskBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new TaskTrackerContext())
            {
                return context.Tasks
                   .Where(rec => (rec.Name == model.Name))
                    .Select(rec => new TaskViewModel
                    {
                        Id = rec.Taskid,
                    }).ToList();
            }
        }
        public TaskViewModel GetElement(TaskBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new TaskTrackerContext())
            {
                var task = context.Tasks.FirstOrDefault(rec => rec.Projectid == model.Id);
                return task != null ?
                new TaskViewModel
                {
                    Projectid = task.Projectid,
                    Id=task.Taskid,
                    StartDate=task.Startdate,
                    EndDate = task.Enddate,
                    Name=task.Name,
                    Text = task.Text,
                    State =task.State,
                    Priority = task.Priority
            } :
                null;
            }
        }

        public void Insert(TaskBindingModel model)
        {
            using (var context = new TaskTrackerContext())
            {
                context.Tasks.Add(CreateModel(model, new Tasks()));
                context.SaveChanges();
            }
        }

        public void Update(TaskBindingModel model)
        {
            using (var context = new TaskTrackerContext())
            {
                var element = context.Tasks.FirstOrDefault(rec => rec.Taskid == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        public void Delete(TaskBindingModel model)
        {
            using (var context = new TaskTrackerContext())
            {
                Tasks element = context.Tasks.FirstOrDefault(rec => rec.Taskid == model.Id);
                if (element != null)
                {
                    context.Tasks.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        private Tasks CreateModel(TaskBindingModel model, Tasks task)
        {
            task.Taskid = model.Id;
            task.Startdate = model.StartDate;
            task.Enddate = model.EndDate;
            task.Name = model.Name;
            task.Text = model.Text;
            task.Projectid = model.Id;
            task.State = model.State;
            task.Priority = model.Priority;
            return task;
        }

    }
}
