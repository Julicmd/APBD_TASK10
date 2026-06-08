using StudentPanel.DTOs;

namespace StudentPanel.Controller;

public class StudentController
{
    private static readonly List<StudentDto> Students = new()
    {
        new() { Id = 1, IndexNumber = "s12345", FirstName = "Anna",  LastName = "Kowalska",   Email = "anna@example.com",  Semester = 3 },
        new() { Id = 2, IndexNumber = "s12346", FirstName = "Piotr", LastName = "Nowak",      Email = "piotr@example.com", Semester = 5 },
        new() { Id = 3, IndexNumber = "s12347", FirstName = "Maria", LastName = "Wisniewska", Email = "maria@example.com", Semester = 2 },
    };

    private static readonly List<CourseDto> Courses = new()
    {
        new() { Id = 1, Name = "Programming in C#", Ects = 6 },
        new() { Id = 2, Name = "Web Applications",  Ects = 5 },
        new() { Id = 3, Name = "Databases",         Ects = 4 },
    };

    private static readonly List<StudentCourseDto> Assignments = new()
    {
        new() { StudentId = 1, CourseId = 1, AssignedAt = DateTime.UtcNow.AddDays(-10) }
    };


    public static void MapEndpoints(WebApplication app)
    {
        app.MapGet("/api/students", () => Results.Ok(Students));
        
        app.MapGet("/api/students/{id:int}", (int id) =>
        {
            var student = Students.FirstOrDefault(s => s.Id == id);
            return student is null ? Results.NotFound() : Results.Ok(student);
        });

        app.MapGet("/api/students/{id:int}/courses", (int id) =>
        {
            if (Students.All(s => s.Id != id)) return Results.NotFound();
            var list = Assignments
                .Where(a => a.StudentId == id)
                .Join(Courses, a => a.CourseId, c => c.Id, (_, c) => c)
                .ToList();
            return Results.Ok(list);
        });

    }
    
}