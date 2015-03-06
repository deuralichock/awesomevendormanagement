using AwesomeVenderManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

using System.Linq;
using System.Web;

namespace AwesomeVenderManagement.EntityConfiguration
{
    public class AddressConfiguration : EntityTypeConfiguration<Address>
    {
        public AddressConfiguration()
        {
            Property(t => t.Address1)
               .IsRequired()
               .HasMaxLength(255)
               .IsUnicode(false);

            Property(t => t.Address2)
              .HasMaxLength(255)
              .IsUnicode(false);

            Property(t => t.City)
               .HasMaxLength(255)
               .IsUnicode(false);

            Property(t => t.State)
              .HasMaxLength(255)
              .IsUnicode(false);

            Property(t => t.ZipCode)
             .HasMaxLength(30)
             .IsUnicode(false);

            Property(t => t.Country)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
        }
    }
}