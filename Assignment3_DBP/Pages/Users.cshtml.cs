using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Assignment3_DBP.Pages
{
    public class UsersModel : PageModel
    {
        public List<User> Users { get; set; } = new();

        public void OnGet()
        {
            using var connection = new SQLiteConnection("Data Source=UsersData.db");
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "SELECT Id, Name, Mobile, Address FROM Users";
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Users.Add(new User
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Mobile = reader.GetString(2),
                    Address = reader.GetString(3)
                });
            }
        }

        public IActionResult OnPostDelete(int id)
        {
            using var connection = new SQLiteConnection("Data Source=UsersData.db");
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "DELETE FROM Users WHERE Id = @Id";
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
            return RedirectToPage();
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Mobile { get; set; }
        public string? Address { get; set; }
    }
}
