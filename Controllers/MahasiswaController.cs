using apilibraryapps.Data;
using apilibraryapps.Data.Response;
using apilibraryapps.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apilibraryapps.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MahasiswaController : ControllerBase
{
    private readonly AppDbContext _context;

    public MahasiswaController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("getallmahasiswa")]
    public async Task<ActionResult> GetAllMahasiswa()
    {
        var listMhs = await _context.Mahasiswas.Select(mhs => new DataMahasiswaResponse {
            NimMhs = mhs.NimMhs,
            NamaMhs = mhs.NamaMhs,
            Jurusan = mhs.Jurusan,
            StsAktif = mhs.AktifFlag ? "Aktif" : "Tidak Aktif",
        }).ToListAsync();
        return Ok(listMhs);
    }

    [HttpPost("createmahasiswa")]
    public async Task<ActionResult> CreateMahasiswa(Mahasiswa mahasiswa)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Mahasiswas.Add(mahasiswa);
        await _context.SaveChangesAsync();

        return Ok(mahasiswa);

    }

    [HttpGet("getmhsbyaaktifflag")]
    public async Task<IActionResult> GetMhsByAktifFlag()
    {
        var listMhsByAktifFlag = await _context.Mahasiswas
                                .Where(mhs => mhs.AktifFlag.Equals(true))
                                .OrderBy(m => m.NamaMhs)
                                .ToListAsync();

        return Ok(listMhsByAktifFlag);
    }
}