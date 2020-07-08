using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using StatNav.WebApplication.BLL;
using StatNav.WebApplication.Interfaces;
using StatNav.WebApplication.Models;

namespace StatNav.WebApplication.DAL
{
    public class ExperimentRepository : GenericRepository<Experiment>, IExperimentRepository
    {       
        public override List<Experiment> LoadList(string sortOrder, string searchString)
        {
            IQueryable<Experiment> experiments = Db.Experiments;
            experiments = ExperimentLogic.FilterExperiments(experiments, searchString);
            return SortList(experiments.ToList(), sortOrder);
        }

        public List<Experiment> SortList(List<Experiment> experiments, string sortOrder)
        {
            return ExperimentLogic.SortExperiments(experiments, sortOrder);
        }
        public override Experiment Load(int id)
        {
            Experiment experiment = Db.Experiments
                .Where(x => x.Id == id)
                .Include(x => x.MarketingAssetPackage)
                .Include(x=>x.Variants)
                .FirstOrDefault();

            return experiment;
        }

        public List<Variant> GetVariants(int Id)
        {
            return Db.Variants
                     .Where(x => x.ExperimentId == Id)
                     .OrderBy(i => i.VariantName)
                     .ToList();
        }
        public override void Remove(int id)
        {
            Experiment experiment = Db.Experiments
                      .Include(x => x.Variants) 
                      .FirstOrDefault(x => x.Id == id);
            if (experiment != null)
            {
                experiment?.Variants.ToList().ForEach(n => Db.Variants.Remove(n)); 
                Db.Experiments.Remove(experiment);
                Db.SaveChanges();
            }
        }

        public IList<MarketingAssetPackage> GetMAPs()
        {
            IList<MarketingAssetPackage> ep = Db.MarketingAssetPackages
                                              .OrderBy(x => x.MAPName).ToList();
            return ep;
        }
        
    }
}