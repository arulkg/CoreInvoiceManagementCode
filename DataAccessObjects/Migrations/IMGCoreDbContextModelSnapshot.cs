﻿// <auto-generated />
using DataAccessObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessObjects.Migrations
{
    [DbContext(typeof(IMGCoreDbContext))]
    partial class IMGCoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BusinessObjects.CategoryObj", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("Description");

                    b.Property<decimal>("MaximumRate")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("MaximumRate");

                    b.Property<decimal>("MaximumStock")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("MaximumStock");

                    b.Property<decimal>("MinimumRate")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("MinimumRate");

                    b.Property<decimal>("MinimumStock")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("MinimumStock");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(250)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("BusinessObjects.UserLoginObj", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("Password");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("UserName");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
