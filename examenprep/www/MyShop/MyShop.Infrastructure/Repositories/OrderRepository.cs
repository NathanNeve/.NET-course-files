using Microsoft.EntityFrameworkCore;
using MyShop.Domain.Models;
using System.Linq;

namespace MyShop.Infrastructure.Repositories
{
    public class OrderRepository : GenericRepository<Order>
    {
        private readonly ShoppingContext _context;
        public OrderRepository(ShoppingContext context) : base(context)
        {
            _context = context;
        }

        public override Order Update(Order entity)
        {
            var order = _context.Orders
                .Single(o => o.OrderID == entity.OrderID);

            order.OrderDate = entity.OrderDate;
            order.Orderlines = entity.Orderlines;

            return base.Update(order);
        }

        public override IEnumerable<Order> All()
        {
            var orders = _context.Orders.Include(o => o.Orderlines)
                .ThenInclude(ol => ol.Product);

            return orders.ToList();
        }

    }
}
