using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cs335.Models;
using System.Linq.Dynamic;
using System.Xml.Linq;
using System.Data.Services.Client;

namespace cs335.Controllers
{
    public class WebGridSqlController : Controller
    {
        //
        // GET: /WebGridSql/

        public ActionResult WebGridSql(int page = 1, int rowsPerPage = 10, string sort = "ProductID", string sortDir = "ASC")
        {
            var sql = new cs335DBDataContext();
            var r =
                from p in sql.Products
                join c in sql.Categories
                on p.CategoryID equals c.CategoryID
                join s in sql.Suppliers
                on p.SupplierID equals s.SupplierID
                orderby p.ProductID ascending
                select new JointProductModel
                {
                    ProductID = p.ProductID,
                    ProductName = p.ProductName,
                    CategoryName = c.CategoryName,
                    CompanyName = s.CompanyName,
                    Country = s.Country
                };

            ViewBag.page = page;
            ViewBag.rowsPerPage = rowsPerPage;
            ViewBag.sort = sort;
            ViewBag.sortDir = sortDir;
            ViewBag.count = r.Count();

            var table = r.AsQueryable().OrderBy(sort + " " + sortDir).Skip((page - 1) * rowsPerPage).Take(rowsPerPage);
            return View(table);
        }

    }
}
