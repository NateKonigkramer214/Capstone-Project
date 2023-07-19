
using Capstone.Areas.Identity.Pages.Account;
using Capstone.Data;
using Capstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Capstone.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        RoleManager<IdentityRole> roleManager;
        private readonly ApplicationDbContext _context;

        public RoleController(RoleManager<IdentityRole> roleManager, ApplicationDbContext dbContext)
        {
            this.roleManager = roleManager;
            _context = dbContext;
        }

        public IActionResult Index()
        {
            var roles = roleManager.Roles.ToList();
            return View(roles);
        }

        public IActionResult Create()
        {
            return View(new IdentityRole());
        }

        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            await roleManager.CreateAsync(role);
            return RedirectToAction("Index");
        }

        public IActionResult ViewRoles()
        {
            List<UsersList> users = new ();
            using (var conn = new SqlConnection(_context.Database.GetConnectionString()))
            {
                conn.Open();
                string query = $"SELECT AspNetUsers.Email, AspNetUserRoles.UserId, AspNetRoles.Name AS 'Role Name', AspNetUserRoles.RoleId FROM AspNetRoles INNER JOIN AspNetUsers INNER JOIN AspNetUserRoles ON (AspNetUsers.Id = AspNetUserRoles.UserId) ON (AspNetUserRoles.RoleId = AspNetRoles.Id) WHERE AspNetUsers.Id = AspNetUserRoles.UserId AND AspNetRoles.Id = AspNetUserRoles.RoleId";
                using (var cmd = new SqlCommand(query, conn))
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        UsersList user = new();
                        user.Email = reader.GetValue(0).ToString();
                        user.UserId =reader.GetValue(1).ToString();
                        user.RoleName = reader.GetValue(2).ToString();
                        user.RoleId = reader.GetValue(3).ToString();
                        users.Add(user);
                    }
                }
                ViewBag.users = users;
                conn.Close();
            }

            //var userRolesList = _context.Database.SqlQuery<UsersList>(query).Select(x => new UsersList { Email = x.Email, UserId = x.UserId, RoleName = x.RoleName, RoleId = x.RoleId }).ToList();

            //var userRolesList = _context.Database.SqlQuery<UsersList>(query)
            //    .Select(x => new UsersList { Email = x.Email, UserId = x.UserId, RoleName = x.RoleName, RoleId = x.RoleId })
            //    .ToList();

            //ViewBag.table = userRolesList;
            return View();
        }
    }
}
