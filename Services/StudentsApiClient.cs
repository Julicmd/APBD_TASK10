using System.Net.Http.Json;
using StudentPanel.DTOs;

namespace StudentPanel.Services;

public class StudentsApiClient(HttpClient http)
{
    public async Task<List<StudentDto>> GetStudentsAsync()
        => await http.GetFromJsonAsync<List<StudentDto>>("/api/students") ?? [];

    public async Task<StudentDto?> GetStudentAsync(int id)
        => await http.GetFromJsonAsync<StudentDto>($"/api/students/{id}");

    public async Task<List<CourseDto>> GetStudentCoursesAsync(int studentId)
        => await http.GetFromJsonAsync<List<CourseDto>>($"/api/students/{studentId}/courses") ?? [];

    public async Task<List<CourseDto>> GetCoursesAsync()
        => await http.GetFromJsonAsync<List<CourseDto>>("/api/courses") ?? [];

    public async Task<StudentDto?> CreateStudentAsync(CreateStudentRequest request)
    {
        var response = await http.PostAsJsonAsync("/api/students", request);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<StudentDto>();
    }

    public async Task AssignCourseAsync(int studentId, AssignStudentCourseRequest request)
    {
        var response = await http.PostAsJsonAsync($"/api/students/{studentId}/courses", request);
        response.EnsureSuccessStatusCode();
    }
}
