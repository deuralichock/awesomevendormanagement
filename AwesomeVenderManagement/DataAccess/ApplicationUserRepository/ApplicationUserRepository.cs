using AwesomeVenderManagement.Models;
using AwesomeVenderManagement.VendorDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AwesomeVenderManagement.DataAccess
{
    public class ApplicationUserRepository : BaseRepository<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUserRepository(ApplicationDbContext appDbContext)
            : base(appDbContext) { }
    }
}