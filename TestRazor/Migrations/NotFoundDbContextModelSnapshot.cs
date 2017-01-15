using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using U2U.AspNetCore.NotFound;

namespace TestRazor.Migrations
{
    [DbContext(typeof(NotFoundDbContext))]
    partial class NotFoundDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("U2U.AspNetCore.NotFound.NotFoundRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FixedPath");

                    b.Property<int>("Hits");

                    b.Property<string>("Path");

                    b.HasKey("Id");

                    b.ToTable("NotFoundRequests");
                });
        }
    }
}
