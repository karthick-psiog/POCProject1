namespace ORM.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class POCContext : DbContext
    {
        public POCContext() : base("name=POCContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
