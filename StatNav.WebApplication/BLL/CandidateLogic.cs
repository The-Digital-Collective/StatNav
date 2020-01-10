using StatNav.WebApplication.Models;
using System.Collections.Generic;
using System.Linq;

namespace StatNav.WebApplication.BLL
{
    public class CandidateLogic
    {

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