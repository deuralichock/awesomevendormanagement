using AwesomeVenderManagement.Models;
using AwesomeVenderManagement.VendorDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AwesomeVenderManagement.DataAccess
{
    public class VendorRepository  : BaseRepository<Vendor>, IVendorRepository
    {
        public VendorRepository(ApplicationDbContext appDbContext)
            : base(appDbContext) { }
    }
}