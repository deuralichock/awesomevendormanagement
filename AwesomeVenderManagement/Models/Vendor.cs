using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AwesomeVenderManagement.Models
{
    public class Vendor
    {
        public int Id { get; set; }

        public int VendorCategoryId { get; set; }
        public virtual VendorCategory VenderCategory { get; set; }
        public string VendorName { get; set; }
        public string VendorDescription { get; set; }


        public virtual Address VendorAddress { get; set; }

        public virtual VendorContactPerson ContactPerson { get; set; }

        public DateTime VendorCreatedDate { get; set; }

        public string VendorCreatedById { get; set; }
        public ApplicationUser VendorCreatedBy { get; set; }
        public bool IsActiveVendor { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string ModifiedById { get; set; }
        public ApplicationUser VendorModifiedBy { get; set; }

    }
}