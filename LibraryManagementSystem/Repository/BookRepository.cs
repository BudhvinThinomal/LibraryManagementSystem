using Dapper;
using LibraryManagementSystem.Models.Entities;
using LibraryManagementSystem.Models.Request;
using LibraryManagementSystem.Models.Response;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;

namespace LibraryManagementSystem.Repository
{
    public class BookRepository
    {
        private readonly IConfiguration _config;

        public BookRepository(IConfiguration config)
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

        //Get All Books
        public List<BookModel> GetAllBooks()
        {
            try
            {
                using (IDbConnection con = connection)
                {
                    string Query = "sp_GetAllBooks";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    //param.Add("@Page", request.Page);
                    //param.Add("@Limit", request.Limit);

                    List<BookModel> resp = con.Query<BookModel>(Query, param, commandType: CommandType.StoredProcedure).ToList();

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

        //Register Book
        public CreateBookResponse CreateBook(CreateBookRequest request)
        {
            CreateBookResponse resp = new CreateBookResponse();

            try
            {
                using (IDbConnection con = connection)
                {
                    string Query = "sp_CreateBook";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@ISBN", request.ISBN);
                    param.Add("@Title", request.Title);
                    param.Add("@Author", request.Author);
                    param.Add("@Publication", request.Publication);
                    param.Add("@Edition", request.Edition);
                    param.Add("@PublishedYear", request.PublishedYear);
                    param.Add("@Category", request.Category);
                    param.Add("@NumberOfCopies", request.NumberOfCopies);

                    int _ID = con.Query<int>(Query, param, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    if (_ID == 0)
                    {
                        throw new Exception("Failed to register the Book");
                    }

                    resp.ID = _ID;
                    return resp;
                }
            }
            catch (Exception ex)
            {
                return new CreateBookResponse()
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
