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
    public class CouponsController : ControllerBase
    {
        private readonly ICouponRepository _couponRepository;

        public CouponsController(ICouponRepository couponRepository)
        {
            this._couponRepository = couponRepository;
        }

        // GET: api/Coupons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<coupons>>> GetCoupons()
        {
            return await _couponRepository.GetAllAsync();
        }

        // GET: api/Coupons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<coupons>> Getcoupon(int id)
        {
            var coupon = await _couponRepository.GetAsync(id);

            if (coupon == null)
            {
                return NotFound();
            }

            return coupon;
        }

        // PUT: api/Coupons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putcoupons(int id, coupons coupon)
        {
            if (id != coupon.Id)
            {
                return BadRequest();
            }           

            try
            {
                await _couponRepository.UpdateAsync(coupon);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await couponsExists(id))
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

        // POST: api/Coupons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<coupons>> Postcoupons(coupons coupon)
        {
            await _couponRepository.AddAsync(coupon);

            return CreatedAtAction("Getcoupons", new { id = coupon.Id }, coupon);
        }

        // DELETE: api/Coupons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletecoupons(int id)
        {
            var coupon = await Getcoupon(id);
            if (coupon == null)
            {
                return NotFound();
            }

            await _couponRepository.DeleteAsync(id);
            return NoContent();
        }

        private async Task<bool> couponsExists(int id)
        {
            return await _couponRepository.Exists(id);
        }
    }
}
