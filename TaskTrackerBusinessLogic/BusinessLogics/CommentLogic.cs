using System;
using System.Collections.Generic;
using System.Text;
using TaskTrackerBusinessLogic.BindingModels;
using TaskTrackerBusinessLogic.Interfaces;
using TaskTrackerBusinessLogic.ViewModels;

namespace TaskTrackerBusinessLogic.BusinessLogics
{
    public class CommentLogic
    {
        private readonly ICommentStorage _commentStorage;

        public CommentLogic(ICommentStorage commentStorage)
        {
            _commentStorage = commentStorage;
        }

        public List<CommentViewModel> Read(CommentBindingModel model)
        {
            if (model == null)
            {
                return _commentStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<CommentViewModel> { _commentStorage.GetElement(model) };
            }
            return _commentStorage.GetFullList();
        }

        public void CreateOrUpdate(CommentBindingModel model)
        {
            
            if (model.Id.HasValue)
            {
                _commentStorage.Update(model);
            }
            else
            {
                _commentStorage.Insert(model);
            }
        }
        public void Delete(CommentBindingModel model)
        {
            var element = _commentStorage.GetElement(new CommentBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Комментарий не найден");
            }
            _commentStorage.Delete(model);
        }
    }
}
