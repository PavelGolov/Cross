using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Cross.Model;
using Cross.Web.Models.Cars;
using Cross.BLL.Managers;
using Microsoft.AspNetCore.Authorization;
using Cross.BLL.Enums;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Cross.Web.Controllers
{
    [Authorize(Roles = Roles.User)]
    public class CarsController : Controller
    {
        private readonly CarManager _carManager;
        private readonly DbModelManager<RaceType> _raceTypeManager;
        private readonly DbModelManager<Discipline> _disciplineManager;
        private readonly UserManager<User> _userManager;
        private readonly RaceManager _raceManager;

        public CarsController(CarManager carManager, DbModelManager<RaceType> raceTypeManager, DbModelManager<Discipline> disciplineManager,
            UserManager<User> userManager, RaceManager raceManager)
        {
            _carManager = carManager;
            _raceTypeManager = raceTypeManager;
            _disciplineManager = disciplineManager;
            _userManager = userManager;
            _raceManager = raceManager;
        }

        public IActionResult Create(int? userId)
        {
            if (userId == null)
                return NotFound();

            ViewData["DisciplineId"] = new SelectList(_disciplineManager.GetAll(), "Id", "Name");
            ViewData["RaceTypeId"] = new SelectList(_raceTypeManager.GetAll(), "Id", "Name");
            return View(nameof(Edit), new EditViewModel() { UserId = (int)userId });
        }

        public IActionResult Edit(int? carId)
        {
            if (carId == null)
                return NotFound();

            var car = _carManager.Find(carId.Value);
            var editViewModel = new EditViewModel()
            {
                Id = car.Id,
                LicensePlate = car.LicensePlate,
                DisciplineId = car.DisciplineId,
                RaceTypeId = car.RaceTypeId,
                UserId = car.UserId
            };

            ViewData["DisciplineId"] = new SelectList(_disciplineManager.GetAll(), "Id", "Name");
            ViewData["RaceTypeId"] = new SelectList(_raceTypeManager.GetAll(), "Id", "Name");
            return View(editViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EditViewModel editViewModel)
        {
            if (_carManager.ExistLicensePlate(editViewModel.LicensePlate, editViewModel.RaceTypeId, editViewModel.DisciplineId))
                ModelState.AddModelError("LicensePlate", "Такой номер уже существует");

            if (ModelState.IsValid)
            {
                _carManager.Save(new Car()
                {
                    Id = editViewModel.Id ?? 0,
                    UserId = editViewModel.UserId,
                    LicensePlate = editViewModel.LicensePlate,
                    RaceTypeId = editViewModel.RaceTypeId,
                    DisciplineId = editViewModel.DisciplineId
                });
                return RedirectToAction("Index", "Users");
            }

            ViewData["DisciplineId"] = new SelectList(_disciplineManager.GetAll(), "Id", "Name", editViewModel.DisciplineId);
            ViewData["RaceTypeId"] = new SelectList(_raceTypeManager.GetAll(), "Id", "Name", editViewModel.RaceTypeId);

            return View(editViewModel);
        }

        public async Task<IActionResult> ChooseСarAsync(int? raceId, int? actionId)
        {
            if (raceId == null || actionId == null)
                return NotFound();

            var race = _raceManager.Find(raceId.Value);
            var user = await _userManager.GetUserAsync(User);
            var viewModel = new ChooseСarViewModel
            {
                RaceId = raceId.Value,
                ActionId = actionId.Value,
                Cars = user.Cars.Where(c=>c.DisciplineId == race.DisciplineId)
                .Select(c => new BasicCarInfoViewModel
                {
                    Id = c.Id,
                    LicensePlate = c.LicensePlate
                }).ToList()
            };
            return View(viewModel);

        }

        public IActionResult Delete(int carId, int userId)
        {
            _carManager.Remove(carId);

            return RedirectToAction("Details", "Users", new { userId });
        }
    }
}
