using Microsoft.AspNetCore.Mvc;
using TolkienApi.Models;
using TolkienApi.Services;
using System.Collections.Generic;

namespace TolkienApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharactersController : ControllerBase
    {
        private readonly CharacterService _characterService;
        public CharactersController(CharacterService characterService)
        {
            _characterService = characterService;
        }

        /// <summary>
        /// Returns a list of characters
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<Character>> Get(int count = 10)
        {
            IEnumerable<Character> characters = _characterService.Get(count);
            return Ok(characters);
        }

        /// <summary>
        /// Returns total number of characters
        /// </summary>
        [HttpGet("count")]
        public ActionResult<int> GetCount() => Ok(_characterService.GetCount());

        /// <summary>
        /// Returns a character for a given id
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<Character> GetById(int id = 408)
        {
            Character character = _characterService.GetById(id);
            return character == null ? NotFound() : Ok(character);
        }

        /// <summary>
        /// Returns a character for a given name
        /// </summary>
        [HttpGet("by/{name}")]
        public ActionResult<Character> GetByName(string name = "Aragorn")
        {
            Character character = _characterService.GetByName(name);
            return character == null ? NotFound() : Ok(character);
        }

        /// <summary>
        /// Returns a random character
        /// </summary>
        [HttpGet("random")]
        public ActionResult<Character> GetRandom() => Ok(_characterService.GetRandom());

        /// <summary>
        /// Create new character
        /// </summary>
        [HttpPost]
        public ActionResult Create([FromBody] CharacterNew character)
        {
            _characterService.Add(character);
            return Created("", character);
        }

    }
}