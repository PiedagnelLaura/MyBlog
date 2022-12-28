using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBlog.Data;
using MyBlog.Models;
using MyBlog.Repository.Context;

namespace MyBlog.Controllers
{
    public class ArticleEfController : Controller
    {
        private readonly DbBlogContext _context;

        public ArticleEfController(DbBlogContext context)
        {
            _context = context;
        }

        // GET: ArticleEf
        public async Task<IActionResult> Index()
        {
              return View(await _context.Articles.ToListAsync());
        }

        // GET: ArticleEf/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Articles == null)
            {
                return NotFound();
            }

            var articlesModel = await _context.Articles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (articlesModel == null)
            {
                return NotFound();
            }

            return View(articlesModel);
        }

        // GET: ArticleEf/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ArticleEf/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Content,Available")] ArticlesModel articlesModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(articlesModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(articlesModel);
        }

        // GET: ArticleEf/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Articles == null)
            {
                return NotFound();
            }

            var articlesModel = await _context.Articles.FindAsync(id);
            if (articlesModel == null)
            {
                return NotFound();
            }
            return View(articlesModel);
        }

        // POST: ArticleEf/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Content,Available")] ArticlesModel articlesModel)
        {
            if (id != articlesModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(articlesModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticlesModelExists(articlesModel.Id))
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
            return View(articlesModel);
        }

        // GET: ArticleEf/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Articles == null)
            {
                return NotFound();
            }

            var articlesModel = await _context.Articles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (articlesModel == null)
            {
                return NotFound();
            }

            return View(articlesModel);
        }

        // POST: ArticleEf/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Articles == null)
            {
                return Problem("Entity set 'MyBlogContext.ArticlesModel'  is null.");
            }
            var articlesModel = await _context.Articles.FindAsync(id);
            if (articlesModel != null)
            {
                _context.Articles.Remove(articlesModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticlesModelExists(int id)
        {
          return _context.Articles.Any(e => e.Id == id);
        }
    }
}
