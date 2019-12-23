﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using StatNav.WebApplication.Models;

namespace StatNav.WebApplication.DAL
{
    public class CandidateLogic : CrudLogic<ExperimentCandidate>
    {
        public override List<ExperimentCandidate> LoadList()
        {
            List<ExperimentCandidate> candidates = Db.ExperimentCandidates
                                                     .OrderBy(x => x.Name)
                                                     .ToList();
            return candidates;

        }

        public override ExperimentCandidate Load(int id)
        {
            ExperimentCandidate candidate = Db.ExperimentCandidates
                                              .Where(x => x.Id == id)
                                              .Include(x => x.ExperimentIteration)
                                              .Include(x=>x.ImpactMetricModel)
                                              .Include(x=>x.TargetMetricModel)
                                              .FirstOrDefault();

            return candidate;
        }
        

        public IList<ExperimentIteration> GetIterations()
        {
            IList<ExperimentIteration> ei = Db.ExperimentIterations
                                              .OrderBy(x => x.Name).ToList();
            return ei;
        }
        
    }
}