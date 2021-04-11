using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APIdbWithRipo.Models;
using APIdbWithRipo.Auth;

namespace APIdbWithRipo.Controllers
{
    [RoutePrefix("api/categories")]
    public class CategoryController : ApiController
    {
        InventoryDataContext context = new InventoryDataContext();


        //Authertication
        //1.Basic 2.Token based/Open authentication  3.Third party(google,fb)


        /* [HttpGet]*/
        /*[Route(""),BasicAuth]*/  
        /*        public IHttpActionResult AllCategories()
                {
                    return Ok(context.Catagories.ToList());
                }*/



        /* [Route("api/categories")]*/
        [Route(""), BasicAuth] //Auth/basciAuth folder
        public IHttpActionResult Get()
        {
            // return StatusCode(HttpStatusCode.NoContent);
            return Ok(context.Catagories.ToList());
        }

       /* [Route("api/categories/{id}")]*/
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            Catagory category = context.Catagories.Find(id);
            if (category == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }

            return Ok(category);
        }

        /*[Route("api/categories")] *///create
        [Route("")]
        public IHttpActionResult Post(Catagory catagory)
        {
            context.Catagories.Add(catagory);
            context.SaveChanges();

            return Created("api/categories/" + catagory.CatagoriesId,catagory);
        }

        /* [Route("api/categories/{id}"), HttpPut] *///edit
        [Route("{id}"), HttpPut]

        public IHttpActionResult Edit([FromBody]Catagory catagory,[FromUri]int id)
        {
            catagory.CatagoriesId = id;
            context.Entry(catagory).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return Ok(catagory);
        }

        /*[Route("api/categories/{id}"), HttpDelete] *///delete
        [Route("{id}"), HttpDelete]
        public IHttpActionResult Remove([FromUri] int id)
        {

            context.Catagories.Remove(context.Catagories.Find(id));
            context.SaveChanges();
            return StatusCode(HttpStatusCode.NoContent);
        }

    }

}
