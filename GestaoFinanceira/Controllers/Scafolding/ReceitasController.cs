using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Modelo.Entidades;
using Persistencia.Context;

namespace GestaoFinanceira.Controllers.Scafolding
{
    public class ReceitasController : Controller
    {
        private readonly EFContext _context;

        public ReceitasController(EFContext context)
        {
            _context = context;
        }

        // GET: Receitas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Receitas.ToListAsync());
        }

        // GET: Receitas/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receita = await _context.Receitas
                .FirstOrDefaultAsync(m => m.ReceitaId == id);


            if (receita == null)
            {
                return NotFound();
            }

            return View(receita);
        }

        // GET: Receitas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Receitas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReceitaId,Valor,Descricao,Pago,ReceitaFixa,ReceitaParcelada,QtdParcelas,Observacao,DhReceita")] Receita receita)
        {
            if (ModelState.IsValid)
            {
                _context.Add(receita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(receita);
        }

        // GET: Receitas/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receita = await _context.Receitas.FindAsync(id);
            if (receita == null)
            {
                return NotFound();
            }
            return View(receita);
        }

        // POST: Receitas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(long id, [Bind("ReceitaId,Valor,Descricao,Pago,ReceitaFixa,ReceitaParcelada,QtdParcelas,Observacao,DhReceita")] Receita receita)
        //{
        //    if (id != receita.ReceitaId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(receita);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ReceitaExists(receita.ReceitaId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(receita);
        //}

        // GET: Receitas/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receita = await _context.Receitas
                .FirstOrDefaultAsync(m => m.ReceitaId == id);
            if (receita == null)
            {
                return NotFound();
            }

            return View(receita);
        }

        // POST: Receitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var receita = await _context.Receitas.FindAsync(id);
            _context.Receitas.Remove(receita);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReceitaExists(long id)
        {
            return _context.Receitas.Any(e => e.ReceitaId == id);
        }
    }
}
