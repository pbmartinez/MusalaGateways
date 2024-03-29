﻿// <auto-generated />
using System;
using Infraestructure.Domain.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infraestructure.Migrations
{
    [DbContext(typeof(UnitOfWorkContainer))]
    [Migration("20220321153138_AddBrandToGateway")]
    partial class AddBrandToGateway
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1, 1);

            modelBuilder.Entity("Domain.Entities.Brand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GatewayId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sponsor")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GatewayId")
                        .IsUnique();

                    b.ToTable("Brand");
                });

            modelBuilder.Entity("Domain.Entities.Gateway", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Ipv4Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Gateway");
                });

            modelBuilder.Entity("Domain.Entities.Peripheral", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("GatewayId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Vendor")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GatewayId");

                    b.ToTable("Peripheral");
                });

            modelBuilder.Entity("Domain.Entities.Brand", b =>
                {
                    b.HasOne("Domain.Entities.Gateway", "Gateway")
                        .WithOne("Brand")
                        .HasForeignKey("Domain.Entities.Brand", "GatewayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gateway");
                });

            modelBuilder.Entity("Domain.Entities.Peripheral", b =>
                {
                    b.HasOne("Domain.Entities.Gateway", "Gateway")
                        .WithMany("Peripherals")
                        .HasForeignKey("GatewayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gateway");
                });

            modelBuilder.Entity("Domain.Entities.Gateway", b =>
                {
                    b.Navigation("Brand");

                    b.Navigation("Peripherals");
                });
#pragma warning restore 612, 618
        }
    }
}
