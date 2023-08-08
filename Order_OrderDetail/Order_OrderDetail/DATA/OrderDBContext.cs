using Microsoft.EntityFrameworkCore;
using Order_OrderDetail.Entities;

namespace Order_OrderDetail.DATA
{
    public class OrderDBContext : DbContext
    {
        public OrderDBContext(DbContextOptions<OrderDBContext> options) : base(options) 
        { }
        public DbSet<OrderEntity> Order { get; set; }
        public DbSet<OrderDetailEntity> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetailEntity>()
                .HasOne(o => o.Order)
                .WithMany(od => od.OrderDetails)
                .HasForeignKey(f => f.ID_ORDER);
                
        }
    }
}
