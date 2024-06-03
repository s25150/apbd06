using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apbd06.Models;

public class Prescription
{
    [Key]
    public int IdPrescription { get; set; }
    
    public DateTime Date { get; set; }
    
    public DateTime DueDate { get; set; }
    
    public int IdPatientPrescription { get; set; }
    
    public int IdDoctorPrescription { get; set; }
    
    [ForeignKey(nameof(IdPatientPrescription))]
    public ICollection<Patient> Patients { get; set; }
    
    [ForeignKey(nameof(IdDoctorPrescription))]
    public ICollection<Doctor> Doctors { get; set; }
}