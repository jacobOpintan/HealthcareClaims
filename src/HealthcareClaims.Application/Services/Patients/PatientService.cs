using HealthcareClaims.Application.DTOs.Patients;
using HealthcareClaims.Application.Interfaces;
using HealthcareClaims.Domain.Entities;

namespace HealthcareClaims.Application.Services.Patients;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _patientRepository;

    public PatientService(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<PatientResponseDto> CreatePatientAsync(
        CreatePatientDto patientDto)
    {
        var patient = new Patient
        {
            FirstName = patientDto.FirstName,
            LastName = patientDto.LastName,
            DateOfBirth = DateOnly.FromDateTime(patientDto.DateOfBirth),
            Gender = patientDto.Gender,
            PhoneNumber = patientDto.PhoneNumber,
            Email = patientDto.Email,
            Address = patientDto.Address,
            CreatedAt = DateTime.UtcNow
        };

        await _patientRepository.AddAsync(patient);

        return MapToResponseDto(patient);
    }

    public async Task<PatientResponseDto?> GetPatientByIdAsync(int patientId)
    {
        var patient = await _patientRepository.GetByIdAsync(patientId);

        if (patient == null)
        {
            return null;
        }

        return MapToResponseDto(patient);
    }

    public async Task<IEnumerable<PatientResponseDto>> GetAllPatientsAsync()
    {
        var patients = await _patientRepository.GetAllAsync();

        return patients.Select(MapToResponseDto).ToList();
    }

    private static PatientResponseDto MapToResponseDto(Patient patient)
    {
        return new PatientResponseDto
        {
            PatientId = patient.PatientId,
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            DateOfBirth = patient.DateOfBirth.ToDateTime(TimeOnly.MinValue),
            Gender = patient.Gender,
            PhoneNumber = patient.PhoneNumber,
            Email = patient.Email,
            Address = patient.Address,
            CreatedAt = patient.CreatedAt
        };
    }
}