using Microsoft.EntityFrameworkCore;
using Netdev.Domain.Entities.Docs;
using Netdev.Domain.Entities.Interviews;
using Netdev.Domain.Entities.Statistics;
using Netdev.Domain.Entities.TestCategories;
using Netdev.Domain.Entities.Tests;
using Netdev.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netdev.DataAccess.DbContexts
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Doc> Docs { get; set; } = default!;
        public virtual DbSet<Interview> Interviews { get; set; } = default!;
        public virtual DbSet<Statistic> Statistics { get; set; } = default!;
        public virtual DbSet<TestCategory> TestCategories { get; set; } = default!;
        public virtual DbSet<Test> Tests { get; set; } = default!;
        public virtual DbSet<User> Users { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(p=>p.Email)
                .IsUnique();
        }
    }
}
