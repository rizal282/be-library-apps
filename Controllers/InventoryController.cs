using apilibraryapps.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apilibraryapps.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InvestoryController : ControllerBase
{
    private readonly AppDbContext _context;

    public InvestoryController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult> GetAllInventory()
    {
        var listInventory = await _context.Inventories.ToListAsync();
        return Ok(listInventory);
    }
}