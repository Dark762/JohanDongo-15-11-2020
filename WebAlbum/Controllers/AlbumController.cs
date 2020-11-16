using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAlbum.Helper;
using WebAlbum.Models;

namespace WebAlbum.Controllers
{
    public class AlbumController : Controller
    {
      
        ServiceHelper service = new ServiceHelper();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListaAlbum()
        {
            var result = service.getListaAlbum();

            return Json(result, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult AlbumPhotos(ALbumModel request)
        {

            var result = service.getListaPhotos(request);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ComentarioPhoto(PhotoModel request)
        {

            var result = service.getComentarioPhoto(request);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}