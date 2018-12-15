using ComicBookStore.Models;
using ComicBookStore.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComicBookStore.Controllers
{
    public class ComicBooksController : Controller
    {
        public ActionResult Index(int page = 0)
        {
            var dataSource = MarvelDataRepository.GetInstance().GetAllComics();
            const int PageSize = 6; 
            var count = dataSource.Count();

            var data = dataSource.Skip(page * PageSize).Take(PageSize).ToList();

            this.ViewBag.MaxPage = (count / PageSize) - (count % PageSize == 0 ? 1 : 0);

            this.ViewBag.Page = page;

            return this.View(data);
        }
    }
}