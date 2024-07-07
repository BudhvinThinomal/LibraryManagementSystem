using LibraryManagementSystem.Models.Entities;
using LibraryManagementSystem.Repository;

namespace LibraryManagementSystem.Service
{
    public class StudentService
    {
        private readonly StudentRepository _studentRepository;

        public StudentService(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        //Get All Students
        public List<StudentModel> GetAllStudents()
        {
            try
            {
                return _studentRepository.GetAllStudents();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
