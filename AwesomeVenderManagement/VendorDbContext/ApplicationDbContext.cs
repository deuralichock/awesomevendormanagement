using AwesomeVenderManagement.EntityConfiguration;
using AwesomeVenderManagement.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace AwesomeVenderManagement.VendorDbContext
{
    public class ApplicationDbContext 
        : IdentityDbContext<ApplicationUser>
    {

        #region model properties
        public virtual IDbSet<VendorCategory> VendorCategories { get; set; }
        public virtual IDbSet<Vendor> Vendors { get; set; }

        #endregion 

        public ApplicationDbContext()
            : base("venderManagementConnectionString")
        {
            //this.ChangeTracker.DetectChanges()

            this.Database.Log = (s) => Debug.Write(s);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            this.Configuration.AutoDetectChangesEnabled = false;
           
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new VendorCategoryConfiguration());
            modelBuilder.Configurations.Add(new VendorConfiguration());
            modelBuilder.Configurations.Add(new AddressConfiguration());
            modelBuilder.Configurations.Add(new VendorContactPersonConfiguration());

             
            base.OnModelCreating(modelBuilder);

            
        }
    }
}