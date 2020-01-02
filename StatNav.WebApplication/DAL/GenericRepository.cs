﻿using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Reflection;
using StatNav.WebApplication.Interfaces;

namespace StatNav.WebApplication.DAL
{

    public class GenericRepository<T> : IRepository<T> where T : class, new()
    {
        protected StatNavContext Db;
        protected T Model;

        public GenericRepository()
        {
            this.Db = new StatNavContext();
        }

        public GenericRepository(StatNavContext ctx)
        {
            this.Db = ctx;
        }

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