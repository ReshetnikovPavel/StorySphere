﻿// <auto-generated />
using System;
using FanfictionBackend;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FanfictionBackend.Migrations
{
    [DbContext(typeof(FanficDb))]
    partial class FanficDbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.3.23174.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FanficTag", b =>
                {
                    b.Property<int>("FanficsId")
                        .HasColumnType("integer");

                    b.Property<string>("TagsName")
                        .HasColumnType("text");

                    b.HasKey("FanficsId", "TagsName");

                    b.HasIndex("TagsName");

                    b.ToTable("FanficTag");
                });

            modelBuilder.Entity("FanfictionBackend.Models.Fanfic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AgeLimit")
                        .HasColumnType("integer");

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<int>("Category")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<DateTime>("PostedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Fanfics");
                });

            modelBuilder.Entity("FanfictionBackend.Models.Tag", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Name");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("FanfictionBackend.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FanficTag", b =>
                {
                    b.HasOne("FanfictionBackend.Models.Fanfic", null)
                        .WithMany()
                        .HasForeignKey("FanficsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FanfictionBackend.Models.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FanfictionBackend.Models.Fanfic", b =>
                {
                    b.HasOne("FanfictionBackend.Models.User", "Author")
                        .WithMany("Fanfics")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("FanfictionBackend.Models.User", b =>
                {
                    b.Navigation("Fanfics");
                });
#pragma warning restore 612, 618
        }
    }
}