using memes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace memes.Controllers
{
    public class MenController : Controller
    {
        private Entities shoppingEntities;
        public MenController()
        {
            shoppingEntities = new Entities();
        }

        // GET: Men
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RenderPhoto(int photoId)
        {
            byte[] photo = (new Entities()).Clothes.Find(photoId).Image;
            return File(photo, "image/jpg");
        }

        public ActionResult RenderExtraPhoto(int photoId)
        {
            byte[] photo = (new Entities()).Clothes.Find(photoId).ExtraImage;
            return File(photo, "image/jpg");
        }

        public ActionResult Details(int id)
        {
            Cloth details = shoppingEntities.Clothes.Find(id);
            return View(details);
        }

        public ActionResult TShirts()
        {
            IEnumerable<ShoppingViewModel> shoppingViewModels = (from item in shoppingEntities.Clothes
                                                                 join cate in shoppingEntities.Categories
                                                                 on item.CategoryId equals cate.CategoryId
                                                                 where item.CategoryId == 2
                                                                 select new ShoppingViewModel()
                                                                 {
                                                                     Brand = item.Brand,
                                                                     Details = item.Details,
                                                                     Category = cate.CategoryName,
                                                                     Gender = item.Gender,
                                                                     Name = item.Name,
                                                                     Price = item.Price,
                                                                     Id = item.Id,
                                                                     Image = item.Image
                                                                 }).ToList();
            return View("Hoodies", shoppingViewModels);
        }

        public ActionResult Trousers()
        {
            IEnumerable<ShoppingViewModel> shoppingViewModels = (from item in shoppingEntities.Clothes
                                                                 join cate in shoppingEntities.Categories
                                                                 on item.CategoryId equals cate.CategoryId
                                                                 where item.CategoryId == 3
                                                                 select new ShoppingViewModel()
                                                                 {
                                                                     Brand = item.Brand,
                                                                     Details = item.Details,
                                                                     Category = cate.CategoryName,
                                                                     Gender = item.Gender,
                                                                     Name = item.Name,
                                                                     Price = item.Price,
                                                                     Id = item.Id,
                                                                     Image = item.Image
                                                                 }).ToList();
            return View("Hoodies", shoppingViewModels);
        }

        public ActionResult Brands()
        {
            IEnumerable<ShoppingViewModel> shoppingViewModels = (from item in shoppingEntities.Clothes
                                                                 join cate in shoppingEntities.Categories
                                                                 on item.CategoryId equals cate.CategoryId
                                                                 where item.style == "Trending brands"
                                                                 select new ShoppingViewModel()
                                                                 {
                                                                     Brand = item.Brand,
                                                                     Details = item.Details,
                                                                     Category = cate.CategoryName,
                                                                     Gender = item.Gender,
                                                                     Name = item.Name,
                                                                     Price = item.Price,
                                                                     Id = item.Id,
                                                                     Image = item.Image,
                                                                     style = item.style
                                                                 }).ToList();
            return View("TShirts", shoppingViewModels);
        }

        public ActionResult Street()
        {
            IEnumerable<ShoppingViewModel> shoppingViewModels = (from item in shoppingEntities.Clothes
                                                                 join cate in shoppingEntities.Categories
                                                                 on item.CategoryId equals cate.CategoryId
                                                                 where item.style == "street style"
                                                                 select new ShoppingViewModel()
                                                                 {
                                                                     Brand = item.Brand,
                                                                     Details = item.Details,
                                                                     Category = cate.CategoryName,
                                                                     Gender = item.Gender,
                                                                     Name = item.Name,
                                                                     Price = item.Price,
                                                                     Id = item.Id,
                                                                     Image = item.Image,
                                                                     style = item.style
                                                                 }).ToList();
            return View("TShirts", shoppingViewModels);
        }

        public ActionResult Summer()
        {
            IEnumerable<ShoppingViewModel> shoppingViewModels = (from item in shoppingEntities.Clothes
                                                                 join cate in shoppingEntities.Categories
                                                                 on item.CategoryId equals cate.CategoryId
                                                                 where item.style == "summer 2020"
                                                                 select new ShoppingViewModel()
                                                                 {
                                                                     Brand = item.Brand,
                                                                     Details = item.Details,
                                                                     Category = cate.CategoryName,
                                                                     Gender = item.Gender,
                                                                     Name = item.Name,
                                                                     Price = item.Price,
                                                                     Id = item.Id,
                                                                     Image = item.Image,
                                                                     style = item.style
                                                                 }).ToList();
            return View("TShirts", shoppingViewModels);
        }

        public ActionResult Jackets()
        {
            IEnumerable<ShoppingViewModel> shoppingViewModels = (from item in shoppingEntities.Clothes
                                                                 join cate in shoppingEntities.Categories
                                                                 on item.CategoryId equals cate.CategoryId
                                                                 where item.CategoryId == 4
                                                                 select new ShoppingViewModel()
                                                                 {
                                                                     Brand = item.Brand,
                                                                     Details = item.Details,
                                                                     Category = cate.CategoryName,
                                                                     Gender = item.Gender,
                                                                     Name = item.Name,
                                                                     Price = item.Price,
                                                                     Id = item.Id,
                                                                     Image = item.Image
                                                                 }).ToList();
            return View("Hoodies", shoppingViewModels);
        }

        public ActionResult Hoodies()
        {
            IEnumerable<ShoppingViewModel> shoppingViewModels = (from item in shoppingEntities.Clothes
                                                                 join cate in shoppingEntities.Categories
                                                                 on item.CategoryId equals cate.CategoryId
                                                                 where item.CategoryId == 1
                                                                 select new ShoppingViewModel()
                                                                 {
                                                                     Brand = item.Brand,
                                                                     Details = item.Details,
                                                                     Category = cate.CategoryName,
                                                                     Gender = item.Gender,
                                                                     Name = item.Name,
                                                                     Price = item.Price,
                                                                     Id = item.Id,
                                                                     Image = item.Image
                                                                 }).ToList();
            return View(shoppingViewModels);
        }
    }
}