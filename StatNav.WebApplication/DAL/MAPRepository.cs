using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using StatNav.WebApplication.BLL;
using StatNav.WebApplication.Interfaces;
using StatNav.WebApplication.Models;

namespace StatNav.WebApplication.DAL
{
    public class MAPRepository : GenericRepository<MarketingAssetPackage>, IMAPRepository
    {

        public override List<MarketingAssetPackage> LoadList(string sortOrder, string searchString)
        {
            IQueryable<MarketingAssetPackage> maps = Db.MarketingAssetPackages;
                               //.Include(x => x.ExperimentStatus); //story 2069

            maps = MAPLogic.FilterMAPs(maps, searchString);
            return SortList(maps.ToList(), sortOrder);
        }

        public List<Experiment> GetExperiments(int Id)
        {            
            return Db.Experiments
                     .Where(x => x.MarketingAssetPackageId == Id)
                     .OrderBy(i => i.ExperimentName)
                     .ToList();
        }

        public List<MarketingAssetPackage> SortList(List<MarketingAssetPackage> maps, string sortOrder)
        {
            return MAPLogic.SortMAPs(maps, sortOrder);
        }

        public override MarketingAssetPackage Load(int id)
        {
            MarketingAssetPackage map = Db.MarketingAssetPackages
                                              .Where(x => x.Id == id)
                                              //.Include(x => x.ExperimentStatus) story 2069
                                              //.Include(x => x.MAPTargetMetricModel)
                                              //.Include(x => x.MAPImpactMetricModel)
                                              .Include(x => x.Experiments)
                                              //.Include(x=>x.MAPMethod)
                                              .Include(x=>x.PackageContainer)
                                              .FirstOrDefault();

            return map;
        }
        public override void Remove(int id)
        {
            MarketingAssetPackage map = Db.MarketingAssetPackages
                      .Include(x => x.Experiments.Select(v => v.Variants))
                      .FirstOrDefault(x => x.Id == id);
            if (map != null)
            {
                map?.Experiments.ToList().ForEach(v => v.Variants.ToList().ForEach(n => Db.Variants.Remove(n)));
                map?.Experiments.ToList().ForEach(n => Db.Experiments.Remove(n));
                Db.MarketingAssetPackages.Remove(map);
                Db.SaveChanges();
            }
        }

        public IList<MetricModel> GetMetricModels()
        {
            IList<MetricModel> mm = Db.MetricModels
              .OrderBy(x => x.Title).ToList();
            return mm;
        }
        public IList<ExperimentStatus> GetStatuses()
        {
            IList<ExperimentStatus> es = Db.ExperimentStatuses
            .OrderBy(x => x.DisplayOrder).ToList();
            return es;
        }

        public IList<Method> GetMethods()
        {
            IList<Method> m = Db.Method
            .OrderBy(x => x.SortOrder).ToList();
            return m;
        }

        public IList<PackageContainer> GetPCs()
        {
            IList<PackageContainer> pcs = Db.PackageContainer
                                               .OrderBy(x => x.PackageContainerName).ToList();
            return pcs;
        }
    }
}