using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using StatNav.WebApplication.Interfaces;
using StatNav.WebApplication.Models;

namespace StatNav.WebApplication.DAL
{
    public class ProgrammeLogic : IProgrammeRepository
    {
        protected StatNavContext Db = new StatNavContext();
       

        public virtual void Add(ExperimentProgramme t)
        {
            Db.Set<ExperimentProgramme>().Add(t);
            Db.SaveChanges();
        }

        public virtual void Edit(ExperimentProgramme t)
        {
            Db.Entry(t).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public List<ExperimentProgramme> LoadList()
        {
            List<ExperimentProgramme> programmes = Db.ExperimentProgrammes
                .OrderBy(x => x.Name)
                .Include(x => x.ExperimentStatus)
                .ToList();
            return programmes;

        }

        public ExperimentProgramme Load(int id)
        {
            ExperimentProgramme programme = Db.ExperimentProgrammes
                                              .Where(x=>x.Id==id)
                                              .Include(x=>x.ExperimentStatus)
                                              .Include(x=>x.ImpactMetricModel)
                                              .Include(x=>x.TargetMetricModel)
                                              .Include(x => x.ExperimentIterations)
                                              .FirstOrDefault();
                
            return programme;
        }
        public void Remove(int id)
        {
            ExperimentProgramme ep = Db.ExperimentProgrammes
                      .Include(x => x.ExperimentIterations.Select(c=>c.ExperimentCandidates))
                      .FirstOrDefault(x => x.Id == id);
            if (ep != null)
            {
                ep?.ExperimentIterations.ToList().ForEach(c=>c.ExperimentCandidates.ToList().ForEach(n => Db.ExperimentCandidates.Remove(n)));
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
    }
}