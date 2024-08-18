using Donations.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Donations.Infrastructure;

public class JourneyDbContext : DbContext
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
            string baseDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) 
                ?? throw new Exception("Directory path does not contain a valid database");
            string upperDirectory = baseDirectory.Replace("src\\Journey.Api\\bin\\Debug\\net8.0", "");
            string dbPath = Path.Combine(upperDirectory, "JourneyDatabase.db");
            //optionsBuilder.UseSqlite($"Data Source={dbPath}");
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