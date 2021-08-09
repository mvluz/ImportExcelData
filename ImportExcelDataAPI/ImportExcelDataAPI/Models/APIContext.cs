using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImportExcelDataAPI.Models
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<FileUpload>(
                    eb =>
                    {
                        eb.HasNoKey();
                    });

            modelBuilder
            .Entity<FileUploadError>(
                eb =>
                {
                    eb.HasNoKey();
                    });

            modelBuilder
            .Entity<FileUploadSave>(
             eb =>
             {
                    eb.HasNoKey();
                 });
        }

        public DbSet<Import> Imports { get; set; }
        public DbSet<ImportItem> ImportItems { get; set; }
        public DbSet<FileUpload> FileUpload { get; set; }
        public DbSet<FileUploadError> FileUploadError { get; set; }
        public DbSet<FileUploadSave> FileUploadSave { get; set; }


    }
}
