using Capstone.Data;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Capstone.Controllers
{
    public class ContactController : Controller
    {
        private readonly IConfiguration _configuration;

        public ContactController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Send(Contact model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var contact = new Contact
            {
                Name = model.Name,
                Email = model.Email,
                Message = model.Message,
            };

            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (var conn = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand("INSERT INTO Contacts (Name, Email, Message) VALUES (@Name, @Email, @Message)", conn);

                cmd.Parameters.AddWithValue("@Name", contact.Name);
                cmd.Parameters.AddWithValue("@Email", contact.Email);
                cmd.Parameters.AddWithValue("@Message", contact.Message);
               

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            return RedirectToAction("Contact", "Home");
        }
    }

}
