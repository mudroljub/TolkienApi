using Microsoft.AspNetCore.Mvc;
using TolkienApi.Models;
using TolkienApi.Services;
using System.Collections.Generic;

namespace TolkienApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArtefactsController : ControllerBase
    {
        private readonly ArtefactService _artefactService;
        public ArtefactsController(ArtefactService artefactService) {
            _artefactService = artefactService;
        }

        /// <summary>
        /// Returns a list of artefacts
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<Artefact>> GetAll()
        {
            IEnumerable<Artefact> artefacts = _artefactService.GetAll();
            return Ok(artefacts);
        }

        /// <summary>
        /// Returns a artefact for a given id
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<Artefact> GetById(int id)
        {
            Artefact artefact = _artefactService.GetById(id);

            return artefact == null ? NotFound() : Ok(artefact);
        }

        /// <summary>
        /// Returns a random artefact
        /// </summary>
        [HttpGet("random")]
        public ActionResult<Artefact> GetRandom() => Ok(_artefactService.GetRandom());

        /// <summary>
        /// Create new artefact
        /// </summary>
        [HttpPost]
        public ActionResult Create([FromBody] Artefact artefact)
        {
            _artefactService.Add(artefact);
            return CreatedAtRoute("Get", new { id = artefact.Id }, artefact);
        }

        /// <summary>
        /// Returns all artefacts for a given character
        /// </summary>
        [HttpGet("by/{character}")]
        public IEnumerable<Artefact> GetByCharacter(string character = "Legolas") => _artefactService.GetByCharacter(character);

        /// <summary>
        /// Returns artefacts for a given loction
        /// </summary>
        [HttpGet("of/{location}")]
        public IEnumerable<Artefact> GetByLocation(string location = "Rohan") => _artefactService.GetByLocation(location);

        /// <summary>
        /// Replace an existing artefact with a new one
        /// </summary>
        [HttpPut]
        public ActionResult Update(Artefact newArtefact)
        {
            Artefact oldArtefact = _artefactService.GetById(newArtefact.Id);
            if (oldArtefact is null)
                return NotFound(new { message = "The artefact Id does not exist." });

            _artefactService.Replace(oldArtefact, newArtefact);

            return Ok(newArtefact);
        }

        /// <summary>
        /// Delete a artefact by id
        /// </summary>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Artefact artefact = _artefactService.GetById(id);

            if (artefact is null)
                return NotFound();

            _artefactService.Delete(artefact);

            return NoContent();
        }

        /// <summary>
        /// Returns total number of artefacts
        /// </summary>
        [HttpGet("count")]
        public ActionResult<int> GetCount() => Ok(_artefactService.GetCount());
    }
}