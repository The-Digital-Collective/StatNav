﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using StatNav.WebApplication.BLL;
using StatNav.WebApplication.Interfaces;
using StatNav.WebApplication.Models;

namespace StatNav.WebApplication.DAL
{
    public class PackageContainerRepository : GenericRepository<PackageContainer>, IPackageContainerRepository
    {

        public override List<PackageContainer> LoadList(string sortOrder, string searchString)
        {
            IQueryable<PackageContainer> containers = Db.PackageContainer
                               .Include(x => x.MetricModelStage);


            containers = PCLogic.FilterPCs(containers, searchString);
            return SortList(containers.ToList(), sortOrder);
        }       

        public List<PackageContainer> SortList(List<PackageContainer> containers, string sortOrder)
        {
            return PCLogic.SortPCs(containers, sortOrder);
        }

        public override PackageContainer Load(int id)
        {
            PackageContainer container = Db.PackageContainer
                                              .Include(x => x.MarketingAssetPackages)
                                              .Include(x => x.MetricModelStage)
                                              .Where(x => x.Id == id)
                                              .FirstOrDefault();

            return container;
        }
        public override void Remove(int id)
        {
            PackageContainer pc = Db.PackageContainer
                      .Include(p => p.MarketingAssetPackages.Select(i => i.Experiments.Select(v => v.Variants)))
                      .FirstOrDefault(x => x.Id == id);
            if (pc != null)
            {
                //remove variants
                pc?.MarketingAssetPackages.ToList().ForEach(i => i.Experiments.ToList().ForEach(v => v.Variants.ToList().ForEach(n => Db.Variants.Remove(n))));
                //remove experiments
                pc?.MarketingAssetPackages.ToList().ForEach(i => i.Experiments.ToList().ForEach(n => Db.Experiments.Remove(n)));
                //remove marketing asset packages
                pc?.MarketingAssetPackages.ToList().ForEach(n => Db.MarketingAssetPackages.Remove(n));
                Db.PackageContainer.Remove(pc);
                Db.SaveChanges();
            }
        }

        public IList<MetricModelStage> GetStages()
        {
            IList<MetricModelStage> mms = Db.MetricModelStages
                                            .OrderBy(x => x.SortOrder).ToList();
            return mms;
        }

        public List<MarketingAssetPackage> GetMAPs(int Id)
        {
            return Db.MarketingAssetPackages
                    .Where(x => x.PackageContainerId == Id)
                    .OrderBy(i => i.MAPName)
                    .ToList();
        }
    }
}