using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LojaOnline.Contexto;
using LojaOnline.Models;

namespace LojaOnline.Controllers
{
    public class PromocoesController : Controller
    {
        private readonly Context _context;

        public PromocoesController(Context context)
        {
            _context = context;
        }

        // GET: Promocoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Promocoes.ToListAsync());
        }

        // GET: Promocoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promocao = await _context.Promocoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (promocao == null)
            {
                return NotFound();
            }

            return View(promocao);
        }

        // GET: Promocoes/Create
        public IActionResult Create()
        {
            var produtos = _context.Produtos.Where(p => p.Categoria == "Bebidas").ToList();
            return View(produtos);
        }

        // POST: Promocoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Promocao promocao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(promocao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(promocao);
        }

        // GET: Promocoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promocao = await _context.Promocoes.FindAsync(id);
            if (promocao == null)
            {
                return NotFound();
            }
            return View(promocao);
        }

        // POST: Promocoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Promocao promocao)
        {
            if (id != promocao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(promocao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PromocaoExists(promocao.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(promocao);
        }

        // GET: Promocoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promocao = await _context.Promocoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (promocao == null)
            {
                return NotFound();
            }

            return View(promocao);
        }

        // POST: Promocoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var promocao = await _context.Promocoes.FindAsync(id);
            _context.Promocoes.Remove(promocao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PromocaoExists(int id)
        {
            return _context.Promocoes.Any(e => e.Id == id);
        }
    }
}
