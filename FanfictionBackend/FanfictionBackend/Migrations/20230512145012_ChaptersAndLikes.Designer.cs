﻿// <auto-generated />
using System;
using FanfictionBackend;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FanfictionBackend.Migrations
{
    [DbContext(typeof(FanficDb))]
    [Migration("20230512145012_ChaptersAndLikes")]
    partial class ChaptersAndLikes
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("FanfictionBackend.Models.Chapter", b =>
                {
                    b.Property<int>("FanficId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("FanficId");

                    b.ToTable("Chapters");
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

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Fanfics");
                });

            modelBuilder.Entity("FanfictionBackend.Models.Like", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("FanficId")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "FanficId");

                    b.HasIndex("FanficId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("FanfictionBackend.Models.Password", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Hash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte[]>("Salt")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.HasKey("Id");

                    b.ToTable("Password");
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

                    b.Property<int>("PasswordId")
                        .HasColumnType("integer");

                    b.Property<int?>("PasswordId1")
                        .HasColumnType("integer");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.HasIndex("PasswordId");

                    b.HasIndex("PasswordId1");

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

            modelBuilder.Entity("FanfictionBackend.Models.Chapter", b =>
                {
                    b.HasOne("FanfictionBackend.Models.Fanfic", "Fanfic")
                        .WithMany("Chapters")
                        .HasForeignKey("FanficId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fanfic");
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

            modelBuilder.Entity("FanfictionBackend.Models.Like", b =>
                {
                    b.HasOne("FanfictionBackend.Models.Fanfic", "Fanfic")
                        .WithMany("Likes")
                        .HasForeignKey("FanficId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FanfictionBackend.Models.User", "User")
                        .WithMany("Likes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fanfic");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FanfictionBackend.Models.User", b =>
                {
                    b.HasOne("FanfictionBackend.Models.Password", "Password")
                        .WithMany()
                        .HasForeignKey("PasswordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FanfictionBackend.Models.Password", null)
                        .WithMany()
                        .HasForeignKey("PasswordId1");

                    b.Navigation("Password");
                });

            modelBuilder.Entity("FanfictionBackend.Models.Fanfic", b =>
                {
                    b.Navigation("Chapters");

                    b.Navigation("Likes");
                });

            modelBuilder.Entity("FanfictionBackend.Models.User", b =>
                {
                    b.Navigation("Fanfics");

                    b.Navigation("Likes");
                });
#pragma warning restore 612, 618
        }
    }
}
