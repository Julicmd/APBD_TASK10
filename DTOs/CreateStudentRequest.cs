using System.ComponentModel.DataAnnotations;

namespace StudentPanel.DTOs;

public class CreateStudentRequest
{
    [Required(ErrorMessage = "Index number is required.")]
    public string IndexNumber { get; set; } = string.Empty;

    [Required(ErrorMessage = "First name is required.")]
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Semester is required.")]
    [Range(1, 8, ErrorMessage = "Semester must be between 1 and 8.")]
    public int Semester { get; set; } = 1;
}