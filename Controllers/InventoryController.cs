using apilibraryapps.Data;
using apilibraryapps.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apilibraryapps.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InventoryController : ControllerBase
{
    private readonly AppDbContext _context;

    public InventoryController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("getallinventory")]
    public async Task<ActionResult> GetAllInventory()
    {
        var listInventory = await _context.Inventories.ToListAsync();
        return Ok(listInventory);
    }

    [HttpPost("createrakbuku")]
    public async Task<ActionResult> CreateRakBuku(Inventory inventory)
    {
         if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Inventories.Add(inventory);
        await _context.SaveChangesAsync();

        return Ok(inventory);
    }
}