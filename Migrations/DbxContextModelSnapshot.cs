﻿// <auto-generated />
using System;
using API_Workshop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API_Workshop.Migrations
{
    [DbContext(typeof(DbxContext))]
    partial class DbxContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("API_Workshop.Model.Jobs", b =>
                {
                    b.Property<string>("Job_ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Job_Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Max_Salary")
                        .HasColumnType("int");

                    b.Property<int>("Min_Salary")
                        .HasColumnType("int");

                    b.HasKey("Job_ID");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("API_Workshop.Model.Location", b =>
                {
                    b.Property<int>("Location_Id")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Postal_Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State_Province")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street_Address")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Location_Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("API_Workshop.Model.department", b =>
                {
                    b.Property<int>("Department_ID")
                        .HasColumnType("int");

                    b.Property<string>("Department_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Location_ID")
                        .HasColumnType("int");

                    b.Property<int>("Manager_ID")
                        .HasColumnType("int");

                    b.HasKey("Department_ID");

                    b.HasIndex("Location_ID");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("API_Workshop.Model.employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<float>("Commission_PCT")
                        .HasColumnType("real");

                    b.Property<int>("Department_ID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("First_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Hire_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Job_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Last_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Manager_ID")
                        .HasColumnType("int");

                    b.Property<string>("Phone_Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("salary")
                        .HasColumnType("real");

                    b.HasKey("EmployeeID");

                    b.HasIndex("Department_ID");

                    b.HasIndex("Job_Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("API_Workshop.Model.department", b =>
                {
                    b.HasOne("API_Workshop.Model.Location", "Location")
                        .WithMany("Department")
                        .HasForeignKey("Location_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("API_Workshop.Model.employee", b =>
                {
                    b.HasOne("API_Workshop.Model.department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("Department_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_Workshop.Model.Jobs", "Jobs")
                        .WithMany("Employees")
                        .HasForeignKey("Job_Id");

                    b.Navigation("Department");

                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("API_Workshop.Model.Jobs", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("API_Workshop.Model.Location", b =>
                {
                    b.Navigation("Department");
                });

            modelBuilder.Entity("API_Workshop.Model.department", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
