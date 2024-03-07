using Bank_Api.Data;
using Bank_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;

namespace Bank_Api.Controllers
{
    // UserController.cs
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("{userId}/add-bank-details")]
        public async Task<IActionResult> createuser([FromBody] UserProfile user)
        {
            _context.UserProfile.Add(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddBankDetails(int Id,[FromBody] BankDetails bankDetail)
        {
            var user = await _context.UserProfile.FindAsync(Id);

            if (user == null)
            {
                return NotFound($"User with ID {Id} not found.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.BankDetail.Add(bankDetail);

            await _context.SaveChangesAsync();

            return Ok("Bank details added.");
        }

    }


}
