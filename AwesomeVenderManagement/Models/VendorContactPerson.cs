using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AwesomeVenderManagement.Models
{
    public class VendorContactPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string HomePhone { get; set; }
        public string CellPhone { get; set; }
    }
}