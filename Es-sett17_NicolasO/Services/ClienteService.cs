using Es_sett17_NicolasO.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ClienteService
{
    private readonly AppDbContext _context;

    public ClienteService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Cliente>> GetAllAsync()
    {
        return await _context.Clienti.ToListAsync();
    }

    public async Task<Cliente?> GetByIdAsync(int id)
    {
        return await _context.Clienti.FindAsync(id);
    }

    public async Task AddAsync(Cliente cliente)
    {
        _context.Clienti.Add(cliente);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Cliente cliente)
    {
        _context.Clienti.Update(cliente);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var cliente = await _context.Clienti.FindAsync(id);
        if (cliente != null)
        {
            _context.Clienti.Remove(cliente);
            await _context.SaveChangesAsync();
        }
    }
}
