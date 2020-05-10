﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VocabularyBuilder.Data;

namespace VocabularyBuilder.Data.Migrations
{
    [DbContext(typeof(VocabularyBuilderContext))]
    [Migration("20200510031330_AddingTypeCards")]
    partial class AddingTypeCards
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VocabularyBuilder.Domain.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnName("Description")
                        .HasColumnType("varchar(100)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("VocabularyBuilder.Domain.Entities.FlashCard", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("TypeCardId")
                        .HasColumnType("int");

                    b.Property<string>("Example")
                        .HasColumnType("varchar(1000)");

                    b.Property<DateTime?>("FlashCardDate")
                        .HasColumnType("datetime");

                    b.Property<byte[]>("FlashCardPicture")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("MainWord")
                        .HasColumnType("varchar(50)");

                    b.Property<int>("MeaningId")
                        .HasColumnType("int");

                    b.HasKey("CategoryId", "TypeCardId");

                    b.HasIndex("MeaningId")
                        .IsUnique();

                    b.HasIndex("TypeCardId");

                    b.ToTable("FlashCards");
                });

            modelBuilder.Entity("VocabularyBuilder.Domain.Entities.Meaning", b =>
                {
                    b.Property<int>("MeaningId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("varchar(100)");

                    b.HasKey("MeaningId");

                    b.ToTable("Meanings");
                });

            modelBuilder.Entity("VocabularyBuilder.Domain.Entities.TypeCard", b =>
                {
                    b.Property<int>("TypeCardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("varchar(100)");

                    b.HasKey("TypeCardId");

                    b.ToTable("TypeCards");
                });

            modelBuilder.Entity("VocabularyBuilder.Domain.Entities.FlashCard", b =>
                {
                    b.HasOne("VocabularyBuilder.Domain.Entities.Category", "Category")
                        .WithMany("FlashCards")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_FlashCard_Category")
                        .IsRequired();

                    b.HasOne("VocabularyBuilder.Domain.Entities.Meaning", "Meaning")
                        .WithOne("FlashCard")
                        .HasForeignKey("VocabularyBuilder.Domain.Entities.FlashCard", "MeaningId")
                        .HasConstraintName("FK_FlashCard_Meaning")
                        .IsRequired();

                    b.HasOne("VocabularyBuilder.Domain.Entities.TypeCard", "TypeCard")
                        .WithMany("FlashCards")
                        .HasForeignKey("TypeCardId")
                        .HasConstraintName("FK_FlashCard_TypeCard")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
