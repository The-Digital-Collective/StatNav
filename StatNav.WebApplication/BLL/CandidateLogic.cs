using StatNav.WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StatNav.WebApplication.BLL
{
    public static class CandidateLogic
    {
        public static IQueryable<ExperimentCandidate> FilterCandidates(IQueryable<ExperimentCandidate> candidates, string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                candidates = candidates.Where(x => x.CandidateName.ToLower().Contains(searchString.ToLower()));
            }
            return candidates;
        }
        public static List<ExperimentCandidate> SortCandidates(List<ExperimentCandidate> candidateList, string sortOrder)
        {
            IOrderedEnumerable<ExperimentCandidate> sortedList;
            switch (sortOrder)
            {
                case "name_desc":
                    sortedList = candidateList.OrderByDescending(x => x.CandidateName);
                    break;
                case "Id":
                    sortedList = candidateList.OrderBy(x => x.Id);
                    break;
                case "id_desc":
                    sortedList = candidateList.OrderByDescending(x => x.Id);
                    break;
                default:
                    sortedList = candidateList.OrderBy(x => x.CandidateName);
                    break;
            }
            return sortedList.ToList();
        }
    }
}