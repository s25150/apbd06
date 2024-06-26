using apbd06.Models;
using Microsoft.EntityFrameworkCore;

namespace apbd06.Context;

public class ApbdContext : DbContext
{
    public ApbdContext()
    {
        
    }

    public ApbdContext(DbContextOptions<ApbdContext> options)
        : base(options)
    {
        
    }
    
    /*protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Patient>()
            .HasMany(p => p.Prescriptions)
            .WithOne(pr => pr.Patient)
            .HasForeignKey(pr => pr.IdPatient);
        
        modelBuilder.Entity<Doctor>()
            .HasMany(p => p.Prescriptions)
            .WithOne(pr => pr.Doctor)
            .HasForeignKey(pr => pr.IdDoctor);
    }*/

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("data source=(localdb)\\Local;initial catalog=apbd06;trusted_connection=true");
    
    public DbSet<Medicament> Medicaments { get; set; }
    
    public DbSet<Patient> Patients { get; set; }
    
    public DbSet<Doctor> Doctors { get; set; }
    
    public DbSet<Prescription> Prescriptions { get; set; }
    
    public DbSet<PrescriptionMedicament> Prescription_Medicament { get; set; }
    
    
}