﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using StatNav.WebApplication.BLL;
using StatNav.WebApplication.Interfaces;
using StatNav.WebApplication.Models;

namespace StatNav.WebApplication.DAL
{
    public class IterationRepository : GenericRepository<ExperimentIteration>, IIterationRepository
    {       
        public override List<ExperimentIteration> LoadList(string sortOrder, string searchString)
        {
            IQueryable<ExperimentIteration> iterations = Db.ExperimentIterations;
            iterations = IterationLogic.FilterIterations(iterations, searchString);
            return SortList(iterations.ToList(), sortOrder);
        }

        public List<ExperimentIteration> SortList(List<ExperimentIteration> iterations, string sortOrder)
        {
            return IterationLogic.SortIterations(iterations, sortOrder);
        }
        public override ExperimentIteration Load(int id)
        {
            ExperimentIteration iteration = Db.ExperimentIterations
                .Where(x => x.Id == id)
                .Include(x => x.MarketingAssetPackage)
                .Include(x=>x.ExperimentCandidates)
                .FirstOrDefault();

            return iteration;
        }

        public List<ExperimentCandidate> GetCandidates(int Id)
        {
            return Db.ExperimentCandidates
                     .Where(x => x.ExperimentIterationId == Id)
                     .OrderBy(i => i.CandidateName)
                     .ToList();
        }
        public override void Remove(int id)
        {
            ExperimentIteration iteration = Db.ExperimentIterations
                      .Include(x => x.ExperimentCandidates) 
                      .FirstOrDefault(x => x.Id == id);
            if (iteration != null)
            {
                iteration?.ExperimentCandidates.ToList().ForEach(n => Db.ExperimentCandidates.Remove(n)); 
                Db.ExperimentIterations.Remove(iteration);
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