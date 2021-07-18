
using ASP.NET_Core_MVS_Practise.Data;
using ASP.NET_Core_MVS_Practise.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net.Practice_Forms.Controllers
{
    [Authorize]
    public class ToDoController : Controller
    {
        private readonly UsersContext db;
        public ToDoController(UsersContext toDoTaskService)
        {
            db = toDoTaskService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                IQueryable<ToDo> items = from i in db.ToDos orderby i.Id select i;

                List<ToDo> toDo = await items.ToListAsync();
                return View(toDo);
            }
            return Content("не аутентифицирован");
        }
        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ToDo item)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    db.Add(item);
                    await db.SaveChangesAsync();

                    TempData["Success"] = "Todo has been added";
                    return RedirectToAction("Index");
                }
            }
            return Content("не аутентифицирован");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                ToDo item = await db.ToDos.FindAsync(id);
                if (item == null)
                {
                    return NotFound();
                }
                return View(item);
            }
            return Content("не аутентифицирован");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ToDo item)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    db.Update(item);
                    await db.SaveChangesAsync();

                    TempData["Success"] = "Todo has been updated";
                    return RedirectToAction("Index");
                }
            }
            return Content("не аутентифицирован");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                ToDo item = await db.ToDos.FindAsync(id);
                if (item == null)
                {
                    TempData["Error"] = "ToDo item has doesnt exist";
                    return NotFound();
                }
                  return View(item);
            }
            return Content("не аутентифицирован");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(ToDo item)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    db.Remove(item);
                    await db.SaveChangesAsync();
                    TempData["Success"] = "Todo has been updated";
                    return RedirectToAction("Index");
                }
            }
            return Content("не аутентифицирован");
        }
    }
}
