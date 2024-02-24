using studentregestration.Models;
using System.Data.Entity;

namespace studentregestration.Repository
{
    public class StudentRepository:IStudentRepository
    {
        private readonly Connectionsetting _context;

        public StudentRepository(Connectionsetting context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<int> AddAsync(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student.Id;
        }
    }

}

