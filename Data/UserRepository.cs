using Infrastructure.Data.Data;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class UserRepository
    {
        private readonly string _connectionstring;

        public UserRepository(string connectionstring)
        {
            _connectionstring = connectionstring;
        }

        public void Register(string firstname, string lastname, DateOnly dateofbirth,string email, string password)
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
    }
}
