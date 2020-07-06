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
    class DummyMAPRepository : IMAPRepository
    {
        List<MarketingAssetPackage> dummyMaps = null;

        public DummyMAPRepository(List<MarketingAssetPackage> maps)
        {
            dummyMaps = maps;
        }
        public List<MarketingAssetPackage> LoadList(string sortOrder, string searchString)
        {
            IQueryable<MarketingAssetPackage> queryMaps = dummyMaps.AsQueryable();
            queryMaps = MAPLogic.FilterMAPs(queryMaps, searchString);
            return SortList(queryMaps.ToList(), sortOrder);
        }
        public List<MarketingAssetPackage> SortList(List<MarketingAssetPackage> maps, string sortOrder)
        {
            return maps = MAPLogic.SortMAPs(maps, sortOrder);
        }

        public MarketingAssetPackage Load(int id)
        {
            return dummyMaps.Where(x => x.Id == id).FirstOrDefault();
        }
        public void Add(MarketingAssetPackage ep)
        {
            dummyMaps.Add(ep);
        }
        public void Edit(MarketingAssetPackage ep)
        {
            int id = ep.Id;
            Remove(id);
            dummyMaps.Add(ep);

        }
        public void Remove(int id)
        {
            MarketingAssetPackage mapToDel = dummyMaps.Where(x => x.Id == id).FirstOrDefault();
            dummyMaps.Remove(mapToDel);
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

        public IList<Method> GetMethods()
        {
            Method m1 = new Method { Id = 0, Title = "Randomised Control Trial",SortOrder=1 };          
            return new List<Method> { m1};
        }

        public List<ExperimentIteration> GetIterations(int Id)
        {
            return null;
        }

        public IList<PackageContainer> GetPCs()
        {
            PackageContainer pc1 = new PackageContainer { PackageContainerName = "PC1", Id = 1 };
            PackageContainer pc2 = new PackageContainer { PackageContainerName = "PC2", Id = 2 };
            return new List<PackageContainer> { pc1, pc2 };
        }
    }
}
