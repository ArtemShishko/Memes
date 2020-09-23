using memes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace memes.Controllers
{
    public class SearchController : Controller
    {
        Entities db = new Entities();
        // GET: Search
        [HttpGet]
        public ActionResult Index(string search)
        {
            return View(db.Clothes.Where(m => m.Name.Contains(search)));
        }
    }
}