using LibraryManagementSystem.Models.Entities;
using LibraryManagementSystem.Models.Request;
using LibraryManagementSystem.Models.Response;
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
        public List<StudentModel> GetAllStudents(GetAllStudentRequest request)
        {
            try
            {
                return _studentRepository.GetAllStudents(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Register Student
        public CreateStudentResponse CreateStudent(CreateStudentRequest request)
        {
            try
            {
                return _studentRepository.CreateStudent(request);
            }
            catch (Exception ex)
            {
                return new CreateStudentResponse()
                {
                    ErrorMessage = ex.Message
                };
            }
        }
    }
}
