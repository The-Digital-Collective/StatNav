using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using StatNav.WebApplication.Models;

namespace StatNav.WebApplication.DAL
{
    public class ProgrammeLogic : CrudLogic<ExperimentProgramme>
    {
        public override List<ExperimentProgramme> LoadList()
        {
            List<ExperimentProgramme> programmes = Db.ExperimentProgrammes
                .OrderBy(x => x.Name)
                .Include(x => x.ExperimentStatus)
                .ToList();
            return programmes;

        }

        public override ExperimentProgramme Load(int id)
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
        public override void Remove(int id)
        {
            Model = Db.ExperimentProgrammes
                      .Include(x => x.ExperimentIterations)
                      .FirstOrDefault(x => x.Id == id);
            if (Model != null)
            {
                Model?.ExperimentIterations.ToList().ForEach(n => Db.ExperimentIterations.Remove(n));
                Db.ExperimentProgrammes.Remove(Model);
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