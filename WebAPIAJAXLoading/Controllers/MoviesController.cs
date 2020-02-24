using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIAJAXLoading.Models;

namespace WebAPIAJAXLoading.Controllers
{
    public class MoviesController : ApiController
    {
        // GET ALL 
        public IEnumerable<Movy> Get() {
            using (DBEntities1 db = new DBEntities1()) {

                return db.Movies.ToList();
            
            }
        
        }

        public HttpResponseMessage Get(int id) {

            using (DBEntities1 db = new DBEntities1()) {
                var entity = db.Movies.FirstOrDefault(x => x.MovieId == id);
                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else {

                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "We did not find the Movie:" + id.ToString());
                }
            }
        
        }
    }
}
