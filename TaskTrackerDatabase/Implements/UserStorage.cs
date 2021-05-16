using System;
using System.Collections.Generic;
using System.Text;
using TaskTrackerBusinessLogic.BindingModels;
using TaskTrackerBusinessLogic.Enums;
using TaskTrackerBusinessLogic.ViewModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TaskTrackerBusinessLogic.Interfaces;

namespace TaskTrackerDatabase.Implements
{
    public class UserStorage : IUserStorage
    {
        public List<UserViewModel> GetFullList()
        {
            using (var context = new TaskTrackerContext())
            {
                return context.Users.Select(rec => new UserViewModel
                {
                    Id = rec.Userid
                })
             .ToList();
            }
        }

        public List<UserViewModel> GetFilteredList(UserBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new TaskTrackerContext())
            {
                return context.Users.
                Where(rec => rec.Login == model.Login)
                .Select(CreateModel)
                .ToList();
            }
        }

        public UserViewModel GetElement(UserBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new TaskTrackerContext())
            {
                var user = context.Users.FirstOrDefault(rec => rec.Userid == model.Id || rec.Login == model.Login);
                return user != null ?
                new UserViewModel
                {
                    Id = user.Userid,
                    Login = user.Login,
                    Password = user.Password
                } :
                null;
            }
        }

        public void Insert(UserBindingModel model)
        {
            using (var context = new TaskTrackerContext())
            {
                context.Users.Add(CreateModel(model, new Users()));
                context.SaveChanges();
            }
        }

        public void Update(UserBindingModel model)
        {
            using (var context = new TaskTrackerContext())
            {
                var element = context.Users.FirstOrDefault(rec => rec.Userid == model.Id);
                if (element == null)
                {
                    throw new Exception("Пользователь не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        public void Delete(UserBindingModel model)
        {
            using (var context = new TaskTrackerContext())
            {
                Users element = context.Users.FirstOrDefault(rec => rec.Userid == model.Id);
                if (element != null)
                {
                    context.Users.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Пользователь не найден");
                }
            }
        }

        private Users CreateModel(UserBindingModel model, Users user)
        {
            user.Login = model.Login;
            user.Password = model.Password;
            user.Role = Convert.ToInt32(model.Role);
            return user;
        }

        private UserViewModel CreateModel(Users user)
        {
            UserViewModel model = new UserViewModel();
            model.Id = user.Userid;
            model.Login = user.Login;
            model.Password = user.Password;
            model.Role = (UserRole)user.Role;
            return model;
        }
    }
}
