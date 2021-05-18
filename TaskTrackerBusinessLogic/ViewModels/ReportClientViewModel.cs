using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TaskTrackerBusinessLogic.ViewModels
{
    public class ReportClientViewModel
    {
        
        public int? Id { get; set; }

        [DisplayName("Название")]
        public string Name { get; set; }
        [DisplayName("Дедлайн")]
        public DateTime Deadline { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
    }
}
