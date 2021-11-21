using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TolkienApi.Models;
using TolkienApi.Services;
using System.Collections.Generic;
using System.Net.Mime;

namespace TolkienApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharactersController : ControllerBase
    {
        private readonly CharacterService _characterService;
        public CharactersController(CharacterService characterService) {
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
        public ActionResult<Character> GetById(int id)
        {
            Character character = _characterService.GetById(id);

            return character == null ? NotFound() : Ok(character);
        }

        // /// <summary>
        // /// Returns a random character
        // /// </summary>
        // [HttpGet("random")]
        // public ActionResult<Character> GetRandom() => Ok(_characterService.GetRandom());

        // /// <summary>
        // /// Create new character
        // /// </summary>
        // [HttpPost]
        // public ActionResult Create([FromBody] Character character)
        // {
        //     _characterService.Add(character);
        //     return CreatedAtRoute("Get", new { id = character.Id }, character);
        // }

        // /// <summary>
        // /// Replace an existing character with a new one
        // /// </summary>
        // [HttpPut]
        // public ActionResult Update(Character newCharacter)
        // {
        //     Character oldCharacter = _characterService.GetById(newCharacter.Id);
        //     if (oldCharacter is null)
        //         return NotFound(new { message = "The character Id does not exist." });

        //     _characterService.Replace(oldCharacter, newCharacter);

        //     return Ok(newCharacter);
        // }

    }
}