using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Cross.Model;
using Cross.Web.Models.Races;
using Cross.BLL.Managers;
using Microsoft.AspNetCore.Identity;

namespace Cross.Web.Controllers
{
    public class RacesController : Controller
    {
        private readonly RaceManager _raceManager;
        private readonly DbModelManager<Discipline> _disciplineManager;
        private readonly DbModelManager<RaceStatus> _raceStatusManager;
        private readonly DbModelManager<Track> _trackManager;

        public RacesController(RaceManager raceManager, DbModelManager<Discipline> disciplineManager, DbModelManager<RaceStatus> raceStatusManager, DbModelManager<Track> trackManager)
        {
            _raceManager = raceManager;
            _disciplineManager = disciplineManager;
            _raceStatusManager = raceStatusManager;
            _trackManager = trackManager;
        }

        public IActionResult Index(int? eventId)
        {
            if (eventId == null)
            {
                return NotFound();
            }

            var races = _raceManager.GetRacesByEventId(eventId.Value);

            var indexViewModels = races.Select(r => new IndexViewModel()
            {
                Id = r.Id,
                DateTime = r.DateTime,
                IsCancelled = r.IsCancelled,
                RaceStatus = r.RaceStatus.Name,
                Discipline = r.Discipline.Name,
                EventId = r.EventId,
                Track = r.Track.Name
            });

            ViewData["EventId"] = eventId;
            return View(indexViewModels);
        }

        public IActionResult Create(int? eventId)
        {
            if (eventId == null)
            {
                return NotFound();
            }

            ViewData["DisciplineId"] = new SelectList(_disciplineManager.GetAll(), "Id", "Name");
            ViewData["RaceStatusId"] = new SelectList(_raceStatusManager.GetAll(), "Id", "Name");
            ViewData["TrackId"] = new SelectList(_trackManager.GetAll(), "Id", "Name");
            return View("Edit", new EditViewModel() {EventId = (int)eventId });
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var race = _raceManager.Find(id.Value);

            if (race == null)
            {
                return NotFound();
            }

            var editViewModel = new EditViewModel()
            {
                Id = race.Id,
                DateTime = race.DateTime,
                IsCancelled = race.IsCancelled,
                RaceStatusId = race.RaceStatusId,
                DisciplineId = race.DisciplineId,
                EventId = race.EventId,
                TrackId = race.TrackId
            };

            ViewData["DisciplineId"] = new SelectList(_disciplineManager.GetAll(), "Id", "Name", editViewModel.DisciplineId);
            ViewData["RaceStatusId"] = new SelectList(_raceStatusManager.GetAll(), "Id", "Name", editViewModel.RaceStatusId);
            ViewData["TrackId"] = new SelectList(_trackManager.GetAll(), "Id", "Name", editViewModel.TrackId);

            return View(editViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EditViewModel editViewModel)
        {
            if (ModelState.IsValid)
            {
                _raceManager.Save(new Race()
                {
                    Id = editViewModel.Id ?? 0,
                    DateTime = editViewModel.DateTime,
                    IsCancelled = editViewModel.IsCancelled ?? false,
                    RaceStatusId = editViewModel.RaceStatusId,
                    DisciplineId = editViewModel.DisciplineId,
                    EventId = editViewModel.EventId,
                    TrackId = editViewModel.TrackId
                });
                return RedirectToAction(nameof(Index),new {editViewModel.EventId});
            }

            ViewData["DisciplineId"] = new SelectList(_disciplineManager.GetAll(), "Id", "Name", editViewModel.DisciplineId);
            ViewData["RaceStatusId"] = new SelectList(_raceStatusManager.GetAll(), "Id", "Name", editViewModel.RaceStatusId);
            ViewData["TrackId"] = new SelectList(_trackManager.GetAll(), "Id", "Name", editViewModel.TrackId);

            return View(editViewModel);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventId = _raceManager.Find(id.Value).EventId;

            _raceManager.Remove(id.Value);

            return RedirectToAction("Index", new { eventId });
        }

        public IActionResult Cancel(int? eventId, int? raceId)
        {
            if (eventId == null || raceId == null)
            {
                return NotFound();
            }

            _raceManager.Cancel(raceId.Value);

            return RedirectToAction("Index", new { eventId });
        }
    }
}
