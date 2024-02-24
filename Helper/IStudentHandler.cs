using studentregestration.Models;

namespace studentregestration.Helper
{
    public interface IStudentHandler
    {
        Task<List<Student>> GetAllStudentsAsync();
        Task<int> SaveStudentAsync(StudentRquestModel model);
    }
}