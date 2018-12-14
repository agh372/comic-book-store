using ComicBookStore.Models;
using ComicBookStore.Manager;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComicBookStore.Controllers
{
    public class ComicBooksController : Controller
    {
        public ActionResult Detail()
        {
           ViewBag.Title =  MarvelDataManager.GetInstance().GetData();
            var comic = new ComicBook();
            return View();
        }
    }
}