using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatNav.WebApplication.Models;

namespace StatNav.WebApplication.Interfaces
{
    public interface IRepository<T>
    {

        List<T> LoadList();
        T Load(int id);
        void Add(T t);
        void Edit(T t);
        void Remove(int id);

    }
    public interface IProgrammeRepository : IRepository<ExperimentProgramme> { }
}
