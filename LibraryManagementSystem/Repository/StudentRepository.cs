using Dapper;
using LibraryManagementSystem.Models.Entities;
using LibraryManagementSystem.Models.Request;
using LibraryManagementSystem.Models.Response;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem.Repository
{
    public class StudentRepository
    {

        private readonly IConfiguration _config;

        public StudentRepository(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }
       

        //Get All Students
        public List<StudentModel> GetAllStudents(GetAllStudentRequest request)
        {
            try
            {
                 using (IDbConnection con = connection)
                {
                    string Query = "sp_GetAllStudents";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IssueDate", request.IssueDate);
                    param.Add("@Page", request.Page);
                    param.Add("@Limit", request.Limit);

                    List<StudentModel> resp = con.Query<StudentModel>(Query, param, commandType: CommandType.StoredProcedure).ToList();

                    return resp;

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        //Register Student
        public CreateStudentResponse CreateStudent(CreateStudentRequest request)
        {
            CreateStudentResponse resp = new CreateStudentResponse();

            try
            {
                using (IDbConnection con = connection)
                {
                    string Query = "sp_CreateStudent";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@FirstName", request.FirstName);
                    param.Add("@LastName", request.LastName);
                    param.Add("@Email", request.Email);
                    param.Add("@Address", request.Address);
                    param.Add("@Telephone", request.Telephone);
                    param.Add("@RegisteredDate", request.RegisteredDate);
                    param.Add("@TerminatedDate", request.TerminatedDate);

                    int _ID = con.Query<int>(Query, param, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    if (_ID == 0)
                    {
                        throw new Exception("Failed to Register the Student");
                    }

                    resp.ID = _ID;
                    return resp;
                }
            }
            catch (Exception ex)
            {
                return new CreateStudentResponse()
                {
                    ErrorMessage = ex.Message
                };
            }
            finally
            {
                connection.Close();
            }
        }

        //Get Student
        public StudentModel GetStudent(int StudentId)
        {
            try
            {
                using (IDbConnection con = connection)
                {
                    string Query = "sp_GetStudent";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@StudentId", StudentId);

                    StudentModel resp = con.Query<StudentModel>(Query, param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    return resp;

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        //Edit Student
        public EditStudentResponse EditStudent(EditStudentRequest request)
        {
            EditStudentResponse resp = new EditStudentResponse();

            try
            {
                using (IDbConnection con = connection)
                {
                    string Query = "sp_EditStudent";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@StudentId", request.StudentId);
                    param.Add("@FirstName", request.FirstName);
                    param.Add("@LastName", request.LastName);
                    param.Add("@Email", request.Email);
                    param.Add("@Address", request.Address);
                    param.Add("@Telephone", request.Telephone);

                    int _ID = con.Query<int>(Query, param, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    if (_ID == 0)
                    {
                        throw new Exception("Failed to Edit the Student");
                    }

                    resp.ID = _ID;
                    return resp;
                }
            }
            catch (Exception ex)
            {
                return new EditStudentResponse()
                {
                    ErrorMessage = ex.Message
                };
            }
            finally
            {
                connection.Close();
            }
        }

        //Terminate Student
        public TerminateStudentResponse TerminateStudent(TerminateStudentRequest request)
        {
            TerminateStudentResponse resp = new TerminateStudentResponse();
            try
            {
                using (IDbConnection con = connection)
                {
                    string Query = "sp_TerminateStudent";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@StudentId", request.StudentId);
                    param.Add("@TerminatedDate", request.TerminatedDate);

                    int _ID = con.Query<int>(Query, param, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    if (_ID == 0)
                    {
                        throw new Exception("Failed to Terminate the Student");
                    }

                    resp.ID = _ID;
                    return resp;

                }

            }
            catch (Exception ex)
            {
                return new TerminateStudentResponse()
                {
                    ErrorMessage = ex.Message
                };
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
