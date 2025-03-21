using Es_sett17_NicolasO.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class PrenotazioneService
{
    private readonly AppDbContext _context;

    public PrenotazioneService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Prenotazione>> GetAllAsync()
    {
        return await _context.Prenotazioni
            .Include(p => p.Cliente)
            .Include(p => p.Camera)
            .ToListAsync();
    }

    public async Task<Prenotazione?> GetByIdAsync(int id)
    {
        return await _context.Prenotazioni
            .Include(p => p.Cliente)
            .Include(p => p.Camera)
            .FirstOrDefaultAsync(p => p.PrenotazioneId == id);
    }

    public async Task AddAsync(Prenotazione prenotazione)
    {
        _context.Prenotazioni.Add(prenotazione);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var prenotazione = await _context.Prenotazioni.FindAsync(id);
        if (prenotazione != null)
        {
            _context.Prenotazioni.Remove(prenotazione);
            await _context.SaveChangesAsync();
        }
    }
}
