using Cross.BLL.Enums;
using Cross.BLL.Managers;
using Cross.Model;
using Cross.Web.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cross.Web.Controllers
{
    [Authorize(Roles = Roles.Administrator)]
    public class UsersController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public UsersController(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> EditRole(int id, string role)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Id == id);
            await _userManager.AddToRoleAsync(user, role);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteRole(int id, string role)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Id == id);
            await _userManager.RemoveFromRoleAsync(user, role);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> IndexAsync()
        {
            var indexViewModels = new List<IndexViewModel>();
            var allRoles = _roleManager.Roles.Select(r => r.Name);
            foreach (var user in _userManager.Users)
            {
                var userRoles = (List<string>)await _userManager.GetRolesAsync(user);
                indexViewModels.Add(new IndexViewModel()
                {
                    Id = user.Id,
                    Name = $"{user.FirstName} {user.LastName}",
                    Email = user.Email,
                    UserRoles = userRoles,
                    OtherRoles = allRoles.Where(ar => !userRoles.Any(ur => ar == ur)).ToList()
                }); ;
            }

            return View(indexViewModels);
        }

        public IActionResult Details(int userId)
        {
            var user = _userManager.Users.First(u => u.Id == userId);

            var detailsViewModels = new DetailsViewModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Cars = user.Cars.Select(c => new Models.Cars.DetailsViewModel()
                {
                    Id = c.Id,
                    LicensePlate = c.LicensePlate,
                    Discipline = c.Discipline.Name,
                    RaceType = c.RaceType.Name
                }).ToList(),
            };

            return View(detailsViewModels);
        }
    }
}
