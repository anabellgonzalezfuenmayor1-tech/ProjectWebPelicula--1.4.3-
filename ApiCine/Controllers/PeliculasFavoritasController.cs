using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiProyectoPeliculas.Models;

[Route("api/[controller]")]
[ApiController]
public class PeliculasFavoritasController : ControllerBase
{
    private readonly DbCineContext _context;
    public PeliculasFavoritasController(DbCineContext context)
    {
        _context = context;
    }

    // GET: api/PeliculasFavoritas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PeliculasFavoritas>>> GetPeliculasFavoritas()
    {
        return await _context.PeliculasFavoritas.ToListAsync();
    }

    // GET: api/PeliculasFavoritas/5
    [HttpGet("{id}")]
    public async Task<ActionResult<List<PeliculasFavoritas>>> GetPeliculasFavoritas(int id)
    {

        var peliculasFavoritas = await _context.PeliculasFavoritas
                        .Where(p => p.UsuarioId == id)
                        .ToListAsync(); 

        if (peliculasFavoritas == null)
        {
            return NotFound();
        }

        return peliculasFavoritas;
    }

    // PUT: api/PeliculasFavoritas/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPeliculasFavoritas(int? id, PeliculasFavoritas peliculasFavoritas)
    {
        if (id != peliculasFavoritas.Id)
        {
            return BadRequest();
        }

        _context.Entry(peliculasFavoritas).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PeliculasFavoritasExists(id))
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

    // POST: api/PeliculasFavoritas
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<PeliculasFavoritas>> PostPeliculasFavoritas(PeliculasFavoritas peliculasfavoritas)
    {
        _context.PeliculasFavoritas.Add(peliculasfavoritas);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetPeliculasFavoritas", new { id = peliculasfavoritas.Id }, peliculasfavoritas);
    }

    // DELETE: api/PeliculasFavoritas/5
    [HttpDelete("{userId}/{peliculaId}")]
    public async Task<IActionResult> DeletePeliculasFavoritas(int? userId, int? peliculaId)
    {
        var peliculasfavoritas = await _context.PeliculasFavoritas.FirstOrDefaultAsync(p => p.UsuarioId == userId && p.PeliculaId == peliculaId);
        if (peliculasfavoritas == null)
        {
            return NotFound();
        }

        _context.PeliculasFavoritas.Remove(peliculasfavoritas);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PeliculasFavoritasExists(int? id)
    {
        return _context.PeliculasFavoritas.Any(e => e.Id == id);
    }
}
