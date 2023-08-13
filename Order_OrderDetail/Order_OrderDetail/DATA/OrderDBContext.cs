using Microsoft.EntityFrameworkCore;
using Order_OrderDetail.Entities;

namespace Order_OrderDetail.DATA
{
    public class OrderDBContext : DbContext
    {
        public OrderDBContext(DbContextOptions<OrderDBContext> options) : base(options) 
        { }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<OrderDetailEntity> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            modelBuilder.Entity<OrderDetailEntity>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(f => f.ID_ORDER)
                .IsRequired(); 
            
                
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<OrderEntity>()
        //        .HasMany(o => o.OrderDetails)
        //        .WithOne(od => od.Order)
        //        .HasForeignKey(f => f.ID_ORDER);

        //}
    }
}
