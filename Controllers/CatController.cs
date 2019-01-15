using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using catsllist.Models;
using Microsoft.AspNetCore.Mvc;

namespace catsllist.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CatsController : ControllerBase
  {
    // GET api/values
    public List<Cat> Cats = new List<Cat>()
    {
     new Cat("Momo", "The best cat ever"),
     new Cat("Mr. bigglesworth", "He's a cat")
  };


    [HttpGet]
    public IEnumerable<Cat> Get()
    {
      return Cats;
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<Cat> Get(int id)
    {
      try
      {
        return Cats[id];
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return NotFound("{\"Error\": \"That cat doesn't exist\"}");
      }
    }

    // POST api/values
    [HttpPost]
    public ActionResult<List<Cat>> Post([FromBody] Cat value)
    {
      Cats.Add(value);
      return Cats;
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public ActionResult<List<Cat>> Put(int id, [FromBody] Cat value)
    {
      try
      {
        Cats[id] = value;
        return Cats;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return NotFound("{\"Error\": \"Can't make that cat\"}");
      }
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public ActionResult<List<Cat>> Delete(int id)
    {
      try
      {
        Cats.Remove(Cats[id]);
        return Cats;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return NotFound("{\"Error\": \"Can't delete the cat\"}");
      }
    }
  }
}