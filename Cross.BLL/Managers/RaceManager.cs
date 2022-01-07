using Cross.DAL;
using Cross.Model;
using System.Collections.Generic;
using System.Linq;

namespace Cross.BLL.Managers
{
    public class RaceManager : CancellationDbModelManager<Race>
    {
        public RaceManager(CrossContext dataContext) : base(dataContext)
        {
        }

        public IEnumerable<Race> GetRacesByEventId(int eventId)
        {
            return DataContext.Races.Where(r => r.EventId == eventId);
        }
    }
}
