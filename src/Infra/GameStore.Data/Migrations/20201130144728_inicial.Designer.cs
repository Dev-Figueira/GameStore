﻿// <auto-generated />
using System;
using GameStore.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GameStore.Data.Migrations
{
    [DbContext(typeof(GameStoreDbContex))]
    [Migration("20201130144728_inicial")]
    partial class inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GameStore.Domain.Models.Amigo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Apelido")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(250)");

                    b.Property<Guid>("EmprestimoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("EmprestimoId")
                        .IsUnique();

                    b.ToTable("Amigos");
                });

            modelBuilder.Entity("GameStore.Domain.Models.Emprestimo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Emprestimos");
                });

            modelBuilder.Entity("GameStore.Domain.Models.Jogo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EmprestimoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("EmprestimoId");

                    b.ToTable("Jogos");
                });

            modelBuilder.Entity("GameStore.Domain.Models.Amigo", b =>
                {
                    b.HasOne("GameStore.Domain.Models.Emprestimo", "Emprestimo")
                        .WithOne("Amigo")
                        .HasForeignKey("GameStore.Domain.Models.Amigo", "EmprestimoId")
                        .IsRequired();
                });

            modelBuilder.Entity("GameStore.Domain.Models.Jogo", b =>
                {
                    b.HasOne("GameStore.Domain.Models.Emprestimo", "Emprestimo")
                        .WithMany("Jogos")
                        .HasForeignKey("EmprestimoId")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}