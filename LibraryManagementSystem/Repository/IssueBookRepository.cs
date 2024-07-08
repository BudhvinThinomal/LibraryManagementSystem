using Dapper;
using LibraryManagementSystem.Models.Entities;
using LibraryManagementSystem.Models.Request;
using LibraryManagementSystem.Models.Response;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem.Repository
{
    public class IssueBookRepository
    {
        private readonly IConfiguration _config;

        public IssueBookRepository(IConfiguration config)
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

        //Issue Book
        public CreateIssueBookResponse CreateIssueBook(CreateIssueBookRequest request)
        {
            CreateIssueBookResponse resp = new CreateIssueBookResponse();

            try
            {
                using (IDbConnection con = connection)
                {
                    string Query = "sp_CreateIssueBook";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@ReferenceNumber", request.ReferenceNumber);
                    param.Add("@StudentID", request.StudentID);
                    param.Add("@IssueDate", request.IssueDate);
                    param.Add("@ReturnDate", request.ReturnDate);

                    int _ID = con.Query<int>(Query, param, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    if (_ID == 0)
                    {
                        throw new Exception("Failed to Issue a Book");
                    }

                    resp.ID = _ID;
                    return resp;
                }
            }
            catch (Exception ex)
            {
                return new CreateIssueBookResponse()
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

