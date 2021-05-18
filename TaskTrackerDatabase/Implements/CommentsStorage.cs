using System;
using System.Collections.Generic;
using System.Text;
using TaskTrackerBusinessLogic.BindingModels;
using TaskTrackerBusinessLogic.Interfaces;
using TaskTrackerBusinessLogic.ViewModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TaskTrackerDatabase.Implements
{
    public class CommentsStorage : ICommentStorage
    {
        public List<CommentViewModel> GetFullList()
        {
            using (var context = new TaskTrackerContext())
            {
                return context.Comments.Select(rec => new CommentViewModel
                {
                    Id = rec.Taskid,
                })
                .ToList();
            }
        }

        public CommentViewModel GetElement(CommentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new TaskTrackerContext())
            {
                var task = context.Comments
                .FirstOrDefault(rec => rec.Taskid == model.Id);
                return task != null ?
                new CommentViewModel
                {
                    Id = task.Commentid,
                    Text = task.Text,
                    //Mark = task.Mark,
                    ClientId = task.Customerid,
                    TaskId = task.Taskid

                } :
                null;
            }
        }

        public void Insert(CommentBindingModel model)
        {
            using (var context = new TaskTrackerContext())
            {
                context.Comments.Add(CreateModel(model, new Comments()));
                context.SaveChanges();
            }
        }

        public void Update(CommentBindingModel model)
        {
            using (var context = new TaskTrackerContext())
            {
                var element = context.Comments.FirstOrDefault(rec => rec.Commentid == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        public void Delete(CommentBindingModel model)
        {
            using (var context = new TaskTrackerContext())
            {
                Comments element = context.Comments.FirstOrDefault(rec => rec.Commentid == model.Id);
                if (element != null)
                {
                    context.Comments.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        private Comments CreateModel(CommentBindingModel model, Comments com)
        {
            com.Commentid = model.Id;
            com.Text = model.Text;
            //Mark = task.Mark,
            com.Customerid = model.ClientId;
            com.Taskid = model.TaskId;
            return com;
        }
    }
}
