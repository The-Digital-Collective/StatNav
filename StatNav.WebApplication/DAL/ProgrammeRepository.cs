using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using StatNav.WebApplication.BLL;
using StatNav.WebApplication.Interfaces;
using StatNav.WebApplication.Models;

namespace StatNav.WebApplication.DAL
{
    public class ProgrammeRepository : GenericRepository<ExperimentProgramme>, IProgrammeRepository
    {

        public override List<ExperimentProgramme> LoadList(string sortOrder, string searchString)
        {
            IQueryable<ExperimentProgramme> programmes = Db.ExperimentProgrammes
                               .Include(x => x.ExperimentStatus);

            programmes = ProgrammeLogic.FilterProgrammes(programmes, searchString);
            return SortList(programmes.ToList(), sortOrder);
        }

        public List<ExperimentIteration> GetIterations(int Id)
        {            
            return Db.ExperimentIterations
                     .Where(x => x.ExperimentProgrammeId == Id)
                     .OrderBy(i => i.IterationName)
                     .ToList();
        }

        public List<ExperimentProgramme> SortList(List<ExperimentProgramme> programmes, string sortOrder)
        {
            return ProgrammeLogic.SortProgrammes(programmes, sortOrder);
        }

        public override ExperimentProgramme Load(int id)
        {
            ExperimentProgramme programme = Db.ExperimentProgrammes
                                              .Where(x => x.Id == id)
                                              .Include(x => x.ExperimentStatus)
                                              .Include(x => x.ProgrammeTargetMetricModel)
                                              .Include(x => x.ProgrammeImpactMetricModel)
                                              .Include(x => x.ExperimentIterations)
                                              .Include(x=>x.ProgrammeMethod)
                                              .FirstOrDefault();

            return programme;
        }
        public override void Remove(int id)
        {
            ExperimentProgramme ep = Db.ExperimentProgrammes
                      .Include(x => x.ExperimentIterations.Select(c => c.ExperimentCandidates))
                      .FirstOrDefault(x => x.Id == id);
            if (ep != null)
            {
                ep?.ExperimentIterations.ToList().ForEach(c => c.ExperimentCandidates.ToList().ForEach(n => Db.ExperimentCandidates.Remove(n)));
                ep?.ExperimentIterations.ToList().ForEach(n => Db.ExperimentIterations.Remove(n));
                Db.ExperimentProgrammes.Remove(ep);
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
    }
}