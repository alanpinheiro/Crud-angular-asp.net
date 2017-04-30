namespace WebApplication2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModeloDados2 : DbContext
    {
        public ModeloDados2()
            : base("name=ModeloDados2")
        {
        }

        public virtual DbSet<alunos> alunos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<alunos>()
                .Property(e => e.nome)
                .IsFixedLength();

            modelBuilder.Entity<alunos>()
                .Property(e => e.email)
                .IsFixedLength();

            modelBuilder.Entity<alunos>()
                .Property(e => e.sexo)
                .IsFixedLength();
        }
    }
}
