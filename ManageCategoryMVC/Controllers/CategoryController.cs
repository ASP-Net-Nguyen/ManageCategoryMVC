using ManageCategoryMVC.Data;
using ManageCategoryMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageCategoryMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            //IEnumerable<Category> objList = _db.categories;
            //return View(objList);
            var categoriesList = (from categories in _db.categories
                                  select new SelectListItem()
                                  {
                                      Text = categories.Name,
                                      Value = categories.Id.ToString()
                                  }).ToList();
            categoriesList.Insert(0, new SelectListItem()
            {
                Text = "---Select---",
                Value = string.Empty
            });

            CategoryViewModel categoryViewModel = new CategoryViewModel();
            categoryViewModel.ListOfCategories = categoriesList;
            return View(categoryViewModel);
        }
        //GET-CREATE
        public IActionResult Create()
        {
            return View();
        }
        //POST-CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View(obj);

        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var b = _db.categories.Find(id);
            if (b == null) return NotFound();

            return View(b);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.categories.Update(obj);
                _db.SaveChanges();

                return RedirectToAction("Index");

            }
            return View(obj);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var b = _db.categories.Find(id);
            if (b == null) return NotFound();

            return View(b);
        }

        [HttpPost]
        public IActionResult DeleteD(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var b = _db.categories.Find(id);
            if (b == null) return NotFound();

            _db.categories.Remove(b);
            _db.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}
