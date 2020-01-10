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
    class DummyProgrammeRepository : IProgrammeRepository
    {
        List<ExperimentProgramme> dummyProgrammes = null;

        public DummyProgrammeRepository(List<ExperimentProgramme> programmes)
        {
            dummyProgrammes = programmes;
        }
        public List<ExperimentProgramme> LoadList(string sortOrder)
        {
            return SortList(dummyProgrammes,sortOrder);
        }
        public List<ExperimentProgramme> SortList(List<ExperimentProgramme> programmes, string sortOrder)
        {
            return programmes = ProgrammeLogic.SortProgrammes(programmes, sortOrder);
        }

        public ExperimentProgramme Load(int id)
        {
            return dummyProgrammes.Where(x => x.Id == id).FirstOrDefault();
        }
        public void Add(ExperimentProgramme ep)
        {
            dummyProgrammes.Add(ep);
        }
        public void Edit(ExperimentProgramme ep)
        {
            int id = ep.Id;
            Remove(id);
            dummyProgrammes.Add(ep);

        }
        public void Remove(int id)
        {
            ExperimentProgramme progToDel = dummyProgrammes.Where(x => x.Id == id).FirstOrDefault();
            dummyProgrammes.Remove(progToDel);
        }

        public IList<MetricModel> GetMetricModels()
        {
            MetricModel m1 = new MetricModel { Id = 0, Title = "Bounce Rate" };
            MetricModel m2 = new MetricModel { Id = 1, Title = "Basket Adds" };
            return new List<MetricModel> { m1, m2 };
        }

        public IList<ExperimentStatus> GetStatuses()
        {
            ExperimentStatus s1 = new ExperimentStatus { Id = 0, StatusName = "Draft" };
            ExperimentStatus s2 = new ExperimentStatus { Id = 1, StatusName = "Scheduled" };
            return new List<ExperimentStatus> { s1, s2 };
        }
    }
}
