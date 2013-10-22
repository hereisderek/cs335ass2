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
    public class WebGridOdataController : Controller
    {
        //
        // GET: /WebGridOdata/

        public ActionResult WebGridOdata(int page = 1, int rowsPerPage = 10, string sort = "ProductID", string sortDir = "ASC")
        {
            var oData = new DataServiceContext(new Uri("http://services.odata.org/Northwind/Northwind.svc/"));

            var P1 =
                (QueryOperationResponse<Product>)oData.Execute<Product>(
                new Uri("http://services.odata.org/Northwind/Northwind.svc/Products()?$inlinecount=allpages&$orderby=Category/CategoryName,ProductID&$top=20&$expand=Category,Supplier&$select=ProductID,ProductName,Category/CategoryName,Supplier/CompanyName,Supplier/Country"));
            var P2 =
                (QueryOperationResponse<Product>)oData.Execute<Product>(
                new Uri("http://services.odata.org/Northwind/Northwind.svc/Products()?$inlinecount=allpages&$orderby=Category/CategoryName,ProductID&$skip=20&$top=20&$expand=Category,Supplier&$select=ProductID,ProductName,Category/CategoryName,Supplier/CompanyName,Supplier/Country"));
            var P3 =
                (QueryOperationResponse<Product>)oData.Execute<Product>(
                new Uri("http://services.odata.org/Northwind/Northwind.svc/Products()?$inlinecount=allpages&$orderby=Category/CategoryName,ProductID&$skip=40&$top=20&$expand=Category,Supplier&$select=ProductID,ProductName,Category/CategoryName,Supplier/CompanyName,Supplier/Country"));
            var P4 =
                (QueryOperationResponse<Product>)oData.Execute<Product>(
                new Uri("http://services.odata.org/Northwind/Northwind.svc/Products()?$inlinecount=allpages&$orderby=Category/CategoryName,ProductID&$skip=60&$top=17&$expand=Category,Supplier&$select=ProductID,ProductName,Category/CategoryName,Supplier/CompanyName,Supplier/Country"));

            var r = from p in P1
                    select new JointProductModel
                    {
                        ProductID = p.ProductID,
                        ProductName = p.ProductName,
                        CategoryName = p.Category.CategoryName,
                        CompanyName = p.Supplier.CompanyName,
                        Country = p.Supplier.Country
                    };

            var t = from p in P2
                    select new JointProductModel
                    {
                        ProductID = p.ProductID,
                        ProductName = p.ProductName,
                        CategoryName = p.Category.CategoryName,
                        CompanyName = p.Supplier.CompanyName,
                        Country = p.Supplier.Country
                    };

            var y = from p in P3
                    select new JointProductModel
                    {
                        ProductID = p.ProductID,
                        ProductName = p.ProductName,
                        CategoryName = p.Category.CategoryName,
                        CompanyName = p.Supplier.CompanyName,
                        Country = p.Supplier.Country
                    };

            var u = from p in P4
                    select new JointProductModel
                    {
                        ProductID = p.ProductID,
                        ProductName = p.ProductName,
                        CategoryName = p.Category.CategoryName,
                        CompanyName = p.Supplier.CompanyName,
                        Country = p.Supplier.Country
                    };

            ViewBag.page = page;
            ViewBag.rowsPerPage = rowsPerPage;
            ViewBag.sort = sort;
            ViewBag.sortDir = sortDir;

            IEnumerable<JointProductModel> toShow = r.Concat(t).Concat(y).Concat(u).ToArray();

            ViewBag.count = toShow.Count();

            var table = toShow.AsQueryable().OrderBy(sort + " " + sortDir).Skip((page - 1) * rowsPerPage).Take(rowsPerPage);
            return View(table);
        }
    }
}
