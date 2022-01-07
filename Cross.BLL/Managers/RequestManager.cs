using Cross.DAL;
using Cross.Model;
using System.Collections.Generic;
using System.Linq;

namespace Cross.BLL.Managers
{
    public class RequestManager : DbModelManager<Request>
    {
        public RequestManager(CrossContext dataContext) : base(dataContext)
        {
        }

        public IEnumerable<Request> GetRequestsByCars(IEnumerable<Car> cars)
        {
            if (!cars.Any() || !DataContext.Requests.Any())
                return Enumerable.Empty<Request>();

            return FilterByCars(DataContext.Requests, cars);
        }

        public IEnumerable<Request> GetRequestsByRaceId(int raceId)
        {
            return FilterByRaceId(DataContext.Requests, raceId);
        }

        public IEnumerable<Request> GetRequestsByRaceIdAndCars(int raceId, IEnumerable<Car> cars)
        {
            var requests = FilterByRaceId(DataContext.Requests, raceId);
            return FilterByCars(requests, cars);
        }

        private IQueryable<Request> FilterByCars(IQueryable<Request> requests, IEnumerable<Car> cars)
        {
            var carIds = cars.Select(x => x.Id);
            return requests.Where(r => carIds.Contains(r.CarId));
        }

        private IQueryable<Request> FilterByRaceId(IQueryable<Request> requests, int raceId)
        {
            return requests.Where(r => r.RaceId == raceId);
        }
    }
}
