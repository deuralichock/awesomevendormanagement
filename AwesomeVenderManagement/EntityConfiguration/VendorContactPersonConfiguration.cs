using AwesomeVenderManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

using System.Linq;
using System.Web;

namespace AwesomeVenderManagement.EntityConfiguration
{
    public class VendorContactPersonConfiguration 
        : EntityTypeConfiguration<VendorContactPerson>
    {
        public VendorContactPersonConfiguration()
        {
            Property(t => t.CellPhone)
               .IsRequired()
               .HasMaxLength(255)
               .IsUnicode(false);

            Property(t => t.Email)
              .HasMaxLength(255)
              .IsUnicode(false);

            Property(t => t.FirstName)
                .IsRequired()
               .HasMaxLength(255)
               .IsUnicode(false);

            Property(t => t.HomePhone)
              .HasMaxLength(255)
              .IsUnicode(false);

            Property(t => t.LastName)
                .IsRequired()
             .HasMaxLength(30)
             .IsUnicode(false);

            Property(t => t.MiddleName)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
        }
    }
}