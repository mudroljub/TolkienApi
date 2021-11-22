using Microsoft.AspNetCore.Mvc;
using TolkienApi.Models;
using TolkienApi.Services;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace TolkienApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CulturesController : ControllerBase
    {
        private readonly CultureService _cultureService;
        public CulturesController(CultureService cultureService) {
            _cultureService = cultureService;
        }

        /// <summary>
        /// Returns a list of cultures
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<Culture>> GetAll()
        {
            IEnumerable<Culture> cultures = _cultureService.GetAll();
            return Ok(cultures);
        }

        /// <summary>
        /// Returns a culture for a given id
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<Culture> GetById(int id)
        {
            Culture culture = _cultureService.GetById(id);

            return culture == null ? NotFound() : Ok(culture);
        }

        /// <summary>
        /// Returns a random culture
        /// </summary>
        [HttpGet("random")]
        public ActionResult<Culture> GetRandom() => Ok(_cultureService.GetRandom());

        /// <summary>
        /// Create new culture
        /// </summary>
        [HttpPost]
        [Authorize]
        public ActionResult Create([FromBody] Culture culture)
        {
            _cultureService.Add(culture);
            return CreatedAtRoute("Get", new { id = culture.Id }, culture);
        }

        /// <summary>
        /// Returns all cultures for a given character
        /// </summary>
        [HttpGet("by/{character}")]
        public IEnumerable<Culture> GetByCharacter(string character = "Legolas") => _cultureService.GetByCharacter(character);

        /// <summary>
        /// Returns cultures for a given loction
        /// </summary>
        [HttpGet("in/{location}")]
        public IEnumerable<Culture> GetByLocation(string location = "Rohan") => _cultureService.GetByLocation(location);

        /// <summary>
        /// Replace an existing culture with a new one
        /// </summary>
        [HttpPut]
        [Authorize]
        public ActionResult Update(Culture newCulture)
        {
            Culture oldCulture = _cultureService.GetById(newCulture.Id);
            if (oldCulture is null)
                return NotFound(new { message = "The culture Id does not exist." });

            _cultureService.Replace(oldCulture, newCulture);

            return Ok(newCulture);
        }

        /// <summary>
        /// Delete a culture by id
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult Delete(int id)
        {
            Culture culture = _cultureService.GetById(id);

            if (culture is null)
                return NotFound();

            _cultureService.Delete(culture);

            return NoContent();
        }

        /// <summary>
        /// Returns total number of cultures
        /// </summary>
        [HttpGet("count")]
        public ActionResult<int> GetCount() => Ok(_cultureService.GetCount());
    }
}