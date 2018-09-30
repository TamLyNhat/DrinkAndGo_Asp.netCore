using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DinkAndGoDemo.Data.Models
{
    public class ImportDetail
    {
        public int ImportDetailId { get; set; }
        [Required(ErrorMessage = "Please enter Amount")]
        public int Amount { get; set; }
        [Required(ErrorMessage = "Please enter your Import Name")]
        [Display(Name = "Import name")]
        public int ImportId { get; set; }
        [BindRequired]
        [Required(ErrorMessage = "Please enter your Category Name")]
        [Display(Name = "Category name")]
        public int CategoryId { get; set; }
        public virtual Import Import { get; set; }
        public virtual Category Category { get; set; }
    }
}
