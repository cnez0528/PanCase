using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Pancase.Controllers
{
    public class CaseController : Controller
    {
        // GET: CaseController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CaseController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CaseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CaseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CaseController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CaseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CaseController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CaseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
