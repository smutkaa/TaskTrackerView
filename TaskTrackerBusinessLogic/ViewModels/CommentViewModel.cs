using System;
using System.Collections.Generic;
using System.Text;

namespace TaskTrackerBusinessLogic.ViewModels
{
    public class CommentViewModel
    {
        public int? Id { get; set; }
        public string Text { get; set; }
        public string Mark { get; set; }
        public int ClientId { get; set; }
        public int TaskId { get; set; }
    }
}
