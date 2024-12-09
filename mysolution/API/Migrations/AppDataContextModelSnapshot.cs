﻿// <auto-generated />
using System;
using API.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(AppDataContext))]
    partial class AppDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("API.models.Aluno", b =>
                {
                    b.Property<int>("AlunoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("AlunoId");

                    b.ToTable("alunos");
                });

            modelBuilder.Entity("API.models.IMC", b =>
                {
                    b.Property<int>("IMCId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AlunoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Classificacao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("TEXT");

                    b.Property<double>("ValorIMC")
                        .HasColumnType("REAL");

                    b.Property<double>("altura")
                        .HasColumnType("REAL");

                    b.Property<double>("peso")
                        .HasColumnType("REAL");

                    b.HasKey("IMCId");

                    b.HasIndex("AlunoId");

                    b.ToTable("IMCs");
                });

            modelBuilder.Entity("API.models.IMC", b =>
                {
                    b.HasOne("API.models.Aluno", "Aluno")
                        .WithMany("iMCs")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");
                });

            modelBuilder.Entity("API.models.Aluno", b =>
                {
                    b.Navigation("iMCs");
                });
#pragma warning restore 612, 618
        }
    }
}