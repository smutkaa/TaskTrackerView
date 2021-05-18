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
   
   public class TaskofprojectStorage: ITaskProjectStorage
   {
        public List<TaskofprojectViewModel> GetFullList()
        {
            using (var context = new TaskTrackerContext())
            {
                return context.Taskofproject.Select(rec => new TaskofprojectViewModel
                {
                    Id = rec.Taskofprojectid
                })
             .ToList();
            }
        }

        public List<TaskofprojectViewModel> GetFilteredList(TaskofprojectBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new TaskTrackerContext())
            {
                return context.Taskofproject.
                Where(rec => rec.Projectid == model.Projectid)
                .Select(CreateModel)
                .ToList();
            }
        }

        public TaskofprojectViewModel GetElement(TaskofprojectBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new TaskTrackerContext())
            {
                var user = context.Taskofproject.FirstOrDefault(rec => rec.Projectid == model.Projectid);
                return user != null ?
                new TaskofprojectViewModel
                {
                    Id = user.Taskofprojectid,
                    Projectid = user.Projectid,
                    Taskid = user.Taskid
                } :
                null;
            }
        }

        public void Insert(TaskofprojectBindingModel model)
        {
            using (var context = new TaskTrackerContext())
            {
                context.Taskofproject.Add(CreateModel(model, new Taskofproject()));
                context.SaveChanges();
            }
        }

        public void Update(TaskofprojectBindingModel model)
        {
            using (var context = new TaskTrackerContext())
            {
                var element = context.Taskofproject.FirstOrDefault(rec => rec.Taskofprojectid == model.Id);
                if (element == null)
                {
                    throw new Exception("Задача не найдена");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        public void Delete(TaskofprojectBindingModel model)
        {
            using (var context = new TaskTrackerContext())
            {
                Taskofproject element = context.Taskofproject.FirstOrDefault(rec => rec.Taskofprojectid == model.Id);
                if (element != null)
                {
                    context.Taskofproject.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Пользователь не найден");
                }
            }
        }

        private Taskofproject CreateModel(TaskofprojectBindingModel model, Taskofproject tp)
        {
            tp.Projectid = model.Projectid;
            tp.Taskid = model.Taskid;
            return tp;
        }

        private TaskofprojectViewModel CreateModel(Taskofproject tp)
        {
            TaskofprojectViewModel model = new TaskofprojectViewModel();
            model.Id = tp.Taskofprojectid;
            model.Projectid = tp.Projectid;
            model.Taskid = tp.Taskid;
            return model;
        }
    }
}