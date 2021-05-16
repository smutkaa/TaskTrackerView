using System;
using System.Collections.Generic;
using System.Text;
using TaskTrackerBusinessLogic.BindingModels;
using TaskTrackerBusinessLogic.Interfaces;
using TaskTrackerBusinessLogic.ViewModels;

namespace TaskTrackerBusinessLogic.BusinessLogics
{
    public class CustomerLogic
    {
        private readonly ICustomerStorage _clientStorage;

        public CustomerLogic(ICustomerStorage clientStorage)
        {
            _clientStorage = clientStorage;
        }

        public List<CustomerViewModel> Read(CustomerBindingModel model)
        {
            if (model == null)
            {
                return _clientStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<CustomerViewModel> { _clientStorage.GetElement(model) };
            }
            if (model.UserId.HasValue)
            {
                return new List<CustomerViewModel> { _clientStorage.GetElement(model) };
            }
            return _clientStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(CustomerBindingModel model)
        {
            var element = _clientStorage.GetElement(new CustomerBindingModel
            {
                UserId=model.UserId
            });
            if (element != null)
            {
                throw new Exception("Уже есть клиент");
            }
            if (model.Id.HasValue)
            {
                _clientStorage.Update(model);
            }
            else
            {
                _clientStorage.Insert(model);
            }
        }
        public void Delete(CustomerBindingModel model)
        {
            var element = _clientStorage.GetElement(new CustomerBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Клиент не найден");
            }
            _clientStorage.Delete(model);
        }
    }
}
