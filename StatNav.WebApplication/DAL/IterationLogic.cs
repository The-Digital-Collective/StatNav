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
                .FirstOrDefault();

            return programme;
        }
        public override void Remove(int id)
        {
            Model = Db.ExperimentIterations
                     // .Include(x => x.ExperimentIterations) change this to candidates
                      .FirstOrDefault(x => x.Id == id);
            if (Model != null)
            {
                //Model?.ExperimentIterations.ToList().ForEach(n => Db.ExperimentIterations.Remove(n)); change this to candidates
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