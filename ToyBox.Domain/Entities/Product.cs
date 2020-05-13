using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToyBox.Domain.Entities
{
    public class Product
    {
        [HiddenInput (DisplayValue = false)]
        public int ProductID { get; set; }


        [Required(ErrorMessage = "Product name is required")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }


        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }


        [Required]
        public decimal Price { get; set; }


        [Required]
        [Display(Name = "Category")]
        public int CategoryID { get; set; }



        [Required]
        [Display(Name = "Condition")]
        public int ConditionID { get; set; }


       
        public virtual Condition Condition { get; set; }


        [Required]
        public string Brand { get; set; }


        
        [Display(Name = "Year the Product Was Made")]
        public int YearOfProduct { get; set; }



        [HiddenInput(DisplayValue = false)]
        public DateTime PostedDate { get; set; }



        public bool AvaliableStatus { get; set; }


        public int userID { get; set; }



    }

}
