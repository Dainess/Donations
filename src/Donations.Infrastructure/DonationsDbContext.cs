using Donations.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Donations.Infrastructure;

public class DonationsDbContext : DbContext
{
    public DbSet<Donor> Donors { get; set; }
    //public DbSet<Pledge> Pledges { get; set; }
    //public DbSet<Payment> Payments { get; set; }
    public DbSet<Change> Changelog { get; set; }
    //public DbSet<PledgePayment> PledgesPayments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        try
        {
            var connectionString = "server=localhost;user=root;password=dainess1942;database=donations";
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 36));

            optionsBuilder.UseMySql(connectionString, serverVersion);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    //06 meteu essa função aqui pq ele disse que ela é suficiente pra trabalhar com Activity via Trips
    //mas por causa de um bug específico do SQLite podia remover e a gente ia ter que criar um DBSet
    //de activities. Deixei só pra ter o código no registro
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //modelBuilder.Entity<Activity>().ToTable("Activities");
    }
}