using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_WithPostman.Controllers
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
    }
    public class PersonsController : ApiController
    {


       static List<Person> people = new List<Person>()
        {
            new Person(){Id=1101,Name="Sakib",Salary=50000},
            new Person(){Id=1102,Name="Montu",Salary=80000},
            new Person(){Id=1103,Name="JOntu",Salary=5000},
        };


        public IHttpActionResult Get()
        {
            return Ok(people);
        }


        public IHttpActionResult Get(int id)
        {
            var person = people.Find(i => i.Id == id);
            if(person == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(person);
        }

        public IHttpActionResult Post(Person person)
        {
            people.Add(person);
            return Created("abc", person);
        }

        public IHttpActionResult Put(Person person,int id)
        {
            var personToUpdate = people.Find(i=>i.Id == id);
            personToUpdate.Name = person.Name;
            personToUpdate.Salary = person.Salary;
            return Ok(personToUpdate);

        }
        public IHttpActionResult Delete(int id)
        {
            people.Remove(people.Find(i => i.Id == id));

            return StatusCode(HttpStatusCode.NoContent);
        }

    }


}
