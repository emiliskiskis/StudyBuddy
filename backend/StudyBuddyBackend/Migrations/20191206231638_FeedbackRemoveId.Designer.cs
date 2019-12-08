﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using StudyBuddyBackend.Database;

namespace StudyBuddyBackend.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20191206231638_FeedbackRemoveId")]
    partial class FeedbackRemoveId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("StudyBuddyBackend.Database.Entities.Chat", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("StudyBuddyBackend.Database.Entities.Feedback", b =>
                {
                    b.Property<string>("AuthorUsername")
                        .HasColumnType("character varying");

                    b.Property<string>("ReviewerUsername")
                        .HasColumnType("character varying");

                    b.Property<string>("Comment")
                        .HasColumnType("text");

                    b.HasKey("AuthorUsername", "ReviewerUsername");

                    b.HasIndex("ReviewerUsername");

                    b.ToTable("Feedback");
                });

            modelBuilder.Entity("StudyBuddyBackend.Database.Entities.Message", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("VARCHAR(36)");

                    b.Property<string>("ChatId")
                        .HasColumnType("text");

                    b.Property<DateTime>("SentAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .HasColumnType("character varying");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.HasIndex("Username");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("StudyBuddyBackend.Database.Entities.ProfilePicture", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("character varying");

                    b.Property<string>("Data")
                        .HasColumnType("text");

                    b.HasKey("Username");

                    b.ToTable("ProfilePictures");
                });

            modelBuilder.Entity("StudyBuddyBackend.Database.Entities.User", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("VARCHAR")
                        .HasMaxLength(255);

                    b.Property<string>("Email")
                        .HasColumnType("VARCHAR")
                        .HasMaxLength(255);

                    b.Property<string>("FirstName")
                        .HasColumnType("VARCHAR")
                        .HasMaxLength(255);

                    b.Property<string>("LastName")
                        .HasColumnType("VARCHAR")
                        .HasMaxLength(255);

                    b.Property<string>("Password")
                        .HasColumnType("VARCHAR")
                        .HasMaxLength(255);

                    b.Property<string>("Salt")
                        .HasColumnType("VARCHAR")
                        .HasMaxLength(255);

                    b.HasKey("Username");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("StudyBuddyBackend.Database.Entities.UserInChat", b =>
                {
                    b.Property<string>("ChatId")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .HasColumnType("character varying");

                    b.HasKey("ChatId", "Username");

                    b.HasIndex("Username");

                    b.ToTable("UsersInChats");
                });

            modelBuilder.Entity("StudyBuddyBackend.Database.Entities.Feedback", b =>
                {
                    b.HasOne("StudyBuddyBackend.Database.Entities.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorUsername")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudyBuddyBackend.Database.Entities.User", "Reviewer")
                        .WithMany()
                        .HasForeignKey("ReviewerUsername")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StudyBuddyBackend.Database.Entities.Message", b =>
                {
                    b.HasOne("StudyBuddyBackend.Database.Entities.Chat", null)
                        .WithMany("Messages")
                        .HasForeignKey("ChatId");

                    b.HasOne("StudyBuddyBackend.Database.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("Username");
                });

            modelBuilder.Entity("StudyBuddyBackend.Database.Entities.ProfilePicture", b =>
                {
                    b.HasOne("StudyBuddyBackend.Database.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("Username")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StudyBuddyBackend.Database.Entities.UserInChat", b =>
                {
                    b.HasOne("StudyBuddyBackend.Database.Entities.Chat", "Chat")
                        .WithMany("Users")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudyBuddyBackend.Database.Entities.User", "User")
                        .WithMany("Chats")
                        .HasForeignKey("Username")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
