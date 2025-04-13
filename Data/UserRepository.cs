using Infrastructure.Data.Interfaces;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class UserRepository:IUserRepository
    {
        private readonly string _connectionstring;

        public UserRepository(IConfiguration configuration)
        {
            _connectionstring = configuration.GetConnectionString("Defaultconnection");
        }

        public void Register(string firstname, string lastname, DateTime dateofbirth,string email, string password)
        {
            using SqliteConnection connection = new(_connectionstring);
            connection.Open();
            using SqliteCommand cmd= connection.CreateCommand();
            cmd.CommandText = "INSERT INTO User(Firstname,Lastname,DateOfBirth,Email,Password) VALUES(@Firstname,@Lastname,@DateOfBirth,@Email,@Password)";
            cmd.Parameters.AddWithValue("@Firstname",firstname);
            cmd.Parameters.AddWithValue("@Lastname",lastname);
            cmd.Parameters.AddWithValue("@DateOfBirth",dateofbirth);
            cmd.Parameters.AddWithValue("@Email",email);
            cmd.Parameters.AddWithValue("@Password",password);
            cmd.ExecuteNonQuery();

        }

        public UserDTO Login(string email, string password)
        {
            UserDTO user=null;
            using SqliteConnection conn = new(_connectionstring);
            conn.Open();
            using SqliteCommand cmd = conn.CreateCommand(); 
            cmd.CommandText= "SELECT * FROM USER WHERE Email = @Email AND Password = @Password";
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Password", password);
            using SqliteDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
               user= new UserDTO
                {
                    UserId = Convert.ToInt32(reader["UserId"]),
                    
                    Email = reader["Email"].ToString(),

                };

            }
            return user;
        }

        public bool EmailExists(string email)
        { 
           
            using SqliteConnection conn =new(_connectionstring);
            conn.Open();
            using SqliteCommand cmd =conn.CreateCommand();
            cmd.CommandText = "SELECT 1 FROM USER WHERE Email=@Email";
            cmd.Parameters.AddWithValue("@Email", email);
            var result = cmd.ExecuteScalar();

            return result != null;
            
        }

     
    }
}
