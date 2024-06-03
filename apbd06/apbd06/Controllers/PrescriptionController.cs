using apbd06.Context;
using apbd06.Models;
using apbd06.RequestModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apbd06.Controllers;


[Route("api/prescriptions")]
[ApiController]
public class PrescriptionController : ControllerBase
{
    
    private readonly ApbdContext _context;

    public PrescriptionController(ApbdContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> AssignClientToTrip(int idDoctor, AssignPrescriptionModel apm)
    {
        //var dbContext = new ApbdContext();

        var newAssignPrescription = new AssignPrescriptionModel()
        {
            IdPatient = apm.IdPatient,
            FirstName = apm.FirstName,
            LastName = apm.LastName,
            Birthdate = apm.Birthdate,
            IdMedicament = apm.IdMedicament,
            Name = apm.Name,
            Description = apm.Description,
            Date = apm.Date,
            DueDate = apm.DueDate
        };

        var patientExists = await _context.Patients.AnyAsync(p => p.IdPatient == newAssignPrescription.IdPatient);
        if (!patientExists)
        {
            var newPatient = new Patient()
            {
                FirstName = newAssignPrescription.FirstName,
                LastName = newAssignPrescription.LastName,
                Birthdate = newAssignPrescription.Birthdate,
            };
            await _context.Patients.AddAsync(newPatient);
        }

        var medicamentExists = await _context.Medicaments
            .AllAsync(m => m.IdMedicament == newAssignPrescription.IdMedicament
                           && m.Name == newAssignPrescription.Name
                           && m.Description == newAssignPrescription.Description);

        if (!medicamentExists)
        {
            return BadRequest("Podany lek nie istnieje");
        }

        if (newAssignPrescription.DueDate < newAssignPrescription.Date)
        {
            return BadRequest("Data ważności jest niepoprawna");
        }

        var newPrescription = new Prescription()
        {
            Date = newAssignPrescription.Date,
            DueDate = newAssignPrescription.DueDate,
            IdPatient = newAssignPrescription.IdPatient,
            IdDoctor = idDoctor
        };

        var addPrescription = await _context.Prescriptions.AddAsync(newPrescription);
        
        await _context.SaveChangesAsync();
        
        return Ok();
    }
}