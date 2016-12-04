using Martijn.HouseInsight.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Martijn.HouseInsight.EntityFramework
{
    public class HouseInsightContext : DbContext
    {
        public HouseInsightContext() { }

        public HouseInsightContext(DbContextOptions<HouseInsightContext> options) : base(options) { }

        public DbSet<GeoPosition> GeoPositions { get; set; }

        public DbSet<ItemGroup> ItemGroups { get; set; }

        public DbSet<ItemPriority> ItemPriorities { get; set; }

        public DbSet<ItemType> ItemTypes { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Retail> Retails { get; set; }

        public DbSet<RetailProduct> RetailProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureGeoPosition(modelBuilder.Entity<GeoPosition>());
            ConfigureItemGroup(modelBuilder.Entity<ItemGroup>());
            ConfigureItemPriority(modelBuilder.Entity<ItemPriority>());
            ConfigureItemType(modelBuilder.Entity<ItemType>());
            ConfigureItemTypeRoom(modelBuilder.Entity<ItemTypeRoom>());
            ConfigureProduct(modelBuilder.Entity<Product>());
            ConfigureRoom(modelBuilder.Entity<Room>());
            ConfigureStoreChain(modelBuilder.Entity<Retail>());
            ConfigureStoreChainProduct(modelBuilder.Entity<RetailProduct>());
        }

        protected virtual void ConfigureGeoPosition(EntityTypeBuilder<GeoPosition> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Latitude).HasColumnType("decimal(15,12)").IsRequired();
            builder.Property(x => x.Longitude).HasColumnType("decimal(15,12)").IsRequired();
            builder.HasOne(x => x.Retail).WithMany(x => x.Locations);
        }

        protected virtual void ConfigureItemGroup(EntityTypeBuilder<ItemGroup> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(128).IsRequired();
        }

        protected virtual void ConfigureItemPriority(EntityTypeBuilder<ItemPriority> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(128).IsRequired();
        }

        protected virtual void ConfigureItemType(EntityTypeBuilder<ItemType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(128).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(256);
            builder.Property(x => x.RequiredAmount).HasDefaultValue(1);
            builder.Property(x => x.Obtained).HasDefaultValue(false);
            builder.HasOne(x => x.Group).WithMany(x => x.ItemTypes);
            builder.HasOne(x => x.Priority).WithMany(x => x.ItemTypes);
        }

        protected virtual void ConfigureItemTypeRoom(EntityTypeBuilder<ItemTypeRoom> builder)
        {
            builder.HasKey(x => new { x.ItemTypeId, x.RoomId });
            builder.HasOne(x => x.ItemType).WithMany(x => x.Rooms).HasForeignKey(x => x.ItemTypeId);
            builder.HasOne(x => x.Room).WithMany(x => x.ItemTypes).HasForeignKey(x => x.RoomId);
        }

        protected virtual void ConfigureProduct(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(128).IsRequired();
            builder.HasOne(x => x.ItemType).WithMany(x => x.Products);
        }

        protected virtual void ConfigureRoom(EntityTypeBuilder<Room> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(128).IsRequired();
        }

        protected virtual void ConfigureStoreChain(EntityTypeBuilder<Retail> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(128).IsRequired();
        }

        protected virtual void ConfigureStoreChainProduct(EntityTypeBuilder<RetailProduct> builder)
        {
            builder.HasKey(x => new { StoreChainId = x.RetailId, x.ProductId });
            builder.Property(x => x.Price).HasColumnType("money").IsRequired();
            builder.Property(x => x.Link).IsRequired();
            builder.Property(x => x.LastUpdated).HasDefaultValue("getutcdate()").IsRequired();
            builder.Property(x => x.IsDiscount).HasDefaultValue(false);
            builder.HasOne(x => x.Retail).WithMany(x => x.RetailProducts).HasForeignKey(x => x.RetailId);
            builder.HasOne(x => x.Product).WithMany(x => x.RetailProducts).HasForeignKey(x => x.ProductId);
        }
    }
}
