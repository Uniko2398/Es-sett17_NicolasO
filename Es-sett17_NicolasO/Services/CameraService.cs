using Es_sett17_NicolasO.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class CameraService
{
    private readonly AppDbContext _context;

    public CameraService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Camera>> GetAllAsync()
    {
        return await _context.Camere.ToListAsync();
    }

    public async Task<Camera?> GetByIdAsync(int id)
    {
        return await _context.Camere.FindAsync(id);
    }

    public async Task AddAsync(Camera camera)
    {
        _context.Camere.Add(camera);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Camera camera)
    {
        _context.Camere.Update(camera);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var camera = await _context.Camere.FindAsync(id);
        if (camera != null)
        {
            _context.Camere.Remove(camera);
            await _context.SaveChangesAsync();
        }
    }
}
