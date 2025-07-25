using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace YourApp.Controllers
{
    [ApiController]
    [Route("api/val")]// Custom route for Postman testing
    public class ValuesController : ControllerBase
    {
        private static List<string> values = new List<string> { "value1", "value2" };

        // GET: api/val
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(values);
        }

        // GET: api/val/1
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<string> Get(int id)
        {
            if (id < 0 || id >= values.Count)
                return NotFound("Value not found.");
            return Ok(values[id]);
        }

        // POST: api/val
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<string> Post([FromBody] string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return BadRequest("Invalid input.");
            values.Add(value);
            return CreatedAtAction(nameof(Get), new { id = values.Count - 1 }, value);
        }

        // PUT: api/val/1
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put(int id, [FromBody] string newValue)
        {
            if (string.IsNullOrWhiteSpace(newValue))
                return BadRequest("Invalid input.");
            if (id < 0 || id >= values.Count)
                return NotFound("Value not found.");
            values[id] = newValue;
            return NoContent();
        }

        // DELETE: api/val/1
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= values.Count)
                return NotFound("Value not found.");
            values.RemoveAt(id);
            return NoContent();
        }
    }
}
