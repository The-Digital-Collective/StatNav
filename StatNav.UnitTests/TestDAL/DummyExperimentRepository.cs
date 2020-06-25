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
    class DummyExperimentRepository : IExperimentRepository
    {
        List<Experiment> dummyExperiments = null;

        public DummyExperimentRepository(List<Experiment> experiments)
        {
            dummyExperiments = experiments;
        }
        public List<Experiment> LoadList(string sortOrder, string searchString = "")
        {
            IQueryable<Experiment> queryExperiments = dummyExperiments.AsQueryable();
            queryExperiments = ExperimentLogic.FilterExperiments(queryExperiments, searchString);
            return SortList(queryExperiments.ToList(), sortOrder);
        }

        public List<Experiment> SortList(List<Experiment> experiments, string sortOrder)
        {
            return experiments = ExperimentLogic.SortExperiments(experiments, sortOrder);
        }
        public Experiment Load(int id)
        {
            return dummyExperiments.Where(x => x.Id == id).FirstOrDefault();
        }
        public void Add(Experiment ex)
        {
            dummyExperiments.Add(ex);
        }
        public void Edit(Experiment ex)
        {
            int id = ex.Id;
            Remove(id);
            dummyExperiments.Add(ex);

        }
        public void Remove(int id)
        {
            Experiment ExperimentToDel = dummyExperiments.Where(x => x.Id == id).FirstOrDefault();
            dummyExperiments.Remove(ExperimentToDel);
        }

        public IList<MarketingAssetPackage> GetMAPs()
        {
            MarketingAssetPackage map1 = new MarketingAssetPackage { MAPName = "MAP1", Id = 1 };
            MarketingAssetPackage map2 = new MarketingAssetPackage() { MAPName = "MAP2", Id = 2 };
            return new List<MarketingAssetPackage> { map1, map2 };
        }

        public List<ExperimentCandidate> GetCandidates(int id)
        {
            return null;
        }
    }
}
