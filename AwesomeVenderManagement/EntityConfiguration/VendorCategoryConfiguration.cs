using AwesomeVenderManagement.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AwesomeVenderManagement.EntityConfiguration
{
    public class VendorCategoryConfiguration : 
        EntityTypeConfiguration<VendorCategory>
    {
        public VendorCategoryConfiguration()
        {
             Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(255)
            .IsUnicode(false);

             Property(t => t.Description)
            .HasMaxLength(1000)
            .IsUnicode(false);


        }
    }
}