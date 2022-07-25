using FormulaOneApp.Data;
using FormulaOneApp.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FormulaOneApp.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public TeamController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var teams = await _context.Teams.ToListAsync();
            return Ok(teams);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var team = await _context.Teams.FirstOrDefaultAsync(x => x.Id == id);
            if (team == null)
            {
                return BadRequest("Invalid Id");
            }
            return Ok(team);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Team team)
        {
            await _context.Teams.AddAsync(team);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), team.Id, team);
        }

        [HttpPatch]
        public async Task<IActionResult> Patch(int id, string country)
        {
            var team = await _context.Teams.FirstOrDefaultAsync(x => x.Id == id);
            if (team == null)
            {
                return BadRequest("Invalid Id");
            }
            team.Country = country;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var team = await _context.Teams.FirstOrDefaultAsync(x => x.Id == id);
            if (team == null)
            {
                return BadRequest("Invalid Id");
            }
            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}