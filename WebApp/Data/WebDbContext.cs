using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebApp.Data {
    public partial class WebDbContext : DbContext {
        public WebDbContext()
            : base("name=WebDbContext") {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Candidate> Candidates { get; set; }
        public virtual DbSet<Certificate> Certificates { get; set; }
        public virtual DbSet<CertificateTitle> CertificateTitles { get; set; }
        public virtual DbSet<CertificateTopic> CertificateTopics { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
        }
    }
}
