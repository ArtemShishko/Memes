using memes.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace memes.Controllers
{
    public class BagController : Controller
    {
        
        private Entities shoppingEntities;
        private List<BagViewModel> listOfShoppingCartModels;

        public BagController()
        {
            shoppingEntities = new Entities();
            listOfShoppingCartModels = new List<BagViewModel>();
        }
        // GET: Bag
        public ActionResult Index()
        {
            listOfShoppingCartModels = Session["CartItem"] as List<BagViewModel>;

            return View(listOfShoppingCartModels);
        }

        [HttpPost]
        public ActionResult AddOrder()
        {
            int OrderId = 0;
            listOfShoppingCartModels = Session["CartItem"] as List<BagViewModel>;
            Order objOrder = new Order()
            {
                OrderDate = DateTime.Now,
                OrderNumber = String.Format("{0:ddmmyyyyHHmmsss}", DateTime.Now),
            };
            shoppingEntities.Orders.Add(objOrder);
            shoppingEntities.SaveChanges();
            OrderId = objOrder.OrderId;

            foreach (var item in listOfShoppingCartModels)
            {
                OrderDetail objOrderDetail = new OrderDetail();
                objOrderDetail.Total = item.Total;
                objOrderDetail.ItemId = item.Id;
                objOrderDetail.OrderId = OrderId;

                //objOrderDetail.Size = 
                objOrderDetail.Quantity = item.Quantity;
                objOrderDetail.UnitPrice = item.UnitPrice;
                shoppingEntities.OrderDetails.Add(objOrderDetail);
                shoppingEntities.SaveChanges();
                //string_with_your_data = $"{item.ItemName}";

            }

            Session["CartItem"] = null;
            Session["CartCounter"] = null;

            
            return RedirectToAction("Index", "Home");
        }

        public FileStreamResult CreateFile()
        {
            listOfShoppingCartModels = Session["CartItem"] as List<BagViewModel>;
            string string_with_your_data = "$Your bill:\n" +
                    $"Account :{User.Identity.Name}\n";

            foreach (var item in listOfShoppingCartModels)
            {
                OrderDetail objOrderDetail = new OrderDetail();
                //OrderDetail objOrderDetail = new OrderDetail();
                objOrderDetail.Total = item.Total;
                objOrderDetail.ItemId = item.Id;
                //objOrderDetail.OrderId = OrderId;

                //objOrderDetail.Size = 
                objOrderDetail.Quantity = item.Quantity;
                objOrderDetail.UnitPrice = item.UnitPrice;
                shoppingEntities.OrderDetails.Add(objOrderDetail);
                shoppingEntities.SaveChanges();
                string_with_your_data +=
                    $"Item: {item.ItemName}\n" +
                    $"Size: {item.Size}\n" +
                    $"Quantity: {item.Quantity}\n" +
                    $"Price: {item.UnitPrice}\n" +
                    $"Total: {item.Total}\n";
            }

            //todo: add some data from your database into that string:
            //string_with_your_data = $"{orderDetail.Size}";

            var byteArray = Encoding.ASCII.GetBytes(string_with_your_data);
            var stream = new MemoryStream(byteArray);

            return File(stream, "text/plain", "bill.txt");
        }

        [HttpPost]
        public JsonResult Index(int Id, string Size)
        {
            BagViewModel objShoppingCartModel = new BagViewModel();
            Cloth objItem = shoppingEntities.Clothes.Single(model => model.Id == Id);
            if (Session["CartCounter"] != null)
            {
                listOfShoppingCartModels = Session["CartItem"] as List<BagViewModel>;
            }

            if (listOfShoppingCartModels.Any(m => m.Id == Id && m.Size == Size ))
            {
                objShoppingCartModel = listOfShoppingCartModels.Single(m => m.Id == Id && m.Size == Size);
                objShoppingCartModel.Quantity = objShoppingCartModel.Quantity + 1;
                objShoppingCartModel.Total = objShoppingCartModel.Quantity * objShoppingCartModel.UnitPrice;
            }
            else
            {
                objShoppingCartModel.Id = Id;
                objShoppingCartModel.Image = objItem.Image;
                objShoppingCartModel.ItemName = objItem.Name;
                objShoppingCartModel.Size = Size;
                objShoppingCartModel.Quantity = 1;
                objShoppingCartModel.Total = objItem.Price;
                objShoppingCartModel.UnitPrice = objItem.Price;
                listOfShoppingCartModels.Add(objShoppingCartModel);
            }

            Session["CartCounter"] = listOfShoppingCartModels.Count;
            Session["CartItem"] = listOfShoppingCartModels;

            return Json(new { Success = true, Counter = listOfShoppingCartModels.Count }, JsonRequestBehavior.AllowGet);
        }
    }
}