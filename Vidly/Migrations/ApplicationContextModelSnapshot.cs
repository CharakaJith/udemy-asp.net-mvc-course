﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Vidly.Data;

#nullable disable

namespace Vidly.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Vidly.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsSubscribedToNewsletter")
                        .HasColumnType("boolean");

                    b.Property<byte>("MembershipTypeId")
                        .HasColumnType("smallint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(225)
                        .HasColumnType("character varying(225)");

                    b.HasKey("Id");

                    b.HasIndex("MembershipTypeId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Vidly.Models.MembershipType", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("smallint");

                    b.Property<byte>("DiscountRate")
                        .HasColumnType("smallint");

                    b.Property<byte>("DurationInMonths")
                        .HasColumnType("smallint");

                    b.Property<short>("SignUpFee")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("MembershipTypes");
                });

            modelBuilder.Entity("Vidly.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(225)
                        .HasColumnType("character varying(225)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(225)
                        .HasColumnType("character varying(225)");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("Vidly.Models.Customer", b =>
                {
                    b.HasOne("Vidly.Models.MembershipType", "MembershipType")
                        .WithMany()
                        .HasForeignKey("MembershipTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MembershipType");
                });
#pragma warning restore 612, 618
        }
    }
}