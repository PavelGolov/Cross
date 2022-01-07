using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Cross.Model;
using Cross.BLL.Enums;
using Cross.Web.Models.Requests;
using Microsoft.AspNetCore.Identity;
using Cross.BLL.Managers;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace Cross.Web.Controllers
{
    [Authorize(Roles = Roles.User)]
    public class RequestsController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ActionManager _actionManager;
        private readonly RequestManager _requestManager;

        public RequestsController(UserManager<User> userManager, ActionManager actionManager, RequestManager requestManager)
        {
            _userManager = userManager;
            _actionManager = actionManager;
            _requestManager = requestManager;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            var requests = new List<Request>();

            if (User.IsInRole(Roles.Administrator))
                requests = _requestManager.GetAll().ToList();
            else
                requests = _requestManager.GetRequestsByCars(user.Cars).ToList();

            var indexViewModels = new List<IndexViewModel>();
            foreach (var request in requests)
            {
                var requestUser = _userManager.Users.FirstOrDefault(u => u.Cars.Any(c => c.Id == request.CarId));
                indexViewModels.Add(new IndexViewModel()
                {
                    RequestId = request.Id,
                    DateTime = request.Race.DateTime,
                    Discipline = request.Race.Discipline.Name,
                    RaceStatus = request.Race.RaceStatus.Name,
                    RaceType = request.Race.Event.RaceType.Name,
                    Track = request.Race.Track.Name,
                    Venue = request.Race.Event.Venue.Name,
                    User = requestUser.UserName,
                    LicensePlate = request.Car.LicensePlate,
                    Status = request.Status.Name,
                    Created = request.Created,
                    Modifed = request.Modifed,
                    Actions = _actionManager.GetActions(user.Id, request.StatusId).ToDictionary(a => a.Id, a => a.NameMUI),
                    Comment = request.Comment
                });
            }
            return View(indexViewModels);
        }

        public async Task<IActionResult> DetailsAsync(int? raceId)
        {
            if (raceId == null)
                return NotFound();

            var user = await _userManager.GetUserAsync(User);
            var requests = new List<Request>();

            if (User.IsInRole(Roles.Administrator))
                requests = _requestManager.GetRequestsByRaceId(raceId.Value).ToList();
            else
                requests = _requestManager.GetRequestsByRaceIdAndCars(raceId.Value, user.Cars).ToList();

            var indexViewModels = new List<IndexViewModel>();
            foreach (var request in requests)
            {
                var requestUser = _userManager.Users.FirstOrDefault(u => u.Cars.Any(c => c.Id == request.CarId));
                indexViewModels.Add(new IndexViewModel()
                {
                    RequestId = request.Id,
                    DateTime = request.Race.DateTime,
                    Discipline = request.Race.Discipline.Name,
                    RaceStatus = request.Race.RaceStatus.Name,
                    RaceType = request.Race.Event.RaceType.Name,
                    Track = request.Race.Track.Name,
                    Venue = request.Race.Event.Venue.Name,
                    User = requestUser.UserName,
                    LicensePlate = request.Car.LicensePlate,
                    Status = request.Status.Name,
                });
            }
            return View(indexViewModels);
        }

        public IActionResult Create(int? carId ,int? raceId, int? actionId)
        {
            if (carId == null || raceId == null || actionId == null)
                return NotFound();

            var action = _actionManager.Find(actionId.Value);

            var request = new Request()
            {
                Id = 0,
                CarId = carId.Value,
                RaceId = raceId ?? 0,
                StatusId = action.SetStatusId,
                Created = DateTime.Now,
                Modifed = DateTime.Now,
            };
            _requestManager.Save(request);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? requestId, int? actionId)
        {
            if (requestId == null || actionId == null)
            {
                return NotFound();
            }

            var editViewModel = new EditViewModel()
            {
                RequestId = requestId.Value,
                ActionId = actionId.Value
            };
            return View(editViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? requestId, int? actionId, string comment)
        {
            if (requestId == null || actionId == null)
            {
                return NotFound();
            }

            var request = _requestManager.Find(requestId.Value);
            var action = _actionManager.Find(actionId.Value);
            request.StatusId = action.SetStatusId;
            request.Modifed = DateTime.Now;
            request.Comment = comment;

            _requestManager.Save(request);
            return RedirectToAction("Index");
        }
    }
}
