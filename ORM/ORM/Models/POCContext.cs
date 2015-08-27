namespace ORM.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public partial class POCContext : DbContext
    {
        public POCContext() : base("name=POCContext")
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<ServiceArea> ServiceArea { get; set; }
        public DbSet<EventType> EventType { get; set; }
        public DbSet<AuditLog> AuditLog { get; set; }
        public DbSet<EmailLog> EmailLog { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
