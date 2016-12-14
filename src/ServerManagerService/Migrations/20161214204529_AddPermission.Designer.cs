using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ServerManagerService.DbContexts;

namespace ServerManagerService.Migrations
{
    [DbContext(typeof(PermissionsContext))]
    [Migration("20161214204529_AddPermission")]
    partial class AddPermission
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("ServerManagerService.Models.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Target");

                    b.HasKey("Id");

                    b.ToTable("Permissions");
                });
        }
    }
}
