using memes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace memes.Controllers
{
    public class WomenController : Controller
    {
        private Entities shoppingEntities;
        public WomenController()
        {
            shoppingEntities = new Entities();
        }

        public ActionResult Details(int id)
        {
            Cloth details = shoppingEntities.Clothes.Find(id);
            return View(details);
        }

        // GET: Women
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Trands()
        {
            IEnumerable<ShoppingViewModel> shoppingViewModels = (from item in shoppingEntities.Clothes
                                                                 join cate in shoppingEntities.Categories
                                                                 on item.CategoryId equals cate.CategoryId
                                                                 where item.style == "BRANDS OF THE SEASON"
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
            return View(shoppingViewModels);
        }

        public ActionResult Summer()
        {
            IEnumerable<ShoppingViewModel> shoppingViewModels = (from item in shoppingEntities.Clothes
                                                                 join cate in shoppingEntities.Categories
                                                                 on item.CategoryId equals cate.CategoryId
                                                                 where item.style == "SUMMER"
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
            return View("Trands",shoppingViewModels);
        }

        public ActionResult ForAll()
        {
            IEnumerable<ShoppingViewModel> shoppingViewModels = (from item in shoppingEntities.Clothes
                                                                 join cate in shoppingEntities.Categories
                                                                 on item.CategoryId equals cate.CategoryId
                                                                 where item.style == "FORALL"
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
            return View("Trands", shoppingViewModels);
        }

        public ActionResult Jeans()
        {
            IEnumerable<ShoppingViewModel> shoppingViewModels = (from item in shoppingEntities.Clothes
                                                                 join cate in shoppingEntities.Categories
                                                                 on item.CategoryId equals cate.CategoryId
                                                                 where item.CategoryId == 5
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
            return View("Clothes", shoppingViewModels);
        }

        public ActionResult Skirts()
        {
            IEnumerable<ShoppingViewModel> shoppingViewModels = (from item in shoppingEntities.Clothes
                                                                 join cate in shoppingEntities.Categories
                                                                 on item.CategoryId equals cate.CategoryId
                                                                 where item.CategoryId == 6
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
            return View("Clothes", shoppingViewModels);
        }

        public ActionResult Dresses()
        {
            IEnumerable<ShoppingViewModel> shoppingViewModels = (from item in shoppingEntities.Clothes
                                                                 join cate in shoppingEntities.Categories
                                                                 on item.CategoryId equals cate.CategoryId
                                                                 where item.CategoryId == 7
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
            return View("Clothes", shoppingViewModels);
        }

        public ActionResult Blouses()
        {
            IEnumerable<ShoppingViewModel> shoppingViewModels = (from item in shoppingEntities.Clothes
                                                                 join cate in shoppingEntities.Categories
                                                                 on item.CategoryId equals cate.CategoryId
                                                                 where item.CategoryId == 9
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
            return View("Clothes", shoppingViewModels);
        }
    }
}