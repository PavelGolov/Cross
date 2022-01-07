using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Cross.Model;
using Cross.BLL.Managers;
using Cross.Web.Models.Events;
using Microsoft.AspNetCore.Authorization;
using Cross.BLL.Enums;

namespace Cross.Web.Controllers
{
    [Authorize(Roles = Roles.User)]
    public class EventsController : Controller
    {
        private readonly CancellationDbModelManager<Event> _eventManager;
        private readonly DbModelManager<RaceType>_raceTypeManager;
        private readonly DbModelManager<Venue>_venueManager;

        public EventsController(CancellationDbModelManager<Event> eventManager, DbModelManager<RaceType> raceTypeManager, DbModelManager<Venue> venueManager)
        {
            _eventManager = eventManager;
            _raceTypeManager = raceTypeManager;
            _venueManager = venueManager;
        }

        public IActionResult Index()
        {
            var events = _eventManager.GetAll();
            var indexViewModels = events.Select(e => new IndexViewModel()
            {
                Id = e.Id,
                Venue = e.Venue.Name,
                RaceType = e.RaceType.Name,
                IsCancelled = e.IsCancelled,
                DateStart = e.DateStart,
                DateEnd = e.DateEnd
            });
            return View(indexViewModels);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                ViewData["RaceTypeId"] = new SelectList(_raceTypeManager.GetAll(), "Id", "Name");
                ViewData["VenueId"] = new SelectList(_venueManager.GetAll(), "Id", "Name");
                return View();
            }

            var @event = _eventManager.Find(id.Value);
            if (@event == null)
            {
                return NotFound();
            }
            var editViewModel = new EditViewModel()
            {
                Id = @event.Id,
                VenueId = @event.VenueId,
                RaceTypeId = @event.RaceTypeId,
                IsCancelled = @event.IsCancelled,
                DateStart = @event.DateStart,
                DateEnd = @event.DateEnd
            };
            ViewData["RaceTypeId"] = new SelectList(_raceTypeManager.GetAll(), "Id", "Name", editViewModel.RaceTypeId);
            ViewData["VenueId"] = new SelectList(_venueManager.GetAll(), "Id", "Name", editViewModel.VenueId);
            return View(editViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EditViewModel editViewModel)
        {
            if (ModelState.IsValid)
            {
                _eventManager.Save(new Event()
                {
                    Id = editViewModel.Id ?? 0,
                    VenueId = editViewModel.VenueId,
                    RaceTypeId = editViewModel.RaceTypeId,
                    IsCancelled = editViewModel.IsCancelled??false,
                    DateStart = editViewModel.DateStart,
                    DateEnd = editViewModel.DateEnd
                });
                return RedirectToAction(nameof(Index));
            }
            ViewData["RaceTypeId"] = new SelectList(_raceTypeManager.GetAll(), "Id", "Name", editViewModel.RaceTypeId);
            ViewData["VenueId"] = new SelectList(_venueManager.GetAll(), "Id", "Name", editViewModel.VenueId);
            return View(editViewModel);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _eventManager.Remove(id.Value);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Cancel(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _eventManager.Cancel(id.Value);

            return RedirectToAction("Index");
        }
    }
}
