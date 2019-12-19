using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Reflection;

namespace StatNav.WebApplication.DAL
{

    public abstract class CRUDLogic<T> where T : class, new()
                                                  
    {

        protected StatNavContext Db = new StatNavContext();
        protected T Model;


        public virtual List<T> LoadList()
        {
            // Will load the full table of data, override if only a subset is required
            List<T> modelList = Db.Set<T>().ToList();
            return modelList;
        }

        public virtual T Load(int id)
        {
            Model = Db.Set<T>().Find(id);
            if (Model != null)
            {
                return Model;
            }
            else { return null; }
        }


        public virtual T Refresh()
        {
            // reloads the data from the database and returns
            PropertyInfo IdFeild = typeof(T).GetProperty("Id");
            int IdValue = (int)IdFeild.GetValue(Model, null);
            return Load(IdValue);
        }




        public virtual void Add(T model)
        {
            Db.Set<T>().Add(model);
            Db.SaveChanges();
        }

        public virtual void Edit(T model)
        {
            Db.Entry(model).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public virtual void Remove(int id)
        {
            Model = Db.Set<T>().Find(id);
            if (Model != null)
            {
                Db.Set<T>().Remove(Model);
                Db.SaveChanges();
            }
        }

    }
}