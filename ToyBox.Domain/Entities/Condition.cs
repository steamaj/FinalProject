using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ToyBox.Domain.Entities
{
    public class Condition
    {
        [Required]
        public int ConditionID { get; set; }
        public string ConditionName { get; set; }
    }
}
