using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GiftedAPI.Controllers
{
    public class GiftsController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
           //Gets list of Gifts based on user
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            //Gets value of a particular Gift
            return "value";
        }

        // POST api/values
        public void Post(string value)
        {
            //Updates a Gift
        }

        // PUT api/values/5
        public void Put(int id, string value)
        {
            //Puts a new Gift
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
           // Deletes a Gift
        }
    }
}