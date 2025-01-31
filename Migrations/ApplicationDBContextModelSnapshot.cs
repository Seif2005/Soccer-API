﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SoccerAPI.Models;

#nullable disable

namespace SoccerAPI.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SoccerAPI.Models.Coach", b =>
                {
                    b.Property<int>("CoachId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CoachId"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("Experience")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("CoachId");

                    b.HasIndex("TeamId")
                        .IsUnique();

                    b.ToTable("Coaches", (string)null);
                });

            modelBuilder.Entity("SoccerAPI.Models.Cup", b =>
                {
                    b.Property<int>("CupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CupId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfTeams")
                        .HasColumnType("int");

                    b.HasKey("CupId");

                    b.ToTable("Cups", (string)null);
                });

            modelBuilder.Entity("SoccerAPI.Models.CupTeam", b =>
                {
                    b.Property<int>("Cupid")
                        .HasColumnType("int");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Cupid", "TeamId");

                    b.HasIndex("TeamId");

                    b.ToTable("CupTeam", (string)null);
                });

            modelBuilder.Entity("SoccerAPI.Models.Match", b =>
                {
                    b.Property<int>("MatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MatchId"));

                    b.Property<int>("CupId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("StadiumName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MatchId");

                    b.HasIndex("CupId");

                    b.ToTable("Matches", (string)null);
                });

            modelBuilder.Entity("SoccerAPI.Models.MatchTeam", b =>
                {
                    b.Property<int>("MatchId")
                        .HasColumnType("int");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("MatchId", "TeamId", "Status");

                    b.HasIndex("TeamId");

                    b.ToTable("MatchTeam", (string)null);
                });

            modelBuilder.Entity("SoccerAPI.Models.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlayerId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("PlayerId");

                    b.HasIndex("TeamId");

                    b.ToTable("Players", (string)null);
                });

            modelBuilder.Entity("SoccerAPI.Models.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeamId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StadiumName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeamId");

                    b.ToTable("Teams", (string)null);
                });

            modelBuilder.Entity("SoccerAPI.Models.Coach", b =>
                {
                    b.HasOne("SoccerAPI.Models.Team", "Team")
                        .WithOne("Coach")
                        .HasForeignKey("SoccerAPI.Models.Coach", "TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("SoccerAPI.Models.CupTeam", b =>
                {
                    b.HasOne("SoccerAPI.Models.Cup", "Cup")
                        .WithMany("CupTeams")
                        .HasForeignKey("Cupid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoccerAPI.Models.Team", "Team")
                        .WithMany("CupTeams")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cup");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("SoccerAPI.Models.Match", b =>
                {
                    b.HasOne("SoccerAPI.Models.Cup", "Cup")
                        .WithMany("Matches")
                        .HasForeignKey("CupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cup");
                });

            modelBuilder.Entity("SoccerAPI.Models.MatchTeam", b =>
                {
                    b.HasOne("SoccerAPI.Models.Match", "Match")
                        .WithMany("MatchTeams")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoccerAPI.Models.Team", "Team")
                        .WithMany("MatchTeams")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Match");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("SoccerAPI.Models.Player", b =>
                {
                    b.HasOne("SoccerAPI.Models.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("SoccerAPI.Models.Cup", b =>
                {
                    b.Navigation("CupTeams");

                    b.Navigation("Matches");
                });

            modelBuilder.Entity("SoccerAPI.Models.Match", b =>
                {
                    b.Navigation("MatchTeams");
                });

            modelBuilder.Entity("SoccerAPI.Models.Team", b =>
                {
                    b.Navigation("Coach")
                        .IsRequired();

                    b.Navigation("CupTeams");

                    b.Navigation("MatchTeams");

                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
