// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backend.Data;

namespace backend.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.14");

            modelBuilder.Entity("backend.Models.Car", b =>
                {
                    b.Property<int>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("WarehouseId")
                        .HasColumnType("TEXT");

                    b.Property<string>("date_added")
                        .HasColumnType("TEXT");

                    b.Property<bool>("licensed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("make")
                        .HasColumnType("TEXT");

                    b.Property<string>("model")
                        .HasColumnType("TEXT");

                    b.Property<double>("price")
                        .HasColumnType("REAL");

                    b.Property<int>("year_model")
                        .HasColumnType("INTEGER");

                    b.HasKey("_id");

                    b.HasIndex("WarehouseId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("backend.Models.Database.Location", b =>
                {
                    b.Property<string>("lat")
                        .HasColumnType("TEXT");

                    b.Property<string>("long")
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .HasColumnType("TEXT");

                    b.HasKey("lat", "long");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("backend.Models.Warehouse", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Locationlat")
                        .HasColumnType("TEXT");

                    b.Property<string>("Locationlong")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Locationlat", "Locationlong");

                    b.ToTable("Warehouses");
                });

            modelBuilder.Entity("backend.Models.Car", b =>
                {
                    b.HasOne("backend.Models.Warehouse", null)
                        .WithMany("Cars")
                        .HasForeignKey("WarehouseId");
                });

            modelBuilder.Entity("backend.Models.Warehouse", b =>
                {
                    b.HasOne("backend.Models.Database.Location", "Location")
                        .WithMany()
                        .HasForeignKey("Locationlat", "Locationlong");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("backend.Models.Warehouse", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
