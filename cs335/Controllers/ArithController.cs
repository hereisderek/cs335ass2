using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cs335.Models;
/**
 *  qzhu496
 *  2112586
 *  Qingquan Zhu
 */

namespace cs335.Controllers
{
    public class ArithController : Controller
    {
        //
        // GET: /arith/

        public ActionResult SumModelForm(int n = 300, int m = 400)
        {
            var S = new Sum { N = n, M = m };
            return View(S);
        }

    }
}
