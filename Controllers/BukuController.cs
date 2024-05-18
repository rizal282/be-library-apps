using apilibraryapps.Data;
using apilibraryapps.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apilibraryapps.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BukuController : ControllerBase
{

    private readonly AppDbContext _context;
    public BukuController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return Ok("Ok");
    }

    [HttpGet("getallbuku")]
    public async Task<IEnumerable<Buku>> GetAllBuku()
    {
        return await _context.Bukus.ToListAsync();
    }

    [HttpPost("createbuku")]
    public async Task<ActionResult> CreateBuku(Buku buku)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Bukus.Add(buku);
        await _context.SaveChangesAsync();

        return Ok(buku);

    }

    [HttpGet("getbukubystok")]
    public async Task<IActionResult> GetBukuByStok() {

        var listBukuByStok = await _context.Bukus.Where(buku => buku.StokBuku > 0).OrderBy(b => b.NamaBuku).ToListAsync();

        return Ok(listBukuByStok);
    }
}