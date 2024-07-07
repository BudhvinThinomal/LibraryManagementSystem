using Dapper;
using LibraryManagementSystem.Models.Entities;
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
        public List<StudentModel> GetAllStudents()
        {
            try
            {
                 using (IDbConnection con = connection)
                {
                    string Query = "sp_GetAllStudents";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    //param.Add("@Page", request.Page);
                    //param.Add("@Limit", request.Limit);

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
    }
}
