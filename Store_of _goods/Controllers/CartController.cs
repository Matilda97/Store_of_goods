using Store_of__goods.Abstract;
using Store_of__goods.Entities;
using Store_of__goods.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store_of__goods.Controllers
{
    public class CartController : Controller
    {

        private GoodsEntities repository = new GoodsEntities();

        public CartController()
        { }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        //private IGoodsRepositiry repository;
        public CartController(IGoodsRepositiry repo)
        {
            //repository = repo;
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToCart(Cart cart, int? id, string returnUrl)
        {

            WAREHOUSE_DATA wardata = repository.WAREHOUSE_DATA
                .FirstOrDefault(g => g.ID == id);

            if (wardata != null)
            {
                cart.AddItem(wardata, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int id, string returnUrl)
        {
            WAREHOUSE_DATA wardata = repository.WAREHOUSE_DATA
                .FirstOrDefault(g => g.ID == id);

            if (wardata != null)
            {
                cart.RemoveLine(wardata);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}