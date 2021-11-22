using Microsoft.AspNetCore.Mvc;
using TolkienApi.Models;
using TolkienApi.Services;
using System.Collections.Generic;

namespace TolkienApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RacesController : ControllerBase
    {
        private readonly RaceService _raceService;
        public RacesController(RaceService raceService) {
            _raceService = raceService;
        }

        /// <summary>
        /// Returns a list of races
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<Race>> GetAll()
        {
            IEnumerable<Race> races = _raceService.GetAll();
            return Ok(races);
        }

        /// <summary>
        /// Returns a race for a given id
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<Race> GetById(int id)
        {
            Race race = _raceService.GetById(id);

            return race == null ? NotFound() : Ok(race);
        }

        /// <summary>
        /// Returns a random race
        /// </summary>
        [HttpGet("random")]
        public ActionResult<Race> GetRandom() => Ok(_raceService.GetRandom());

        /// <summary>
        /// Create new race
        /// </summary>
        [HttpPost]
        public ActionResult Create([FromBody] Race race)
        {
            _raceService.Add(race);
            return CreatedAtRoute("Get", new { id = race.Id }, race);
        }

        /// <summary>
        /// Returns races for a given loction
        /// </summary>
        [HttpGet("in/{location}")]
        public IEnumerable<Race> GetByLocation(string location = "Angband") => _raceService.GetByLocation(location);

        /// <summary>
        /// Replace an existing race with a new one
        /// </summary>
        [HttpPut]
        public ActionResult Update(Race newRace)
        {
            Race oldRace = _raceService.GetById(newRace.Id);
            if (oldRace is null)
                return NotFound(new { message = "The race Id does not exist." });

            _raceService.Replace(oldRace, newRace);

            return Ok(newRace);
        }

        /// <summary>
        /// Delete a race by id
        /// </summary>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Race race = _raceService.GetById(id);

            if (race is null)
                return NotFound();

            _raceService.Delete(race);

            return NoContent();
        }

        /// <summary>
        /// Returns total number of races
        /// </summary>
        [HttpGet("count")]
        public ActionResult<int> GetCount() => Ok(_raceService.GetCount());
    }
}