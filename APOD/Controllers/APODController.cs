﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using APOD.Data;
using APOD.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using PagedList;
using System.Diagnostics.Contracts;

namespace APOD.Controllers
{
    public class APODAndCommentViewModel
    {
        public APODModel APOD { get; set; }
        public CommentModel New_Comment { get; set; }
        public List<CommentModel> Comment { get; set; }
    }

    public class APODController : Controller
    {
        private readonly APODContext _context;

        public APODController(APODContext context)
        {
            _context = context;
        }

        // GET: APOD
        public async Task<IActionResult> Index(int? page)
        {
            using var httpClient = new HttpClient();
            var apiKey = "qGLChofuLpstXN2oFvwUGl7nmIdKmRMSy3sEiLuR";
            var apiUrl = $"https://api.nasa.gov/planetary/apod?api_key={apiKey}";
            var response = await httpClient.GetAsync(apiUrl);
            var responseContent = await response.Content.ReadAsStringAsync();

            var json = JObject.Parse(responseContent);

			var model = new APODModel
			{
				Url = (string)json["url"],
				Title = (string)json["title"],
				Explanation = (string)json["explanation"],
				Date = (string)json["date"]
			};
			var apodList = _context.APODModel.Where(APOD => APOD.Title == model.Title).FirstOrDefault();

			if (apodList == null)
			{
				_context.Add(model);
				await _context.SaveChangesAsync();
			}

			int pageSize = 12;
            int pageNumber = page ?? 1;

            ViewData["CurrentPage"] = pageNumber;
            ViewData["TotalPage"] = Math.Ceiling((double)_context.APODModel.Count() / pageSize); ;

            return View(await _context.APODModel
                .OrderByDescending(APOD => APOD.Date)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync());
        }

        // GET: APODs/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.APODModel == null)
            {
                return NotFound();
            }

            var apodModel = await _context.APODModel.FirstOrDefaultAsync(m => m.Id == id);
            if (apodModel == null)
            {
                return NotFound();
            }

            var commentModel = _context.CommentModel.Where(c => c.PostId == id).OrderByDescending(d => d.Date).ToList();
            var viewModel = new APODAndCommentViewModel
            {
                APOD = apodModel,
                New_Comment = new CommentModel(),
                Comment = commentModel,
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Details(int id, [Bind("APOD,New_Comment,Comment")] APODAndCommentViewModel commentModel)
        {
			DateTime utcNow = DateTime.UtcNow;
			TimeZoneInfo kst = TimeZoneInfo.FindSystemTimeZoneById("Korea Standard Time");
			DateTime kstNow = TimeZoneInfo.ConvertTimeFromUtc(utcNow, kst);

			commentModel.New_Comment.Date = kstNow;
            commentModel.New_Comment.PostId = id;

            _context.CommentModel.Add(commentModel.New_Comment);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { id = commentModel.New_Comment.PostId });
        }

        // GET: APODs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: APODs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,date,explanation")] APODModel aPOD)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aPOD);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aPOD);
        }

        // GET: APODs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.APODModel == null)
            {
                return NotFound();
            }

            var aPOD = await _context.APODModel.FindAsync(id);
            if (aPOD == null)
            {
                return NotFound();
            }
            return View(aPOD);
        }

        // POST: APODs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,date,explanation")] APODModel aPOD)
        {
            if (id != aPOD.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aPOD);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!APODExists(aPOD.Id))
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
            return View(aPOD);
        }

        // GET: APODs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.APODModel == null)
            {
                return NotFound();
            }

            var aPOD = await _context.APODModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aPOD == null)
            {
                return NotFound();
            }

            return View(aPOD);
        }

        // POST: APODs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.APODModel == null)
            {
                return Problem("Entity set 'APODContext.APOD'  is null.");
            }
            var aPOD = await _context.APODModel.FindAsync(id);
            if (aPOD != null)
            {
                _context.APODModel.Remove(aPOD);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete_Comment(int id, int postid, string password)
        {

			var commentModel = await _context.CommentModel.FindAsync(id);
            if (commentModel != null) {
                if(password == commentModel.Password) {
					_context.CommentModel.Remove(commentModel);
					await _context.SaveChangesAsync();
					return RedirectToAction(nameof(Details), new { id = postid });
				}
                else
                {
					TempData["msg"] = "<script>alert('비밀번호가 일치하지 않습니다.');</script>";
					return RedirectToAction(nameof(Details), new { id = postid });
				}
            }
			TempData["msg"] = "<script>alert('비밀번호가 일치하지 않습니다.');</script>";
			return RedirectToAction(nameof(Details), new { id = postid });
		}

        private bool APODExists(int id)
        {
          return (_context.APODModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public IActionResult Random()
        {
            return View();
        }

        public IActionResult Calendar()
        {
            return View();
        }
    }
}
