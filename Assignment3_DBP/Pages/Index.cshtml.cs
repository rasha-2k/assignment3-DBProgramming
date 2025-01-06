using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SQLite;

namespace Assignment3_DBP.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
        public void OnPost()
        {
            string? Name = Request.Form["Name"];
            string? Mobile = Request.Form["Mobile"];
            string? Address = Request.Form["Address"];
            string sqlQuery = "INSERT INTO Users (Name, Mobile, Address) VALUES(" + "'" + Name + "'" + ", " + "'" + Mobile + "'" + ", " + "'" + Address + "'" + ")";
            var connection = new SQLiteConnection("Data Source=UsersData.db"); connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = @sqlQuery;
            command.ExecuteNonQuery();
            connection.Close();
        }

    }
}
