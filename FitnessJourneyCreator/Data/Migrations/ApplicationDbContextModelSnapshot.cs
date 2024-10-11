﻿// <auto-generated />
using System;
using FitnessJourneyCreator.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FitnessJourneyCreator.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FitnessJourneyCreator.Models.Exercise", b =>
                {
                    b.Property<int>("ExerciseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExerciseId"));

                    b.Property<string>("DemostrationLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExerciseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExerciseId");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("FitnessJourneyCreator.Models.Log", b =>
                {
                    b.Property<int>("LogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LogId"));

                    b.Property<DateTime>("DateLogged")
                        .HasColumnType("datetime2");

                    b.Property<int>("RepsCompleted")
                        .HasColumnType("int");

                    b.Property<decimal?>("Weight")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<int>("WorkoutExerciseId")
                        .HasColumnType("int");

                    b.HasKey("LogId");

                    b.HasIndex("WorkoutExerciseId");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("FitnessJourneyCreator.Models.Macrocycle", b =>
                {
                    b.Property<int>("MacrocycleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MacrocycleId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MacrocycleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("WorkoutPlanId")
                        .HasColumnType("int");

                    b.HasKey("MacrocycleId");

                    b.HasIndex("WorkoutPlanId");

                    b.ToTable("Macrocycles");
                });

            modelBuilder.Entity("FitnessJourneyCreator.Models.Mesocycle", b =>
                {
                    b.Property<int>("MesocycleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MesocycleId"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MacrocycleId")
                        .HasColumnType("int");

                    b.Property<string>("MesocycleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("MesocycleId");

                    b.HasIndex("MacrocycleId");

                    b.ToTable("Mesocycles");
                });

            modelBuilder.Entity("FitnessJourneyCreator.Models.Microcycle", b =>
                {
                    b.Property<int>("MicrocycleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MicrocycleId"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MesocycleId")
                        .HasColumnType("int");

                    b.Property<string>("MicrocycleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("MicrocycleId");

                    b.HasIndex("MesocycleId");

                    b.ToTable("Microcycles");
                });

            modelBuilder.Entity("FitnessJourneyCreator.Models.Workout", b =>
                {
                    b.Property<int>("WorkoutId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WorkoutId"));

                    b.Property<int>("MicrocycleId")
                        .HasColumnType("int");

                    b.Property<int>("WorkoutDay")
                        .HasColumnType("int");

                    b.Property<string>("WorkoutName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WorkoutId");

                    b.HasIndex("MicrocycleId");

                    b.ToTable("Workouts");
                });

            modelBuilder.Entity("FitnessJourneyCreator.Models.WorkoutExercise", b =>
                {
                    b.Property<int>("WorkoutExerciseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WorkoutExerciseId"));

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<int>("Reps")
                        .HasColumnType("int");

                    b.Property<int>("Sets")
                        .HasColumnType("int");

                    b.Property<int>("WorkoutId")
                        .HasColumnType("int");

                    b.HasKey("WorkoutExerciseId");

                    b.HasIndex("ExerciseId")
                        .IsUnique();

                    b.HasIndex("WorkoutId");

                    b.ToTable("WorkoutExercises");
                });

            modelBuilder.Entity("FitnessJourneyCreator.Models.WorkoutPlan", b =>
                {
                    b.Property<int>("WorkoutPlanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WorkoutPlanId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("PlanDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlanName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WorkoutPlanId");

                    b.ToTable("WorkoutPlans");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("FitnessJourneyCreator.Models.Log", b =>
                {
                    b.HasOne("FitnessJourneyCreator.Models.WorkoutExercise", "WorkoutExercise")
                        .WithMany("Logs")
                        .HasForeignKey("WorkoutExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WorkoutExercise");
                });

            modelBuilder.Entity("FitnessJourneyCreator.Models.Macrocycle", b =>
                {
                    b.HasOne("FitnessJourneyCreator.Models.WorkoutPlan", "WorkoutPlan")
                        .WithMany("Macrocycles")
                        .HasForeignKey("WorkoutPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WorkoutPlan");
                });

            modelBuilder.Entity("FitnessJourneyCreator.Models.Mesocycle", b =>
                {
                    b.HasOne("FitnessJourneyCreator.Models.Macrocycle", "Macrocycle")
                        .WithMany("Mesocycles")
                        .HasForeignKey("MacrocycleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Macrocycle");
                });

            modelBuilder.Entity("FitnessJourneyCreator.Models.Microcycle", b =>
                {
                    b.HasOne("FitnessJourneyCreator.Models.Mesocycle", "Mesocycle")
                        .WithMany("Microcycles")
                        .HasForeignKey("MesocycleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mesocycle");
                });

            modelBuilder.Entity("FitnessJourneyCreator.Models.Workout", b =>
                {
                    b.HasOne("FitnessJourneyCreator.Models.Microcycle", "Microcycle")
                        .WithMany("Workouts")
                        .HasForeignKey("MicrocycleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Microcycle");
                });

            modelBuilder.Entity("FitnessJourneyCreator.Models.WorkoutExercise", b =>
                {
                    b.HasOne("FitnessJourneyCreator.Models.Exercise", "Exercise")
                        .WithOne("workoutExercise")
                        .HasForeignKey("FitnessJourneyCreator.Models.WorkoutExercise", "ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitnessJourneyCreator.Models.Workout", "Workout")
                        .WithMany("WorkoutExercises")
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FitnessJourneyCreator.Models.Exercise", b =>
                {
                    b.Navigation("workoutExercise");
                });

            modelBuilder.Entity("FitnessJourneyCreator.Models.Macrocycle", b =>
                {
                    b.Navigation("Mesocycles");
                });

            modelBuilder.Entity("FitnessJourneyCreator.Models.Mesocycle", b =>
                {
                    b.Navigation("Microcycles");
                });

            modelBuilder.Entity("FitnessJourneyCreator.Models.Microcycle", b =>
                {
                    b.Navigation("Workouts");
                });

            modelBuilder.Entity("FitnessJourneyCreator.Models.Workout", b =>
                {
                    b.Navigation("WorkoutExercises");
                });

            modelBuilder.Entity("FitnessJourneyCreator.Models.WorkoutExercise", b =>
                {
                    b.Navigation("Logs");
                });

            modelBuilder.Entity("FitnessJourneyCreator.Models.WorkoutPlan", b =>
                {
                    b.Navigation("Macrocycles");
                });
#pragma warning restore 612, 618
        }
    }
}
