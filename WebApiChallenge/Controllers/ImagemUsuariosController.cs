using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiChallenge.Models;

[Route("api/[controller]")]
[ApiController]
public class ImagemUsuarioController : ControllerBase
{
    private readonly AppDbContext _context;

    public ImagemUsuarioController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ImagemUsuario>>> GetImagensUsuarios()
    {
        return await _context.ImagensUsuarios.Include(i => i.Usuario).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ImagemUsuario>> GetImagemUsuario(int id)
    {
        var imagemUsuario = await _context.ImagensUsuarios.Include(i => i.Usuario).FirstOrDefaultAsync(i => i.ImagemUsuarioId == id);

        if (imagemUsuario == null)
        {
            return NotFound();
        }

        return imagemUsuario;
    }

    [HttpPost]
    public async Task<ActionResult<ImagemUsuario>> PostImagemUsuario(ImagemUsuario imagemUsuario)
    {
        var usuario = await _context.Usuarios.FindAsync(imagemUsuario.UsuarioId);
        if (usuario == null)
        {
            return BadRequest($"Usuário com ID {imagemUsuario.UsuarioId} não encontrado.");
        }

        _context.ImagensUsuarios.Add(imagemUsuario);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetImagemUsuario), new { id = imagemUsuario.ImagemUsuarioId }, imagemUsuario);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutImagemUsuario(int id, ImagemUsuario imagemUsuario)
    {
        if (id != imagemUsuario.ImagemUsuarioId)
        {
            return BadRequest("ID da imagem não corresponde ao ID fornecido.");
        }

        var usuario = await _context.Usuarios.FindAsync(imagemUsuario.UsuarioId);
        if (usuario == null)
        {
            return BadRequest($"Usuário com ID {imagemUsuario.UsuarioId} não encontrado.");
        }

        _context.Entry(imagemUsuario).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ImagemUsuarioExists(id))
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

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteImagemUsuario(int id)
    {
        var imagemUsuario = await _context.ImagensUsuarios.FindAsync(id);
        if (imagemUsuario == null)
        {
            return NotFound();
        }

        _context.ImagensUsuarios.Remove(imagemUsuario);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ImagemUsuarioExists(int id)
    {
        return _context.ImagensUsuarios.Any(e => e.ImagemUsuarioId == id);
    }
}
