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
    public class SeatsController : ControllerBase
    {        
        private readonly ISeatsRepository _seatsRepository;

        public SeatsController(ISeatsRepository seatsRepository)
        {
            this._seatsRepository = seatsRepository;
        }

        // GET: api/MovieDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<seats>>> Getseats()
        {
            return await _seatsRepository.GetAllAsync();
        }
        [HttpGet("byrow/{row}")]
        public async Task<ActionResult<IEnumerable<seats>>> Getseatsbyrow(string row)
        {
            return await _seatsRepository.GetSeatsByRow(row);
        }
        // GET: api/MovieDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<seats>> Getseat(int id)
        {
            var seat = await _seatsRepository.GetAsync(id);
            if (seat == null)
            {
                return NotFound();
            }

            return seat;
        }    
    }
}
