using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AwesomeVenderManagement.Models
{
    [Serializable]
    public class Address
    {
        public int Id { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
    }
}