using Es_sett17_NicolasO.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Authorize(Roles = "Admin,Receptionist")]
public class CameraController : Controller
{
    private readonly AppDbContext _context;

    public CameraController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.Camere.ToListAsync());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Camera camera)
    {
        if (ModelState.IsValid)
        {
            _context.Add(camera);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(camera);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var camera = await _context.Camere.FindAsync(id);
        if (camera == null) return NotFound();
        return View(camera);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Camera camera)
    {
        if (id != camera.CameraId) return NotFound();

        if (ModelState.IsValid)
        {
            _context.Update(camera);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(camera);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var camera = await _context.Camere.FindAsync(id);
        if (camera == null) return NotFound();

        _context.Camere.Remove(camera);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
