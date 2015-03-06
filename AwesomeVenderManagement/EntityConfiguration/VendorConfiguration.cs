using AwesomeVenderManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

using System.Linq;
using System.Web;

namespace AwesomeVenderManagement.EntityConfiguration
{
    public class VendorConfiguration :
        EntityTypeConfiguration<Vendor>
    {
        public VendorConfiguration()
        {
            Property(t => t.VendorName)
            .IsRequired()
            .HasMaxLength(255)
            .IsUnicode(false);

            Property(t => t.VendorDescription)
           .HasMaxLength(1000)
           .IsUnicode(false);

            this.HasOptional(t => t.VendorModifiedBy)
                .WithMany()
                .HasForeignKey(t => t.ModifiedById);

            this.HasOptional(t => t.VendorCreatedBy)
                .WithMany()
                .HasForeignKey(key => key.VendorCreatedById);

            this.HasRequired(t => t.VenderCategory)
                .WithMany()
                .HasForeignKey(key => key.VendorCategoryId);

        }
    }
}