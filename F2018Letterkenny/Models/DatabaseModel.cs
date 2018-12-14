namespace F2018Letterkenny.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DatabaseModel : DbContext
    {
        public DatabaseModel()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<Character> Characters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Character>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Character>()
                .Property(e => e.Photo)
                .IsUnicode(false);

            modelBuilder.Entity<Character>()
                .Property(e => e.Quote)
                .IsUnicode(false);
        }
    }
}
