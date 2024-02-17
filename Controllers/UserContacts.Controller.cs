
using DatabaseApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;


[ApiController]
[Route("api/[controller]")]
public class UserContactController {

        private readonly string _connectionString;

        public UserContactController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserModel>), 200)]
         public List<UserContactModel> GetContacts()
        {
            List<UserContactModel> contactdetails = new List<UserContactModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT ContactID, UserID, Email, PhoneNumber FROM ContactDetails";

                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        UserContactModel contacts = new UserContactModel
                        {
                            ContactID = reader.GetInt32(0),
                            UserID = reader.GetInt32(1),
                            Email = reader.GetString(2),
                            PhoneNumber = reader.GetString(3)
                        };

                        contactdetails.Add(contacts);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    
                }
            }

            return contactdetails;
        }
    }