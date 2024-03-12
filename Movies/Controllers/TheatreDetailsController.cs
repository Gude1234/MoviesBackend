using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies.contract;
using Movies.Data;
using Movies.Models;

namespace Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheatreDetailsController : ControllerBase
    {        
        private readonly ITheatreDetailsRepository _theatreDetailsRepository;

        public TheatreDetailsController(ITheatreDetailsRepository theatreDetailsRepository)
        {            
            this._theatreDetailsRepository = theatreDetailsRepository;
        }

        // GET: api/MovieDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TheatreDetails>>> GetTheatreDetails()
        {
            return await _theatreDetailsRepository.GetAllAsync();
        }

        // GET: api/MovieDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TheatreDetails>> GetTheatreDetail(int id)
        {
            var movieDetail = await _theatreDetailsRepository.GetAsync(id);

            if (movieDetail == null)
            {
                return NotFound();
            }

            return movieDetail;
        }

        // PUT: api/MovieDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovieDetail(int id, TheatreDetails theatreDetail)
        {
            if (id != theatreDetail.Id)
            {
                return BadRequest();
            }

            

            try
            {
                await _theatreDetailsRepository.UpdateAsync(theatreDetail);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await MovieDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MovieDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TheatreDetails>> PostMovieDetail(TheatreDetails theatreDetail)
        {
            await _theatreDetailsRepository.AddAsync(theatreDetail);

            return CreatedAtAction("GetTheatreDetail", new { id = theatreDetail.Id }, theatreDetail);
        }

        // DELETE: api/MovieDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovieDetail(int id)
        {
            var movieDetail = await GetTheatreDetail(id);
            if (movieDetail == null)
            {
                return NotFound();
            }

            await _theatreDetailsRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> MovieDetailExists(int id)
        {
            return await _theatreDetailsRepository.Exists(id);
        }
    }
}
