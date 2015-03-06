using AwesomeVenderManagement.Models;
using AwesomeVenderManagement.VendorDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AwesomeVenderManagement.DataAccess
{
    public class VendorCategoryRepository : BaseRepository<VendorCategory>
                                            ,IVenderCategoryRepository
    {

        public VendorCategoryRepository(ApplicationDbContext appDbContext)
            : base(appDbContext) { }
    }
}