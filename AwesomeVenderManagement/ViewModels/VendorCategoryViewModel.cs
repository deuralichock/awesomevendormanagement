using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AwesomeVenderManagement.ViewModels
{
    public class VendorCategoryViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name="Vendor Name")]
        public string VendorName { get; set; }


        [Display(Name = "Vendor Description")]
        [DataType(DataType.MultilineText)]
        public string VendorDescription { get; set; }
    }
}