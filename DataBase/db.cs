using Microsoft.EntityFrameworkCore;
using porthealthvis.Models;

namespace porthealthvis.DataBase
{
    public class DbnewContext : DbContext
    {
        public DbnewContext(DbContextOptions options) : base(options)
        {
        }
        //public DbSet<Appoinment> Appoinments { get; set; }
        public DbSet<NewAppointMent> NewAppoinments { get; set; }
        public DbSet<TrasactionModel> Transaction { get; set; }
        public DbSet<NotificationModel> Notification { get; set; }

    
        //public DbSet<ResponseModel> Success { get; set; }
        //public DbSet<TransactionDetails> TransactionHistory { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<TrasactionModel>()
              .HasIndex(p => p.TransactionID)
              .IsUnique();

            modelBuilder.Entity<NewAppointMent>()
              .HasIndex(p => p.TransactionID)
              .IsUnique();

        }
    }
}
