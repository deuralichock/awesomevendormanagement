using AwesomeVenderManagement.DataAccess;
using AwesomeVenderManagement.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AwesomeVenderManagement.Controllers
{
    public abstract class BaseController : Controller
    {
        protected UserManager<ApplicationUser> UserManager =
                    new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new AwesomeVenderManagement.VendorDbContext.ApplicationDbContext()));


        protected ApplicationUser getCurrentlyLoggedInUser(IApplicationUserRepository applicationUserRepository)
        {
            return applicationUserRepository.Get(
                                    filter: currentUser => currentUser.UserName == this.User.Identity.Name).SingleOrDefault();
        }
    }
}