﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UniversityInfo.Infrastructure;

#nullable disable

namespace UniversityInfo.Infrastructure.Migrations
{
    [DbContext(typeof(UniversityInfoContext))]
    [Migration("20240519105417_updateUniversityDB")]
    partial class updateUniversityDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("UniversityInfo.Domain.Entities.University", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("AlphaTwoCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StateProvince")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Universities");
                });

            modelBuilder.Entity("UniversityInfo.Domain.Entities.UniversityDomain", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("DomainName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UniversityId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UniversityId");

                    b.ToTable("UnivrsityDomains");
                });

            modelBuilder.Entity("UniversityInfo.Domain.Entities.WebPage", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("UniversityId")
                        .HasColumnType("bigint");

                    b.Property<string>("WebPageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UniversityId");

                    b.ToTable("WebPages");
                });

            modelBuilder.Entity("UniversityInfo.Domain.Entities.UniversityDomain", b =>
                {
                    b.HasOne("UniversityInfo.Domain.Entities.University", "University")
                        .WithMany("Domains")
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("University");
                });

            modelBuilder.Entity("UniversityInfo.Domain.Entities.WebPage", b =>
                {
                    b.HasOne("UniversityInfo.Domain.Entities.University", "University")
                        .WithMany("WebPages")
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("University");
                });

            modelBuilder.Entity("UniversityInfo.Domain.Entities.University", b =>
                {
                    b.Navigation("Domains");

                    b.Navigation("WebPages");
                });
#pragma warning restore 612, 618
        }
    }
}
