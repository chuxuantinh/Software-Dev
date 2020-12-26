using System;
using System.Collections.Generic;
using System.Text;
using lab5.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace lab5.Data.Configurations
{
    public class MakeConfiguration : IEntityTypeConfiguration<Make>
    {
        public void Configure(EntityTypeBuilder<Make> make)
        {
            make
                    .HasIndex(m => m.Name)
                    .IsUnique();


            make
                .HasMany(m => m.Models)
                .WithOne(m => m.Make)
                .HasForeignKey(m => m.MakeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
