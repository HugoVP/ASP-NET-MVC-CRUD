using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TableResult()
        {
            using (var context = new SalesEntities())
            {
                var result = context.Search(string.Empty, true).ToList();
                return PartialView(result);
            }
        }
    }
}