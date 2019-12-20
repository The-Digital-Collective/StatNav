using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using StatNav.WebApplication.Models;

namespace StatNav.WebApplication.DAL
{
    public class IterationLogic : CrudLogic<ExperimentIteration>
    {
        public override List<ExperimentIteration> LoadList()
        {
            List<ExperimentIteration> iterations = Db.ExperimentIterations
                                                     .OrderBy(x => x.Name)
                                                     .ToList();
            return iterations;

        }

        public override ExperimentIteration Load(int id)
        {
            ExperimentIteration programme = Db.ExperimentIterations
                .Where(x => x.Id == id)
                .Include(x => x.ExperimentProgramme)
                .Include(x=>x.ExperimentCandidates)
                .FirstOrDefault();

            return programme;
        }
        public override void Remove(int id)
        {
            Model = Db.ExperimentIterations
                      .Include(x => x.ExperimentCandidates) 
                      .FirstOrDefault(x => x.Id == id);
            if (Model != null)
            {
                Model?.ExperimentCandidates.ToList().ForEach(n => Db.ExperimentCandidates.Remove(n)); 
                Db.ExperimentIterations.Remove(Model);
                Db.SaveChanges();
            }
        }

        public IList<ExperimentProgramme> GetProgrammes()
        {
            IList<ExperimentProgramme> ep = Db.ExperimentProgrammes
                                              .OrderBy(x => x.Name).ToList();
            return ep;
        }
        
    }
}