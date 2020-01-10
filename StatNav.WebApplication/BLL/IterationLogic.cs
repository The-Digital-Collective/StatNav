using StatNav.WebApplication.Models;
using System.Collections.Generic;
using System.Linq;

namespace StatNav.WebApplication.BLL
{
    public class IterationLogic
    {
        public static List<ExperimentIteration> SortIterations(List<ExperimentIteration> iterationList, string sortOrder)
        {            
            IOrderedEnumerable<ExperimentIteration> sortedList;
            switch (sortOrder)
            {
                case "name_desc":
                    sortedList = iterationList.OrderByDescending(x => x.IterationName);
                    break;
                case "StartDate":
                    sortedList = iterationList.OrderBy(x => x.StartDateTime);
                    break;
                case "startDate_desc":
                    sortedList = iterationList.OrderByDescending(x => x.StartDateTime);
                    break;
                case "EndDate":
                    sortedList = iterationList.OrderBy(x => x.EndDateTime);
                    break;
                case "endDate_desc":
                    sortedList = iterationList.OrderByDescending(x => x.EndDateTime);
                    break;
                case "Id":
                    sortedList = iterationList.OrderBy(x => x.Id);
                    break;
                case "id_desc":
                    sortedList = iterationList.OrderByDescending(x => x.Id);
                    break;
                default:
                    sortedList = iterationList.OrderBy(x => x.IterationName);
                    break;
            }
            return sortedList.ToList();
        }
    }
}