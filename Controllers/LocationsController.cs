using Microsoft.AspNetCore.Mvc;
using TolkienApi.Models;
using TolkienApi.Services;
using System.Collections.Generic;

namespace TolkienApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationsController : ControllerBase
    {
        private readonly LocationService _locationService;
        public LocationsController(LocationService locationService) {
            _locationService = locationService;
        }

        /// <summary>
        /// Returns a list of locations
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<Location>> GetAll()
        {
            IEnumerable<Location> locations = _locationService.GetAll();
            return Ok(locations);
        }

        /// <summary>
        /// Returns a location for a given id
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<Location> GetById(int id)
        {
            Location location = _locationService.GetById(id);

            return location == null ? NotFound() : Ok(location);
        }

        /// <summary>
        /// Returns a random location
        /// </summary>
        [HttpGet("random")]
        public ActionResult<Location> GetRandom() => Ok(_locationService.GetRandom());

        /// <summary>
        /// Create new location
        /// </summary>
        [HttpPost]
        public ActionResult Create([FromBody] Location location)
        {
            _locationService.Add(location);
            return CreatedAtRoute("Get", new { id = location.Id }, location);
        }

        /// <summary>
        /// Returns all locations for a given culture
        /// </summary>
        [HttpGet("by/{culture}")]
        public IEnumerable<Location> GetByCulture(string culture = "Elves") => _locationService.GetByCulture(culture);

        /// <summary>
        /// Replace an existing location with a new one
        /// </summary>
        [HttpPut]
        public ActionResult Update(Location newLocation)
        {
            Location oldLocation = _locationService.GetById(newLocation.Id);
            if (oldLocation is null)
                return NotFound(new { message = "The location Id does not exist." });

            _locationService.Replace(oldLocation, newLocation);

            return Ok(newLocation);
        }

        /// <summary>
        /// Delete a location by id
        /// </summary>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Location location = _locationService.GetById(id);

            if (location is null)
                return NotFound();

            _locationService.Delete(location);

            return NoContent();
        }

        /// <summary>
        /// Returns total number of locations
        /// </summary>
        [HttpGet("count")]
        public ActionResult<int> GetCount() => Ok(_locationService.GetCount());
    }
}