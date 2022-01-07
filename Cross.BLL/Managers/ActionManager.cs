using Cross.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cross.BLL.Managers
{
    public class ActionManager : DbModelManager<Model.Action>
    {
        public ActionManager(CrossContext dataContext) : base(dataContext)
        {
        }

        public IEnumerable<Model.Action> GetFirstActions(int userId, int raceId)
        {
            if (userId == 0)
                return new List<Model.Action>();

            var user = DataContext.Users.FirstOrDefault(u => u.Id == userId);

            if (DataContext.Requests.AsEnumerable().Any(r => user.Cars.Any(c=>c.Id == r.CarId) && r.RaceId == raceId))
                return new List<Model.Action>();

            var race = DataContext.Races.Find(raceId);

            if (!user.Cars.Any(c=> c.DisciplineId == race.DisciplineId && c.RaceTypeId == race.Event.RaceTypeId))
                return new List<Model.Action>();

            var roleIds = DataContext.UserRoles.Where(ur => ur.UserId == userId).Select(ur => ur.RoleId);
            var actions = DataContext.Actions
                .Where(a => !a.ActionStatuses.Any() && roleIds.Contains(a.RoleId));
            return actions;
        }

        public IEnumerable<Model.Action> GetActions(int userId, int statusId)
        {
            var roleIds = DataContext.UserRoles.Where(ur => ur.UserId == userId).Select(ur => ur.RoleId);
            var actionStatuses = DataContext.ActionStatuses.Where(a => a.StatusId == statusId);
            var actions = actionStatuses.Select(a => a.Action).Where(a => roleIds.Contains(a.RoleId));

            return actions;
        }
    }
}
