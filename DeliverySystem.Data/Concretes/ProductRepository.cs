using DeliverySystem.Data.Interfaces;
using DeliverySystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeliverySystem.Data.Concretes
{
    public class ProductRepository : IProductRepository
    {
        private readonly DeliverySystemContext _context;

        public ProductRepository(DeliverySystemContext context)
        {
            _context = context;
        }

        public List<Tuple<string, string, string, string, decimal?, int?, decimal?>> GetByOrderId(int orderId)
        {
            return _context.TestOrderProducts
            .Join(_context.TestProducts, op => op.ProductId, p => p.Id, (op, p) => new { op, p })
            .Join(_context.TestProductCategories, opp => opp.p.Id, pc => pc.ProductId, (opp, pc) => new { opp, pc })
            .Join(_context.TestCategories, oppc => oppc.pc.CategoryId, c => c.Id, (oppc, c) => new { oppc, c })
            .Where(x => x.oppc.opp.op.OrderId == orderId)
            .Select(x => Tuple.Create(
                x.oppc.opp.p.Name,
                x.oppc.opp.p.Description,
                x.oppc.opp.p.Sku,
                x.c.Name,
                x.oppc.opp.op.Price,
                x.oppc.opp.op.Quantity,
                x.oppc.opp.op.Total
                )
            )
            .ToList();
        }
    }
}
