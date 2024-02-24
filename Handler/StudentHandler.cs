using studentregestration.Helper;
using studentregestration.Models;
using studentregestration.Repository;

namespace studentregestration.Handler
{
    public class StudentHandler :IStudentHandler
    {
        private readonly IStudentRepository _repository;

        public StudentHandler(IStudentRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Student>> GetAllStudentsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveStudentAsync(StudentRquestModel model)
        {
            throw new NotImplementedException();
        }

        //public async Task<List<Student>> GetAllStudentsAsync()
        //{
        //   return await _repository.GetAllAsync();
        //}

        // public async Task<int> SaveStudentAsync(StudentRquestModel model)
        //{
        //    return await _repository.AddAsync(new Student
        //    {
        //        FirstName = model.FirstName,
        //        LastName = model.LastName,
        //        PhoneNumber = model.PhoneNumber,
        //        EmailId = model.EmailId,
        //        ClassIds = model.ClassIds
        //    });
        //}
    }
    
}
