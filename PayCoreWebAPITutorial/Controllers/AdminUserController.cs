using Microsoft.AspNetCore.Mvc;
using PayCoreWebAPITutorial.Models;

namespace PayCoreWebAPITutorial.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminUserController : ControllerBase
    {
        List<AdminUser> adminUsers;

        public AdminUserController()
        {
            adminUsers = new List<AdminUser>();

            AdminUser adminUser = new AdminUser();
            adminUser.Email = "cagatayyildiz@mail.com";
            adminUser.Name = "admin";
            adminUser.Id = 1;

            AdminUser adminUser1 = new AdminUser();
            adminUser1.Email = "aykut@mail.com";
            adminUser1.Name = "aykut";
            adminUser1.Id = 2;

            adminUsers.Add(adminUser);
            adminUsers.Add(adminUser1);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(adminUsers);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var adminUser = adminUsers.FirstOrDefault(x => x.Id == id);

            if (adminUser != null)
            {
                return Ok(adminUser);
            }
            else
            {
                return NotFound("");
            }
        }

        [HttpPost]
        public IActionResult Create(AdminUser adminUser)
        {
            adminUser.Id = adminUsers.Count + 1;
            adminUsers.Add(adminUser);

            return Ok(adminUser);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var adminUser = adminUsers.FirstOrDefault(y => y.Id == id);
            if (adminUser != null)
            {
                adminUsers.Remove(adminUser);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
