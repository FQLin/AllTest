using Demo1.Framework.Core;
using Demo1.Framework.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo1.Controllers
{
    public class HomeController : Controller
    {
        private readonly Demo1Context _db;
        public HomeController(Demo1Context db)
        {
            this._db = db;
        }
        public IActionResult Index()
        {
            this._db.Demo1.Add(new tbl_Demo1()
            {
                Id = Guid.NewGuid().ToString("N"),
                Name = DateTime.Now.ToString(),
                Age = 18
            });
            this._db.SaveChanges();
            List<tbl_Demo1> demo1s = this._db.Demo1.Where(d => d.Id == "1").ToList();

            return Content("this message from home index");
            //return View();
        }
    }
}
