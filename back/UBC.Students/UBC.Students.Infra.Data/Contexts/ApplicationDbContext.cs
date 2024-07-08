using CsvHelper;
using Microsoft.EntityFrameworkCore;
using System.Formats.Asn1;
using System.Globalization;
using UBC.Students.Domain.Entities;

namespace UBC.Students.Infra.Data.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentMap());
        }

        public void LoadDataStudentsFromCsv(string filePath)
        {
            var config = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
            {
                MissingFieldFound = null,
                HeaderValidated = null
            };

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, config))
            {
                var records = csv.GetRecords<Student>();
                Students.AddRange(records);
                SaveChanges();
            }
        }

        public void LoadDataUsersFromCsv(string filePath)
        {
            var config = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
            {
                MissingFieldFound = null,
                HeaderValidated = null
            };

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, config))
            {
                var records = csv.GetRecords<User>();
                Users.AddRange(records);
                SaveChanges();
            }
        }
    }
}
