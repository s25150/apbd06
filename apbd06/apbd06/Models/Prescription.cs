using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apbd06.Models;

public class Prescription
{
    [Key]
    public int IdPrescription { get; set; }
    
    public DateTime Date { get; set; }
    
    public DateTime DueDate { get; set; }
    
    public int IdPatient { get; set; }
    
    public int IdDoctor { get; set; }
    
    [ForeignKey(nameof(IdPatient))]
    public Patient Patient { get; set; }
    
    [ForeignKey(nameof(IdDoctor))]
    public Doctor Doctor { get; set; }
    /*[ForeignKey(nameof(IdPatient))]
    public ICollection<Patient> Patients { get; set; }
    
    [ForeignKey(nameof(IdDoctor))]
    public ICollection<Doctor> Doctors { get; set; }*/

    /*public Patient Patients { get; set; }
    public Doctor Doctors { get; set; }*/

}