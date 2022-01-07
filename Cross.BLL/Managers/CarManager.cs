using Cross.DAL;
using Cross.Model;
using System.Linq;

namespace Cross.BLL.Managers
{
    public class CarManager : DbModelManager<Car>
    {
        public CarManager(CrossContext dataContext) : base(dataContext)
        {
        }

        public bool ExistLicensePlate(string licensePlate, int raceTypeId, int disciplineId)
        {
            if (DataContext.Cars.Any(c => c.LicensePlate == licensePlate
            && c.RaceTypeId == raceTypeId && c.DisciplineId == disciplineId))
                return true;

            return false;
        }
    }
}
