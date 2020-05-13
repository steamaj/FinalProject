using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ToyBox.WebUI.Models
{
    public class Condition
    {
        [Required]
        public int ConditionID { get; set; }
        public string ConditionName { get; set; }

        
    }


}