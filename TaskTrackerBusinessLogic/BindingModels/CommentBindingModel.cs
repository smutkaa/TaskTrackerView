using System;
using System.Collections.Generic;
using System.Text;
using TaskTrackerBusinessLogic.Enums;

namespace TaskTrackerBusinessLogic.BindingModels
{
    public class CommentBindingModel
    {
        public int? Id { get; set; }
        public string Text { get; set; }
        public string Mark { get; set; }
        public int? ClientId { get; set; }
        public int? TaskId { get; set; }
    }
}
