using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADODemoApp.Model;
using ADODemoApp.Repo;
using ADODemoApp.Web.Models;

namespace ADODemoApp.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Top5Products()
        {
            AW_ProductRepo aw_pR = new AW_ProductRepo();
            List<AW_Product> list = aw_pR.GetAll();
            return View(list);
        }

        public ActionResult GetProductsByGender()
        {
            return View();
        }

        public ActionResult ListProductsByGender(string choice)
        {
            AW_ProductModelRepo aw_pmR = new AW_ProductModelRepo();
            aw_pmR.CreateGetClothingProcedureIfNull();

            if (choice == "")
                return View("Error");

            List<AW_ProductModel> list = aw_pmR.GetProductsByGender(choice);
            return View(list);
        }
    }
}