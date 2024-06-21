﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SpendTracker.Infrastructure.Persistence;

#nullable disable

namespace SpendTracker.Migrations.User
{
    [DbContext(typeof(UserContext))]
    partial class UserContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SpendTracker.Domain.Journies.Journey", b =>
                {
                    b.Property<int>("JourneyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JourneyId"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("JourneyName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("JourneyId");

                    b.HasIndex("UserId");

                    b.ToTable("Journeys", (string)null);
                });

            modelBuilder.Entity("SpendTracker.Domain.Journies.JourneySpends", b =>
                {
                    b.Property<int>("JourneySpendsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JourneySpendsId"));

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("JourneyId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("JourneySpendsId");

                    b.HasIndex("JourneyId")
                        .IsUnique();

                    b.ToTable("JourneySpends", (string)null);
                });

            modelBuilder.Entity("SpendTracker.Domain.Spends.Spend", b =>
                {
                    b.Property<int>("SpendId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SpendId"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("JourneySpendsId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SpendDate")
                        .HasColumnType("datetime2");

                    b.HasKey("SpendId");

                    b.HasIndex("JourneySpendsId");

                    b.ToTable("Spends", (string)null);
                });

            modelBuilder.Entity("SpendTracker.Domain.Users.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("LastLoginDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("SpendTracker.Domain.Journies.Journey", b =>
                {
                    b.HasOne("SpendTracker.Domain.Users.User", "User")
                        .WithMany("Journeys")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SpendTracker.Domain.Journies.JourneySpends", b =>
                {
                    b.HasOne("SpendTracker.Domain.Journies.Journey", "Journey")
                        .WithOne("JourneySpends")
                        .HasForeignKey("SpendTracker.Domain.Journies.JourneySpends", "JourneyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Journey");
                });

            modelBuilder.Entity("SpendTracker.Domain.Spends.Spend", b =>
                {
                    b.HasOne("SpendTracker.Domain.Journies.JourneySpends", "JourneySpends")
                        .WithMany("Spends")
                        .HasForeignKey("JourneySpendsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JourneySpends");
                });

            modelBuilder.Entity("SpendTracker.Domain.Journies.Journey", b =>
                {
                    b.Navigation("JourneySpends")
                        .IsRequired();
                });

            modelBuilder.Entity("SpendTracker.Domain.Journies.JourneySpends", b =>
                {
                    b.Navigation("Spends");
                });

            modelBuilder.Entity("SpendTracker.Domain.Users.User", b =>
                {
                    b.Navigation("Journeys");
                });
#pragma warning restore 612, 618
        }
    }
}
