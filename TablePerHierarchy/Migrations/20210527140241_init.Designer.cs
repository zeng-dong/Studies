﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TablePerHierarchy.ConcreteBaseClass;

namespace TablePerHierarchy.Migrations
{
    [DbContext(typeof(ImplictDerivedTypesDbContext))]
    [Migration("20210527140241_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TablePerHierarchy.ConcreteBaseClass.Contract", b =>
                {
                    b.Property<int>("ContractId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Charge")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Months")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ContractId");

                    b.ToTable("Contracts");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Contract");
                });

            modelBuilder.Entity("TablePerHierarchy.ConcreteBaseClass.BroadBandContract", b =>
                {
                    b.HasBaseType("TablePerHierarchy.ConcreteBaseClass.Contract");

                    b.Property<int>("DownloadSpeed")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("BroadBandContract");
                });

            modelBuilder.Entity("TablePerHierarchy.ConcreteBaseClass.MobileContract", b =>
                {
                    b.HasBaseType("TablePerHierarchy.ConcreteBaseClass.Contract");

                    b.Property<string>("MobileNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("MobileContract");
                });

            modelBuilder.Entity("TablePerHierarchy.ConcreteBaseClass.TvContract", b =>
                {
                    b.HasBaseType("TablePerHierarchy.ConcreteBaseClass.Contract");

                    b.Property<int>("PackageType")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("TvContract");
                });
#pragma warning restore 612, 618
        }
    }
}
