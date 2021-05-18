using System;
using System.Collections.Generic;
using System.Text;
using TaskTrackerBusinessLogic.BindingModels;
using TaskTrackerBusinessLogic.ViewModels;

namespace TaskTrackerBusinessLogic.Interfaces
{
    public interface ICommentStorage
    {
        List<CommentViewModel> GetFullList();

        CommentViewModel GetElement(CommentBindingModel model);

        void Insert(CommentBindingModel model);

        void Update(CommentBindingModel model);

        void Delete(CommentBindingModel model);
    }
}
