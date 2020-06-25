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
                .Include(x=>x.ExperimentCandidates)
                .FirstOrDefault();

            return experiment;
        }

        public List<ExperimentCandidate> GetCandidates(int Id)
        {
            return Db.ExperimentCandidates
                     .Where(x => x.ExperimentId == Id)
                     .OrderBy(i => i.CandidateName)
                     .ToList();
        }
        public override void Remove(int id)
        {
            Experiment experiment = Db.Experiments
                      .Include(x => x.ExperimentCandidates) 
                      .FirstOrDefault(x => x.Id == id);
            if (experiment != null)
            {
                experiment?.ExperimentCandidates.ToList().ForEach(n => Db.ExperimentCandidates.Remove(n)); 
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