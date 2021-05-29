using IMS_with_Rest_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IMS_with_Rest_Api.Attributes;
using System.Web;

namespace IMS_with_Rest_Api.Controllers
{
    [RoutePrefix("api/categories")]
    public class CategoryController : ApiController
    {
        InventoryDataContext context = new InventoryDataContext();

        //[HttpGet]
        //public IHttpActionResult AllCategories()
        //{
        //    return Ok(context.Categories.ToList());
        //}


        //Authentication
        //1. Basic
        //2. Token based/Open authentication
        //3. Third Party

        //Richardson Maturity Model
        // Level-1: Resouce-based uri
        // Level-2: Level-1 + Http verbs + Status code
        // Level-3: Level-2 + HATEOAS
        [Route(""),BasicAuthentication]
        public IHttpActionResult Get()
        {
            
            return Ok(context.Categories.ToList());
        }
        [Route("{id}",Name ="GetById")]
        public IHttpActionResult Get(int id)
        {
            Category category = context.Categories.Find(id);
            if (category == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            category.Links.Add(new Link() { Url= "http://localhost:51072//api/categories", Method="POST",Relation="Create a new Category resource" });
            category.Links.Add(new Link() { Url = HttpContext.Current.Request.Url.AbsoluteUri, Method = "PUT", Relation = "Modify an existing Category resource" });
            category.Links.Add(new Link() { Url = "http://localhost:51072//api/categories/" + category.CategoryId, Method = "DELETE", Relation = "Delete an existing Category resource" });
            return Ok(category);
        }

        [Route("")]
        public IHttpActionResult Post(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            string url = Url.Link("GetById",new { id=category.CategoryId});
            return Created(url,category);
        }
        [Route("{id}"),HttpPut]
        public IHttpActionResult Edit([FromBody]Category category,[FromUri]int id)
        {
            category.CategoryId = id;
            context.Entry(category).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return Ok(category);
        }

        [Route("{id}"), HttpDelete]
        public IHttpActionResult Remove([FromUri] int id)
        {

            context.Categories.Remove(context.Categories.Find(id));
            context.SaveChanges();
            return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("{id}/products"),HttpGet]
        public IHttpActionResult GetProductsByCategory(int id)
        {
            var productList = context.Products.Where(x => x.CategoryId == id).ToList();
            if(productList==null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(productList);
        }
    }
}
