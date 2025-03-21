using Es_sett17_NicolasO.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Authorize(Roles = "Admin,Receptionist")]
public class ClienteController : Controller
{
    private readonly AppDbContext _context;

    public ClienteController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.Clienti.ToListAsync());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Cliente cliente)
    {
        if (ModelState.IsValid)
        {
            _context.Add(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(cliente);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var cliente = await _context.Clienti.FindAsync(id);
        if (cliente == null) return NotFound();
        return View(cliente);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Cliente cliente)
    {
        if (id != cliente.ClienteId) return NotFound();

        if (ModelState.IsValid)
        {
            _context.Update(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(cliente);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var cliente = await _context.Clienti.FindAsync(id);
        if (cliente == null) return NotFound();

        _context.Clienti.Remove(cliente);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
