using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using StatNav.WebApplication.DAL;
//using StatNav.WebApplication.Models;

namespace StatNav.API.Controllers
{
    public class DataController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            //PackageContainerRepository packageContainerRepository = new PackageContainerRepository();
            //List<PackageContainer> packageContainers = packageContainerRepository.LoadList("","");
            //string[] packages = new string[packageContainers.Count];
            //for (int x = 0; x<= packageContainers.Count;x++)
            //{
            //    packages[x] = packageContainers[x].PackageContainerName;
            //}

            //return packages;
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
