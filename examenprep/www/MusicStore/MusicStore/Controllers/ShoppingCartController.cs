using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Data;
using MusicStore.Models;
using MusicStore.Models.ViewModels;
using System.Linq;
using System.Net.Http;

namespace MusicStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly StoreContext _context;

        public ShoppingCartController(StoreContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var shoppingCart = new ShoppingCart(HttpContext, _context);
            var cartItems = shoppingCart.GetCartItems();

            ListShoppingCartViewModel shoppingCartVM = new ListShoppingCartViewModel();
            shoppingCartVM.CartItems = cartItems;
            shoppingCartVM.cartTotal = (int)HttpContext.Session.GetInt32("CartTotal");
            return View(shoppingCartVM);
        }

        public IActionResult AddToCart(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = _context.Albums.FirstOrDefault(a => a.AlbumID == id);
            if (album == null)
            {
                return NotFound();
            }

            var shoppingCart = new ShoppingCart(HttpContext, _context);
            int existingCartTotal = HttpContext.Session.GetInt32("CartTotal") ?? 0;
            shoppingCart.AddCartTotal(existingCartTotal + album.Price);
            shoppingCart.AddToCart(album);
            HttpContext.Session.SetInt32("CartTotal", shoppingCart.CartTotal);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingCart = new ShoppingCart(HttpContext, _context);
            shoppingCart.RemoveFromCart((int)id);
            return RedirectToAction("Index");
        }
    }
}
