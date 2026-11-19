using HealthcareClaims.Application.Interfaces;
using HealthcareClaims.Domain.Entities;
using HealthcareClaims.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace HealthcareClaims.Infrastructure.Repositories.Patients;

public class PatientRepository : IPatientRepository
{

    private readonly HealthcareClaimsDbContext _context;
    public PatientRepository(HealthcareClaimsDbContext context)
    {
        _context =context;
    }

    public async Task AddAsync(Patient patient)
    {
        await _context.Patients.AddAsync(patient);
        await _context.SaveChangesAsync();
    }

    public  async Task<IEnumerable<Patient>> GetAllAsync()
    {
        return await _context.Patients.ToListAsync();
    }

    public async Task<Patient?> GetByIdAsync(int patientId)
    {
        return await _context.Patients.FindAsync(patientId);
    }
}
