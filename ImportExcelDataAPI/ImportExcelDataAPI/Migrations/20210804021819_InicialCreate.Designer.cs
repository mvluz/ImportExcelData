// <auto-generated />
using System;
using ImportExcelDataAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ImportExcelDataAPI.Migrations
{
    [DbContext(typeof(APIContext))]
    [Migration("20210804021819_InicialCreate")]
    partial class InicialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ImportExcelDataAPI.Models.Import", b =>
                {
                    b.Property<int>("ImportID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedON")
                        .HasColumnType("datetime");

                    b.Property<string>("FileLocal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ImportID");

                    b.ToTable("Imports");
                });

            modelBuilder.Entity("ImportExcelDataAPI.Models.ImportItem", b =>
                {
                    b.Property<int>("ImportItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("date");

                    b.Property<int>("ImportID")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("UnitaryValue")
                        .HasColumnType("money");

                    b.HasKey("ImportItemID");

                    b.HasIndex("ImportID");

                    b.ToTable("ImportItems");
                });

            modelBuilder.Entity("ImportExcelDataAPI.Models.ImportItem", b =>
                {
                    b.HasOne("ImportExcelDataAPI.Models.Import", "Import")
                        .WithMany("ItemsList")
                        .HasForeignKey("ImportID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Import");
                });

            modelBuilder.Entity("ImportExcelDataAPI.Models.Import", b =>
                {
                    b.Navigation("ItemsList");
                });
#pragma warning restore 612, 618
        }
    }
}
