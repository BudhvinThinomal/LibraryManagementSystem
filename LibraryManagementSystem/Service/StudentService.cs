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

        //Get Student
        public StudentModel GetStudent(int StudentId)
        {
            try
            {
                return _studentRepository.GetStudent(StudentId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Edit Student
        public EditStudentResponse EditStudent(EditStudentRequest request)
        {
            try
            {
                return _studentRepository.EditStudent(request);
            }
            catch (Exception ex)
            {
                return new EditStudentResponse()
                {
                    ErrorMessage = ex.Message
                };
            }
        }

        //Terminate Student
        public TerminateStudentResponse TerminateStudent(TerminateStudentRequest request)
        {
            try
            {
                return _studentRepository.TerminateStudent(request);
            }
            catch (Exception ex)
            {
                return new TerminateStudentResponse()
                {
                    ErrorMessage = ex.Message
                };
            }
        }
    }
}
