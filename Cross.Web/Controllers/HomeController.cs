using Cross.BLL.Managers;
using Cross.Model;
using Cross.Web.Models.Home;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cross.Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly CancellationDbModelManager<Event> _eventManager;
        private readonly ActionManager _actionManager;
        private readonly UserManager<User> _userManager;

        public HomeController(CancellationDbModelManager<Event> eventManager, ActionManager actionManager, UserManager<User> userManager)
        {
            _eventManager = eventManager;
            _actionManager = actionManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var userId = Convert.ToInt32(_userManager.GetUserId(User));
            var indexViewModels = new List<IndexViewModel>();
            var events = _eventManager.GetAll();
            foreach (var @event in events)
            {
                foreach (var race in @event.Races)
                {
                    indexViewModels.Add(new IndexViewModel()
                    {
                        raceId = race.Id,
                        DateTime = race.DateTime,
                        Discipline = race.Discipline.Name,
                        IsCancelled = race.IsCancelled || @event.IsCancelled,
                        RaceStatus = race.RaceStatus.Name,
                        RaceType = @event.RaceType.Name,
                        Track = race.Track.Name,
                        Venue = @event.Venue.Name,
                        Actions = _actionManager.GetFirstActions(userId,race.Id).ToDictionary(a => a.Id, a => a.NameMUI)
                    });
                }
            }
            return View(indexViewModels);
        }
    }
}
