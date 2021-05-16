using System;
using System.Collections.Generic;
using TaskTrackerBusinessLogic.BindingModels;
using TaskTrackerBusinessLogic.Interfaces;
using TaskTrackerBusinessLogic.ViewModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TaskTrackerDatabase.Implements
{
    public class ExecutorStorage: IExecutorStorage
    {
        public List<ExecutorViewModel> GetFullList()
        {
            using (var context = new TaskTrackerContext())
            {
                return context.Executor.Include(x => x.Userid)
                   .Select(CreateModel)
                   .ToList();
            }
        }

        public List<ExecutorViewModel> GetFilteredList(ExecutorBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new TaskTrackerContext())
            {
                return context.Executor
                .Where(rec => rec.Company == model.Company)
                .Select(CreateModel)
                .ToList();
            }
        }

        public ExecutorViewModel GetElement(ExecutorBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new TaskTrackerContext())
            {
                var user = context.Executor.FirstOrDefault(rec => rec.Userid == model.Id || rec.Name == model.Name);
                return user != null ?
                new ExecutorViewModel
                {
                    Id = user.Executorid,
                    Name = user.Name,
                    Company = user.Company
                } :
                null;
            }
        }

        public void Insert(ExecutorBindingModel model)
        {
            using (var context = new TaskTrackerContext())
            {
                context.Executor.Add(CreateModel(model, new Executor()));
                context.SaveChanges();
            }
        }

        public void Update(ExecutorBindingModel model)
        {
            using (var context = new TaskTrackerContext())
            {
                var element = context.Executor.FirstOrDefault(rec => rec.Executorid == model.Id);
                if (element == null)
                {
                    throw new Exception("Клиент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        public void Delete(ExecutorBindingModel model)
        {
            using (var context = new TaskTrackerContext())
            {
                Executor element = context.Executor.FirstOrDefault(rec => rec.Executorid == model.Id);
                if (element != null)
                {
                    context.Executor.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Клиент не найден");
                }
            }
        }

        private Executor CreateModel(ExecutorBindingModel model, Executor executor)
        {
            executor.Name = model.Name;
            executor.Company = model.Company;
            executor.Userid = model.UserId;
            return executor;
        }

        private ExecutorViewModel CreateModel(Executor executor)
        {
            ExecutorViewModel model = new ExecutorViewModel();
            model.Id = executor.Executorid;
            model.Name = executor.Name;
            executor.Userid = model.UserId;
            return model;
        }
    }
}
