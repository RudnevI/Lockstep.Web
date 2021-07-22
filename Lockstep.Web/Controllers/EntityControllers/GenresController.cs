using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LockStep.Library.Domain;
using Lockstep.Web.Data;
using Lockstep.Web.Interfaces;
using MediatR;
using Lockstep.Web.CQRS.Queries.GenreQueries;
using Lockstep.Web.CQRS.Commands.GenreCommands;

namespace Lockstep.Web.Controllers.EntityControllers
{
    public class GenresController : Controller
    {
       
        private readonly IMediator _mediator;
        

        public GenresController(IMediator mediator)
        {
            _mediator = mediator;
        }




        // GET: Genres
        public async Task<IActionResult> Index()
        {
            return View(await _mediator.Send(new GetAllGenresQuery()));
        }

        // GET: Genres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genre = await _mediator.Send(new GetGenreByIdQuery { Id = id});
            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }

        // GET: Genres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Genres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Genre genre)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(new CreateGenreCommand { Name = genre.Name });
                return RedirectToAction(nameof(Index));
            }
            return View(genre);
        }

        // GET: Genres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genre = await _mediator.Send(new GetGenreByIdQuery { Id = id });
            if (genre == null)
            {
                return NotFound();
            }
            return View(genre);
        }

        // POST: Genres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Genre genre)
        {
            if (id != genre.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _mediator.Send(new UpdateGenreCommand { Name = genre.Name });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenreExists(genre.Id))
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
            return View(genre);
        }

        // GET: Genres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genre = await _mediator.Send(new GetGenreByIdQuery { Id = id });
            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }

        // POST: Genres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            await _mediator.Send(new DeleteGenreCommand { Id = id });
            return RedirectToAction(nameof(Index));
        }

        private bool GenreExists(int id)
        {
            return _mediator.Send(new GetGenreByIdQuery { Id=id}) != null;
        }
    }
}
