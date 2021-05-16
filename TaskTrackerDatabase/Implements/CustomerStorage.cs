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
    public class CustomerStorage : ICustomerStorage
    {
        public List<CustomerViewModel> GetFullList()
        {
            using (var context = new TaskTrackerContext())
            {
                return context.Customer.Include(x => x.Userid)
                   .Select(CreateModel)
                   .ToList();
            }
        }

        public List<CustomerViewModel> GetFilteredList(CustomerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new TaskTrackerContext())
            {
                return context.Customer
                .Where(rec => rec.Company == model.Company)
                .Select(CreateModel)
                .ToList();
            }
        }

        public CustomerViewModel GetElement(CustomerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new TaskTrackerContext())
            {
                var user = context.Customer.FirstOrDefault(rec => rec.Userid == model.UserId || rec.Name == model.Name);
                return user != null ?
                new CustomerViewModel
                {
                    Id = user.Customerid,
                    Name =user.Name,
                    Company =user.Company
                } :
                null;
            }
        }

        public void Insert(CustomerBindingModel model)
        {
            using (var context = new TaskTrackerContext())
            {
                context.Customer.Add(CreateModel(model, new Customer()));
                context.SaveChanges();
            }
        }

        public void Update(CustomerBindingModel model)
        {
            using (var context = new TaskTrackerContext())
            {
                var element = context.Customer.FirstOrDefault(rec => rec.Customerid == model.Id);
                if (element == null)
                {
                    throw new Exception("Клиент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        public void Delete(CustomerBindingModel model)
        {
            using (var context = new TaskTrackerContext())
            {
                Customer element = context.Customer.FirstOrDefault(rec => rec.Customerid == model.Id);
                if (element != null)
                {
                    context.Customer.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Клиент не найден");
                }
            }
        }

        private Customer CreateModel(CustomerBindingModel model, Customer client)
        {
            client.Name = model.Name;
            client.Company = model.Company;
            client.Userid = model.UserId;
            return client;
        }

        private CustomerViewModel CreateModel(Customer client)
        {
            CustomerViewModel model = new CustomerViewModel();
            model.Id = client.Customerid;
            model.Name = client.Name;
            client.Userid = model.UserId;
            return model;
        }
    }
}
