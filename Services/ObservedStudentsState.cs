using StudentPanel.DTOs;

namespace StudentPanel.Services;

public class ObservedStudentsState
{
    private readonly List<StudentDto> _observed = [];

    public IReadOnlyList<StudentDto> Observed => _observed.AsReadOnly();
    public int Count => _observed.Count;

    public event Action? OnChange;

    public bool IsObserved(int studentId) => _observed.Any(s => s.Id == studentId);

    public void Add(StudentDto student)
    {
        if (!IsObserved(student.Id))
        {
            _observed.Add(student);
            OnChange?.Invoke();
        }
    }

    public void Remove(int studentId)
    {
        var student = _observed.FirstOrDefault(s => s.Id == studentId);
        if (student is not null)
        {
            _observed.Remove(student);
            OnChange?.Invoke();
        }
    }
}