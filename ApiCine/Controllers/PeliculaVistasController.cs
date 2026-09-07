using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiProyectoPeliculas.Models;

[Route("api/[controller]")]
[ApiController]
public class PeliculaVistasController : ControllerBase
{
    private readonly DbCineContext _context;
    public PeliculaVistasController(DbCineContext context)
    {
        _context = context;
    }

    // GET: api/PeliculaVista
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PeliculaVista>>> GetPeliculaVista()
    {
        return await _context.PeliculaVista.ToListAsync();
    }

    // GET: api/PeliculaVista/5
    [HttpGet("{id}")]
    public async Task<ActionResult<PeliculaVista>> GetPeliculaVista(int id)
    {
        var peliculavista = await _context.PeliculaVista.FindAsync(id);

        if (peliculavista == null)
        {
            return NotFound();
        }

        return peliculavista;
    }

    // PUT: api/PeliculaVista/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPeliculaVista(int? id, PeliculaVista peliculavista)
    {
        if (id != peliculavista.Id)
        {
            return BadRequest();
        }

        _context.Entry(peliculavista).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PeliculaVistaExists(id))
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

    // POST: api/PeliculaVista
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<PeliculaVista>> PostPeliculaVista(PeliculaVista peliculavista)
    {
        _context.PeliculaVista.Add(peliculavista);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetPeliculaVista", new { id = peliculavista.Id }, peliculavista);
    }

    // DELETE: api/PeliculaVista/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePeliculaVista(int? id)
    {
        var peliculavista = await _context.PeliculaVista.FindAsync(id);
        if (peliculavista == null)
        {
            return NotFound();
        }

        _context.PeliculaVista.Remove(peliculavista);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PeliculaVistaExists(int? id)
    {
        return _context.PeliculaVista.Any(e => e.Id == id);
    }
}
