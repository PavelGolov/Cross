using Cross.DAL;
using Cross.Model;
using System.Collections.Generic;

namespace Cross.BLL.Managers
{
    public class CancellationDbModelManager<T> : DbModelManager<T> where T : CancellationDbModel
    {
        public CancellationDbModelManager(CrossContext dataContext) : base(dataContext)
        {
        }

        public void Cancel(int id)
        {
            var model = DataContext.Set<T>().Find(id);
            model.IsCancelled = !model.IsCancelled;
            DataContext.Update(model);
            DataContext.SaveChanges();
        }
    }
}
