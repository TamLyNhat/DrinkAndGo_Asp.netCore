using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinkAndGoDemo.Data.Models
{
    public class ImportDetail
    {
        public int ImportDetailId { get; set; }
        public int Amount { get; set; }
        public virtual Import Import { get; set; }
        public virtual Category Category { get; set; }
    }
}
