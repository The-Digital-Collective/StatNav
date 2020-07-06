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
    class DummyPCRepository : IPackageContainerRepository
    {
        List<PackageContainer> dummyPCs = null;

        public DummyPCRepository(List<PackageContainer> pcs)
        {
            dummyPCs = pcs;
        }
        public List<PackageContainer> LoadList(string sortOrder, string searchString)
        {
            IQueryable<PackageContainer> queryPcs = dummyPCs.AsQueryable();
            queryPcs = PCLogic.FilterPCs(queryPcs, searchString);
            return SortList(queryPcs.ToList(), sortOrder);
        }
        public List<PackageContainer> SortList(List<PackageContainer> pcs, string sortOrder)
        {
            return pcs = PCLogic.SortPCs(pcs, sortOrder);
        }

        public PackageContainer Load(int id)
        {
            return dummyPCs.Where(x => x.Id == id).FirstOrDefault();
        }
        public void Add(PackageContainer pc)
        {
            dummyPCs.Add(pc);
        }
        public void Edit(PackageContainer pc)
        {
            int id = pc.Id;
            Remove(id);
            dummyPCs.Add(pc);

        }
        public void Remove(int id)
        {
            PackageContainer pcToDel = dummyPCs.Where(x => x.Id == id).FirstOrDefault();
            dummyPCs.Remove(pcToDel);
        }

        public IList<MetricModelStage> GetStages()
        {
            MetricModelStage mms1 = new MetricModelStage { Id = 0, Title = "Reach" };
            MetricModelStage mms2 = new MetricModelStage { Id = 1, Title = "Act" };
            MetricModelStage mms3 = new MetricModelStage { Id = 2, Title = "Engage" };
            return new List<MetricModelStage> { mms1, mms2, mms3 };            
        }

        public List<MarketingAssetPackage> GetMAPs(int Id)
        {
            return null;
        }
    }
}
