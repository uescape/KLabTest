using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KLabTest.Models
{
    public class KLabTextContext : IdentityDbContext<User>
    {
        private readonly DbContextOptions _options;

        public KLabTextContext(DbContextOptions options) : base(options)
        {
            _options = options;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public virtual DbSet<Task> Task { get; set; }
    }
}
