using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using QRScanner_API.DAL;

namespace QRScannerAPI.Migrations
{
    [DbContext(typeof(APIDataContext))]
    [Migration("20161213224418_ModelsAdded")]
    partial class ModelsAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("QRScanner_API.Models.ItemQR", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AssignedDate");

                    b.Property<DateTime?>("EndDate");

                    b.Property<int>("OwnerID");

                    b.Property<int>("ProductID");

                    b.Property<string>("SerialNumber");

                    b.HasKey("ID");

                    b.ToTable("ItemQRs");
                });

            modelBuilder.Entity("QRScanner_API.Models.Location", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("ID");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("QRScanner_API.Models.Office", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("Description");

                    b.Property<string>("State");

                    b.HasKey("ID");

                    b.ToTable("Offices");
                });

            modelBuilder.Entity("QRScanner_API.Models.Owner", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("LocationID");

                    b.Property<int>("Name");

                    b.Property<int>("OfficeID");

                    b.HasKey("ID");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("QRScanner_API.Models.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Brand");

                    b.Property<string>("Model");

                    b.Property<int>("OfficeId");

                    b.Property<int>("Quantity");

                    b.Property<string>("Type");

                    b.HasKey("ID");

                    b.ToTable("Products");
                });
        }
    }
}
