using System;
using System.Collections.Generic;
using System.Text;

namespace TaskTrackerBusinessLogic.BindingModels
{
    public class TaskofprojectBindingModel
    {
        public int? Id { get; set; }
        public int? Projectid { get; set; }
        public int? Taskid { get; set; }
    }
}
