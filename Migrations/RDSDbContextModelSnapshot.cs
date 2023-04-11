﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace INTEX2.Migrations
{
    [DbContext(typeof(RDSDbContext))]
    partial class RDSDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("INTEX2.Models.Mummy", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("AdultSubadult")
                        .HasColumnType("text");

                    b.Property<string>("AgeAtDeath")
                        .HasColumnType("text");

                    b.Property<string>("Area")
                        .HasColumnType("text");

                    b.Property<string>("BurialId")
                        .HasColumnType("text");

                    b.Property<string>("BurialMaterials")
                        .HasColumnType("text");

                    b.Property<string>("BurialNumber")
                        .HasColumnType("text");

                    b.Property<string>("ClusterNumber")
                        .HasColumnType("text");

                    b.Property<string>("DataExpertInitials")
                        .HasColumnType("text");

                    b.Property<string>("DateOfExcavation")
                        .HasColumnType("text");

                    b.Property<string>("Depth")
                        .HasColumnType("text");

                    b.Property<string>("EastWest")
                        .HasColumnType("text");

                    b.Property<string>("ExcavationRecorder")
                        .HasColumnType("text");

                    b.Property<string>("FaceBundles")
                        .HasColumnType("text");

                    b.Property<string>("FieldBookExcavationYear")
                        .HasColumnType("text");

                    b.Property<string>("FieldBookPage")
                        .HasColumnType("text");

                    b.Property<string>("Goods")
                        .HasColumnType("text");

                    b.Property<string>("Hair")
                        .HasColumnType("text");

                    b.Property<string>("HairColor")
                        .HasColumnType("text");

                    b.Property<string>("HeadDirection")
                        .HasColumnType("text");

                    b.Property<string>("Length")
                        .HasColumnType("text");

                    b.Property<string>("NorthSouth")
                        .HasColumnType("text");

                    b.Property<string>("Photos")
                        .HasColumnType("text");

                    b.Property<string>("Preservation")
                        .HasColumnType("text");

                    b.Property<string>("SamplesCollected")
                        .HasColumnType("text");

                    b.Property<string>("Sex")
                        .HasColumnType("text");

                    b.Property<string>("ShaftNumber")
                        .HasColumnType("text");

                    b.Property<string>("SouthToFeet")
                        .HasColumnType("text");

                    b.Property<string>("SouthToHead")
                        .HasColumnType("text");

                    b.Property<string>("SquareEastWest")
                        .HasColumnType("text");

                    b.Property<string>("SquareNorthSouth")
                        .HasColumnType("text");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.Property<string>("WestToFeet")
                        .HasColumnType("text");

                    b.Property<string>("WestToHead")
                        .HasColumnType("text");

                    b.Property<string>("Wrapping")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Mummies");
                });
#pragma warning restore 612, 618
        }
    }
}