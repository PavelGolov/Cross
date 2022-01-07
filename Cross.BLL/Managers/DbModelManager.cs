using Cross.DAL;
using Cross.Model;
using System.Collections.Generic;
using System.Linq;

namespace Cross.BLL.Managers
{
    public class DbModelManager<T> where T : DbModel
    {
        protected readonly CrossContext DataContext;

        public DbModelManager(CrossContext dataContext)
        {
            DataContext = dataContext;
        }

        public virtual T Find(int id)
        {
            return DataContext.Set<T>().FirstOrDefault(e => e.Id == id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return DataContext.Set<T>();
        }

        public virtual void Save(T model)
        {
            if (model.Id == 0)
                DataContext.Add(model);
            else
                DataContext.Update(model);

            DataContext.SaveChanges();
        }

        public virtual void Remove(int id)
        {
            var model = DataContext.Set<T>().Find(id);
            DataContext.Set<T>().Remove(model);
            DataContext.SaveChanges();
        }
    }
}
