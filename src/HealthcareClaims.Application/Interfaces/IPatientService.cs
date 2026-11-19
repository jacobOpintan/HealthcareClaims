using HealthcareClaims.Application.DTOs.Patients;

namespace HealthcareClaims.Application.Interfaces;

public interface IPatientService
{
    Task<PatientResponseDto> CreatePatientAsync(CreatePatientDto patientDto);
    Task<PatientResponseDto?> GetPatientByIdAsync(int patientId);
    Task<IEnumerable<PatientResponseDto>> GetAllPatientsAsync();
}
