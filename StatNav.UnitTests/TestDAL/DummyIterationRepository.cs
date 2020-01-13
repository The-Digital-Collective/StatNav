using StatNav.WebApplication.BLL;
using StatNav.WebApplication.Interfaces;
using StatNav.WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatNav.UnitTests.TestData
{
    class DummyIterationRepository : IIterationRepository
    {
        List<ExperimentIteration> dummyIterations = null;

        public DummyIterationRepository(List<ExperimentIteration> iterations)
        {
            dummyIterations = iterations;
        }
        public List<ExperimentIteration> LoadList(string sortOrder, string searchString = "")
        {
            IQueryable<ExperimentIteration> queryIterations = dummyIterations.AsQueryable();
            queryIterations = IterationLogic.FilterIterations(queryIterations, searchString);
            return SortList(queryIterations.ToList(), sortOrder);
        }

        public List<ExperimentIteration> SortList(List<ExperimentIteration> iterations, string sortOrder)
        {
            return iterations = IterationLogic.SortIterations(iterations, sortOrder);
        }
        public ExperimentIteration Load(int id)
        {
            return dummyIterations.Where(x => x.Id == id).FirstOrDefault();
        }
        public void Add(ExperimentIteration ei)
        {
            dummyIterations.Add(ei);
        }
        public void Edit(ExperimentIteration ei)
        {
            int id = ei.Id;
            Remove(id);
            dummyIterations.Add(ei);

        }
        public void Remove(int id)
        {
            ExperimentIteration iterationToDel = dummyIterations.Where(x => x.Id == id).FirstOrDefault();
            dummyIterations.Remove(iterationToDel);
        }

        public IList<ExperimentProgramme> GetProgrammes()
        {
            ExperimentProgramme prog1 = new ExperimentProgramme { ProgrammeName = "Programme1", Id = 1 };
            ExperimentProgramme prog2 = new ExperimentProgramme() { ProgrammeName = "Programme2", Id = 2 };
            return new List<ExperimentProgramme> { prog1, prog2 };
        }
    }
}
