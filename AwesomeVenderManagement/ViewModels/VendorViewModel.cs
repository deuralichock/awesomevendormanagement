using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AwesomeVenderManagement.ViewModels
{
    [Serializable]
    public class VendorViewModel
    {
        public int Id { get; set; }

        public virtual List<VendorCategoryViewModel> VendorCategories { get; set; }
        [Required]
        [Display(Name = "Vendor Name")]

        public string VendorName { get; set; }

        [Display(Name = "Vendor Description")]

        public string VendorDescription { get; set; }
        [Required]

        [Display(Name = "Vendor Address1")]

        public string VendorAddress1 { get; set; }

        [Display(Name = "Vendor Address2")]

        public string VendorAddress2{ get; set; }
        [Required]
        [Display(Name = "Vendor City")]

        public string VendorCity { get; set; }

        [Display(Name = "Vendor State")]

        public string VendorState { get; set; }

        [Display(Name = "Vendor Zip Code")]

        public string VendorZipCode { get; set; }

        [Required]
        [Display(Name = "Vendor Country")]


        public string VendorCountry { get; set; }

        [Required]
        [Display(Name = "Contact Person First Name")]

        public  string ContactPersonFirstName { get; set; }

        [Display(Name = "Contact Person Middle Name")]

        public  string ContactPersonMiddleName { get; set; }
        [Required]
        [Display(Name = "Contact Person Last Name")]

        public  string ContactPersonLastName { get; set; }
        [Display(Name = "Contact Person Home Phone")]

        public  string ContactPersonHomePhone { get; set; }
        [Display(Name = "Contact Person Cell Phone")]

        public  string ContactPersonCellPhone { get; set; }

        [Display(Name = "Contact Person Email")]

        public  string ContactPersonEmail { get; set; }

        public string VendorCategoryName { get; set; }

        public string VendorCategoryId { get; set; }

    }
}