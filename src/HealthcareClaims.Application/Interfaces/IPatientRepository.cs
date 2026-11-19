using HealthcareClaims.Domain.Entities;

namespace HealthcareClaims.Application.Interfaces;

public interface IPatientRepository
{
    Task AddAsync(Patient patient);

    Task<Patient?> GetByIdAsync(int patientId);

    Task<IEnumerable<Patient>> GetAllAsync();
}