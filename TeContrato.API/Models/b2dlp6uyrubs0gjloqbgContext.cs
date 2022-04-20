using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Supermarket.API.Models
{
    public partial class b2dlp6uyrubs0gjloqbgContext : DbContext
    {
        public b2dlp6uyrubs0gjloqbgContext()
        {
        }

        public b2dlp6uyrubs0gjloqbgContext(DbContextOptions<b2dlp6uyrubs0gjloqbgContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=b2dlp6uyrubs0gjloqbg-mysql.services.clever-cloud.com;port=3306;database=b2dlp6uyrubs0gjloqbg;uid=uo2kpwbhggtt8caa;password=jxa3cXiJUyrmw9MmiOsj", Microsoft.EntityFrameworkCore.ServerVersion.FromString("8.0.22-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
