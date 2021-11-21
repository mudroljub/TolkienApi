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
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class QuotesController : ControllerBase
    {
        private readonly QuoteService _quoteService;
        public QuotesController(QuoteService quoteService) {
            _quoteService = quoteService;
        }

        /// <summary>
        /// Returns a list of quotes
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<Quote>> GetAll()
        {
            IEnumerable<Quote> quotes = _quoteService.GetAll();
            return Ok(quotes);
        }

        /// <summary>
        /// Returns a quote for a given id
        /// </summary>
        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Quote> Get(int id)
        {
            Quote quote = _quoteService.GetById(id);

            return quote == null ? NotFound() : Ok(quote);
        }

        /// <summary>
        /// Returns a random quote
        /// </summary>
        [HttpGet("random")]
        public ActionResult<Quote> GetRandom() => Ok(_quoteService.GetRandom());

        /// <remarks>
        /// Don't send quote id, it will be auto-generated.
        /// </remarks>
        /// <summary>
        /// Create new quote
        /// </summary>
        [HttpPost]
        public ActionResult Create([FromBody] Quote quote)
        {
            _quoteService.Add(quote);
            return CreatedAtRoute("Get", new { id = quote.Id }, quote);
        }

        /// <summary>
        /// Returns all quotes for a given character
        /// </summary>
        [HttpGet("by/{character}")]
        public IEnumerable<Quote> GetQuotesByAuthor(string character) => _quoteService.GetByAuthor(character);

        /// <summary>
        /// Replace an existing quote with a new one
        /// </summary>
        [HttpPut]
        public ActionResult Update(Quote newQuote)
        {
            Quote oldQuote = _quoteService.GetById(newQuote.Id);
            if (oldQuote is null)
                return NotFound(new { message = "The quote Id does not exist." });

            _quoteService.Replace(oldQuote, newQuote);

            return Ok(newQuote);
        }

        /// <summary>
        /// Delete a quote by id
        /// </summary>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Quote quote = _quoteService.GetById(id);

            if (quote is null)
                return NotFound();

            _quoteService.Delete(quote);

            return NoContent();
        }

        /// <summary>
        /// Returns total number of quotes
        /// </summary>
        [HttpGet("count")]
        public ActionResult<int> GetCount() => Ok(_quoteService.GetCount());
    }
}