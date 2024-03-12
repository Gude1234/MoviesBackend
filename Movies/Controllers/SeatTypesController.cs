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
    public class SeatTypesController : ControllerBase
    {        
        private readonly ISeatTypeRespository _seatTypeRespository;

        public SeatTypesController(ISeatTypeRespository seatTypeRespository)
        {
            this._seatTypeRespository = seatTypeRespository;
        }

        // GET: api/MovieDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SeatType>>> GetSeatTypes()
        {
            return await _seatTypeRespository.GetAllAsync();
        }

        // GET: api/MovieDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SeatType>> GetSeatType(int id)
        {
            var seatType = await _seatTypeRespository.GetAsync(id);

            if (seatType == null)
            {
                return NotFound();
            }

            return seatType;
        }

        // PUT: api/MovieDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeatType(int id, SeatType seatType)
        {
            if (id != seatType.Id)
            {
                return BadRequest();
            }

            

            try
            {
                await _seatTypeRespository.UpdateAsync(seatType);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await SeatTypeExists(id))
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
        public async Task<ActionResult<SeatType>> PostSeatType(SeatType seatType)
        {
            await _seatTypeRespository.AddAsync(seatType);

            return CreatedAtAction("GetSeatType", new { id = seatType.Id }, seatType);
        }

        // DELETE: api/MovieDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeatType(int id)
        {
            var seatType = await GetSeatType(id);
            if (seatType == null)
            {
                return NotFound();
            }

            await _seatTypeRespository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> SeatTypeExists(int id)
        {
            return await _seatTypeRespository.Exists(id);
        }
    }
}
