using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServerManagerService.Models;

namespace ServerManagerService.DbContexts
{
    public class PermissionsContext : DbContext
    {
        public DbSet<Permission> Permissions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./Permissions.db");
        }
    }
}
