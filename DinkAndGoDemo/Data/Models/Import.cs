using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DinkAndGoDemo.Data.Models
{
    public class Import
    {
        public int ImportId { get; set; }
        [Required(ErrorMessage = "Please enter your Import name")]
        [Display(Name = "Import name")]
        [StringLength(50, ErrorMessage = "Maximun lenght is 50 character")]
        public string ProductName { get; set; }
        public DateTime ImportDate { get; set; }
        public List<ImportDetail> ImportDetails { get; set; }

    }
}
