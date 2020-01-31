using DeliverySystem.Data.Interfaces;
using DeliverySystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DeliverySystem.Data.Concretes
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DeliverySystemContext _context;

        public OrderRepository(DeliverySystemContext context)
        {
            _context = context;
        }

        public List<Tuple<int,string,string,string,string,string,string,Tuple<int>>> GetAll()
        {
            return _context.TestOrders
            .Join(_context.TestOrderProducts, o => o.Id, op => op.OrderId, (o, op) => new { o, op })
            .GroupBy(x => new { x.o.Id, x.o.FirstName, x.o.LastName, x.o.Address, x.o.City, x.o.State, x.o.Country })
            .Select(g => Tuple.Create(
                g.Key.Id,
                g.Key.FirstName,
                g.Key.LastName,
                g.Key.Address,
                g.Key.City,
                g.Key.State,
                g.Key.Country,
                g.Count()
                )
            ).ToList();
        }
    }
}
