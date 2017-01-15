using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using U2U.AspNetCore.NotFound;

namespace TestRazor.Migrations
{
    [DbContext(typeof(NotFoundDbContext))]
    [Migration("20170113122057_Created")]
    partial class Created
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
