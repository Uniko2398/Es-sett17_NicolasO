using Es_sett17_NicolasO.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Authorize(Roles = "Admin,Receptionist")]
public class PrenotazioneController : Controller
{
    private readonly AppDbContext _context;

    public PrenotazioneController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var prenotazioni = await _context.Prenotazioni
            .Include(p => p.Cliente)
            .Include(p => p.Camera)
            .ToListAsync();
        return View(prenotazioni);
    }

    public IActionResult Create()
    {
        return PartialView("_CreatePrenotazionePartial");
    }

    [HttpPost]
    public async Task<IActionResult> Create(Prenotazione prenotazione)
    {
        if (ModelState.IsValid)
        {
            _context.Add(prenotazione);
            await _context.SaveChangesAsync();
            return Json(new { success = true });
        }
        return Json(new { success = false });
    }

    public async Task<IActionResult> Edit(int id)
    {
        var prenotazione = await _context.Prenotazioni.FindAsync(id);
        if (prenotazione == null) return NotFound();
        return PartialView("_EditPrenotazionePartial", prenotazione);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Prenotazione prenotazione)
    {
        if (id != prenotazione.PrenotazioneId) return NotFound();

        if (ModelState.IsValid)
        {
            _context.Update(prenotazione);
            await _context.SaveChangesAsync();
            return Json(new { success = true });
        }
        return Json(new { success = false });
    }

    public async Task<IActionResult> Delete(int id)
    {
        var prenotazione = await _context.Prenotazioni.FindAsync(id);
        if (prenotazione == null) return NotFound();

        _context.Prenotazioni.Remove(prenotazione);
        await _context.SaveChangesAsync();
        return Json(new { success = true });
    }
}
