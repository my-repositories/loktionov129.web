// Copyright (c) ProjectName. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using Microsoft.EntityFrameworkCore;
using ProjectName.Domain.Users.Entities;

namespace ProjectName.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(e => e.Login)
                .IsUnique();

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .HasMaxLength(64);
        }
    }
}
