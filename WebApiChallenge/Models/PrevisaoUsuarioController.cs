using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiChallenge.Models;

[Route("api/[controller]")]
[ApiController]
public class PrevisaoUsuarioController : ControllerBase
{
    private readonly AppDbContext _context;

    public PrevisaoUsuarioController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PrevisaoUsuario>>> GetPrevisoesUsuarios()
    {
        return await _context.PrevisoesUsuarios
            .Include(p => p.ImagemUsuario)
            .Include(p => p.Usuario)
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PrevisaoUsuario>> GetPrevisaoUsuario(int id)
    {
        var previsao = await _context.PrevisoesUsuarios
            .Include(p => p.ImagemUsuario)
            .Include(p => p.Usuario)
            .FirstOrDefaultAsync(p => p.PrevisaoUsuarioId == id);

        if (previsao == null)
        {
            return NotFound();
        }

        return previsao;
    }

    [HttpPost]
    public async Task<ActionResult<PrevisaoUsuario>> PostPrevisaoUsuario(PrevisaoUsuario previsao)
    {
        
        var usuario = await _context.Usuarios.FindAsync(previsao.UsuarioId);
        if (usuario == null)
        {
            return BadRequest($"Usuário com ID {previsao.UsuarioId} não encontrado.");
        }

        
        var imagem = await _context.ImagensUsuarios.FindAsync(previsao.ImagemUsuarioId);
        if (imagem == null)
        {
            return BadRequest($"Imagem com ID {previsao.ImagemUsuarioId} não encontrada.");
        }

        _context.PrevisoesUsuarios.Add(previsao);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPrevisaoUsuario), new { id = previsao.PrevisaoUsuarioId }, previsao);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutPrevisaoUsuario(int id, PrevisaoUsuario previsao)
    {
        if (id != previsao.PrevisaoUsuarioId)
        {
            return BadRequest("ID da previsão não corresponde ao ID fornecido.");
        }

        var usuario = await _context.Usuarios.FindAsync(previsao.UsuarioId);
        if (usuario == null)
        {
            return BadRequest($"Usuário com ID {previsao.UsuarioId} não encontrado.");
        }

        var imagem = await _context.ImagensUsuarios.FindAsync(previsao.ImagemUsuarioId);
        if (imagem == null)
        {
            return BadRequest($"Imagem com ID {previsao.ImagemUsuarioId} não encontrada.");
        }

        _context.Entry(previsao).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PrevisaoUsuarioExists(id))
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
    public async Task<IActionResult> DeletePrevisaoUsuario(int id)
    {
        var previsao = await _context.PrevisoesUsuarios.FindAsync(id);
        if (previsao == null)
        {
            return NotFound();
        }

        _context.PrevisoesUsuarios.Remove(previsao);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PrevisaoUsuarioExists(int id)
    {
        return _context.PrevisoesUsuarios.Any(e => e.PrevisaoUsuarioId == id);
    }
}
