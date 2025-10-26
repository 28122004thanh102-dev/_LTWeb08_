using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _LTWeb08_.Models;

namespace _LTWeb08_.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        QL_TinTucEntities3 data = new QL_TinTucEntities3();
        public ActionResult Index()
        {
            List<TheLoaiTin> ds = data.TheLoaiTins.ToList();
            return View(ds);
        }
        public ActionResult ThemMoi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(TheLoaiTin ltin)
        {
            data.TheLoaiTins.Add(ltin);
            data.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var EB_tin = data.TheLoaiTins.First(m => m.IDLoai == id);
            return View(EB_tin);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var Ltin = data.TheLoaiTins.First(m => m.IDLoai == id);
            var E_Loaitin = collection["Tentheloai"];
            Ltin.IDLoai = id;
            Ltin.TenTheLoai = E_Loaitin;
            UpdateModel(Ltin);
            data.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var Details_tin = data.TheLoaiTins.Where(m => m.IDLoai == id).First();
            return View(Details_tin);
        }
        public ActionResult Delete(int id)
        {
            var D_tin = data.TheLoaiTins.First(m => m.IDLoai == id);
            data.TheLoaiTins.Remove(D_tin);
            data.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
