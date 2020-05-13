using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ToyBox.Domain.Entities
{
    public class Category
    {
        [Required]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
