using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KLabTest.Models.ViewModels
{
    public class TaskViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Task name is required")]
        [Display(Name = "Task Name")]
        public string TaskName { get; set; }
    }
}
