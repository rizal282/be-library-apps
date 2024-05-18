using System.Data;
using apilibraryapps.Data;
using apilibraryapps.Data.Response;
using apilibraryapps.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace apilibraryapps.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransaksiBukuController : ControllerBase
{
    private readonly AppDbContext _context;

    public TransaksiBukuController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("getalltransaksi")]
    public async Task<ActionResult<List<object>>> GetAllTransaksi(
        string nimMhs = null,
        string namaMhs = null,
        int idBuku = 0,
        string namaBuku = null,
        string tglPinjam = null,
        string tglKembali = null,
        int lamaPinjam = 0,
        int page = 1,
        int perPage = 10
    )
    {

        var queryTrnBuku = _context.TransaksiBukus
            .Include(tb => tb.Buku)
            .Include(tb => tb.Mahasiswa)
            .Select(tb => new { 
                tb.Id,
                tb.Mahasiswa!.NimMhs,
                tb.Mahasiswa.NamaMhs,
                tb.Buku!.NamaBuku,
                tb.IdBuku,
                tb.TglPinjam,
                tb.TglKembali,
                tb.LamaPinjam
            });


        if(nimMhs != null){
            queryTrnBuku = queryTrnBuku.Where(tb => tb.NimMhs == nimMhs);
        }   

        if(namaMhs != null){
            queryTrnBuku = queryTrnBuku.Where(tb => tb.NamaMhs == namaBuku);
        }

        if (idBuku != 0){
            queryTrnBuku = queryTrnBuku.Where(tb => tb.IdBuku == idBuku);
        }

        if (tglPinjam != null){
            queryTrnBuku = queryTrnBuku.Where(tb => tb.TglPinjam == tglPinjam);
        }

        if (tglKembali != null){
            queryTrnBuku = queryTrnBuku.Where(tb => tb.TglKembali == tglKembali);
        }

        if (lamaPinjam != 0){
            queryTrnBuku = queryTrnBuku.Where(tb => tb.LamaPinjam == lamaPinjam);
        }

        var listTrnBuku = await queryTrnBuku
            .Skip((page - 1) * perPage)
            .Take(perPage)
            .ToListAsync();


        return Ok(listTrnBuku);
    }

    [HttpPost("createtransaksi")]
    public async Task<IActionResult> CreateTransaksi(TransaksiBuku transaksi)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.TransaksiBukus.Add(transaksi);
        await _context.SaveChangesAsync();

        return Ok(transaksi);
    }
}