﻿// <auto-generated />
using EFSamurai.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFSamurai.Data.Migrations
{
    [DbContext(typeof(SamuraiDbContext))]
    [Migration("20210810085533_ImpementedSamuraiBattle")]
    partial class ImpementedSamuraiBattle
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFSamurai.Domain.Quote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("QuoteStyle")
                        .HasColumnType("int");

                    b.Property<int>("SamuraiId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SamuraiId");

                    b.ToTable("Quotes");
                });

            modelBuilder.Entity("EFSamurai.Domain.Samurai", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Samurais");
                });

            modelBuilder.Entity("EFSamurai.Domain.SamuraiBattle", b =>
                {
                    b.Property<int>("SamuraiId")
                        .HasColumnType("int");

                    b.Property<int>("BattleId")
                        .HasColumnType("int");

                    b.Property<string>("BattleProperties")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SamuraiId", "BattleId");

                    b.ToTable("SamuraiBattles");
                });

            modelBuilder.Entity("EFSamurai.Domain.SecretIdentity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RealName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SamuraiId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SamuraiId")
                        .IsUnique();

                    b.ToTable("SecretIdentities");
                });

            modelBuilder.Entity("EFSamurai.Domain.Quote", b =>
                {
                    b.HasOne("EFSamurai.Domain.Samurai", "Samurai")
                        .WithMany("Quotes")
                        .HasForeignKey("SamuraiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Samurai");
                });

            modelBuilder.Entity("EFSamurai.Domain.SamuraiBattle", b =>
                {
                    b.HasOne("EFSamurai.Domain.Samurai", "Samurai")
                        .WithMany()
                        .HasForeignKey("SamuraiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Samurai");
                });

            modelBuilder.Entity("EFSamurai.Domain.SecretIdentity", b =>
                {
                    b.HasOne("EFSamurai.Domain.Samurai", "Samurai")
                        .WithOne("SecretIdentity")
                        .HasForeignKey("EFSamurai.Domain.SecretIdentity", "SamuraiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Samurai");
                });

            modelBuilder.Entity("EFSamurai.Domain.Samurai", b =>
                {
                    b.Navigation("Quotes");

                    b.Navigation("SecretIdentity");
                });
#pragma warning restore 612, 618
        }
    }
}
