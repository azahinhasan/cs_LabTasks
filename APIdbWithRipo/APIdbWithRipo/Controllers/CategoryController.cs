using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APIdbWithRipo.Models;
using APIdbWithRipo.Auth;
using System.Web;
using System.Web.Http.Cors;

namespace APIdbWithRipo.Controllers
{
    [RoutePrefix("api/categories")]
    
    public class CategoryController : ApiController
    {
        InventoryDataContext context = new InventoryDataContext();


        //Authertication
        //1.Basic 2.Token based/Open authentication  3.Third party(google,fb)

        /*Richardson Maturity model
         lv 1: resouce based Api
        lv 2: lv 1+http verbs+status code
        lv 3: lv 2+ hatedas
         */

        /* [HttpGet]*/
        /*[Route(""),BasicAuth]*/
        /*        public IHttpActionResult AllCategories()
                {
                    return Ok(context.Catagories.ToList());
                }*/



        /* [Route("api/categories")]*/
        /*[Route(""), BasicAuth]*/ //Auth/basciAuth folder

        [Route("")]
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

            category.Links.Add(new Link() { Url = "https://localhost:44382/api/categories", Method = "POST", Relation = "Create a New Catogory" });
          /*  category.Links.Add(new Link() { Url = HttpContext.Current.Request.Url.AbsoluteUri , Method = "POST", Relation = "Create a New Catogory" }); */  //in here URl is dynamic

            /*category.Links.Add(new Link() { Url = "https://localhost:44382/api/categories/"+category.CatagoriesId, Method = "PUT", Relation = "Maodfiy Catogory data" });*/
            category.Links.Add(new Link() { Url = HttpContext.Current.Request.Url.AbsoluteUri, Method = "PUT", Relation = "Maodfiy Catogory data" });

            category.Links.Add(new Link() { Url = "https://localhost:44382/api/categories/" + category.CatagoriesId, Method = "DELETE", Relation = "DELETE Catogory data" });
            // ^ show meta data on API output

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
       /* [EnableCors(origins: "*", headers: "*", methods: "*")]*/
        public IHttpActionResult Remove([FromUri]int id)
        {

            context.Catagories.Remove(context.Catagories.Find(id));
            context.SaveChanges();
            return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("{id}/products"),HttpGet]
        public IHttpActionResult getProductByCategory(int id)
        {
            var productList = context.Products.Where(x => x.CatagoriesId == id).ToList();
            if(productList == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(productList);
        }

    }

}
