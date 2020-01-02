﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using StatNav.WebApplication.Interfaces;
using StatNav.WebApplication.Models;

namespace StatNav.WebApplication.DAL
{
    public class ProgrammeRepository : GenericRepository<ExperimentProgramme>, IProgrammeRepository
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