using Microsoft.AspNetCore.Mvc;
using TolkienApi.Models;
using TolkienApi.Services;
using System.Collections.Generic;

namespace TolkienApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BattlesController : ControllerBase
    {
        private readonly BattleService _battleService;
        public BattlesController(BattleService battleService) {
            _battleService = battleService;
        }

        /// <summary>
        /// Returns a list of battles
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<Battle>> GetAll()
        {
            IEnumerable<Battle> battles = _battleService.GetAll();
            return Ok(battles);
        }

        /// <summary>
        /// Returns a battle for a given id
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<Battle> GetById(int id)
        {
            Battle battle = _battleService.GetById(id);

            return battle == null ? NotFound() : Ok(battle);
        }

        /// <summary>
        /// Returns a random battle
        /// </summary>
        [HttpGet("random")]
        public ActionResult<Battle> GetRandom() => Ok(_battleService.GetRandom());

        /// <summary>
        /// Create new battle
        /// </summary>
        [HttpPost]
        public ActionResult Create([FromBody] Battle battle)
        {
            _battleService.Add(battle);
            return CreatedAtRoute("Get", new { id = battle.Id }, battle);
        }

        /// <summary>
        /// Returns battles for a given loction
        /// </summary>
        [HttpGet("in/{location}")]
        public IEnumerable<Battle> GetByLocation(string location = "Shire") => _battleService.GetByLocation(location);

        /// <summary>
        /// Replace an existing battle with a new one
        /// </summary>
        [HttpPut]
        public ActionResult Update(Battle newBattle)
        {
            Battle oldBattle = _battleService.GetById(newBattle.Id);
            if (oldBattle is null)
                return NotFound(new { message = "The battle Id does not exist." });

            _battleService.Replace(oldBattle, newBattle);

            return Ok(newBattle);
        }

        /// <summary>
        /// Delete a battle by id
        /// </summary>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Battle battle = _battleService.GetById(id);

            if (battle is null)
                return NotFound();

            _battleService.Delete(battle);

            return NoContent();
        }

        /// <summary>
        /// Returns total number of battles
        /// </summary>
        [HttpGet("count")]
        public ActionResult<int> GetCount() => Ok(_battleService.GetCount());
    }
}