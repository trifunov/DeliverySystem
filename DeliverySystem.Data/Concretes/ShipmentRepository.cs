using DeliverySystem.Data.Interfaces;
using DeliverySystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DeliverySystem.Data.Concretes
{
    public class ShipmentRepository : IShipmentRepository
    {
        private readonly DeliverySystemContext _context;

        public ShipmentRepository(DeliverySystemContext context)
        {
            _context = context;
        }

        public List<SPShipmentsGetAll> GetAll()
        {
            string sqlQuery = "EXEC [dbo].[SPShipmentsGetAll] ";
            return _context.Query<SPShipmentsGetAll>().FromSql(sqlQuery).ToList();
        }

        public List<SPShipmentsGetByAddressAndCategoryId> GetByAddressAndCategoryId(string address, int categoryId)
        {
            SqlParameter addressParameter = new SqlParameter("@address", address);
            SqlParameter categoryParameter = new SqlParameter("@categoryId", categoryId);
            string sqlQuery = "EXEC [dbo].[SPShipmentsGetByAddressAndCategoryId] @address,@categoryId";
            return _context.Query<SPShipmentsGetByAddressAndCategoryId>().FromSql(sqlQuery, addressParameter, categoryParameter).ToList();
        }

        public List<SPShipmentsGetByAddressAndCategoryId> GetBySelectedOrderIds(string orderIds)
        {
            SqlParameter ordersParameter = new SqlParameter("@orderIds", orderIds);
            string sqlQuery = "EXEC [dbo].[SPShipmentsGetByAddressAndCategoryId] @orderIds";
            return _context.Query<SPShipmentsGetByAddressAndCategoryId>().FromSql(sqlQuery, ordersParameter).ToList();
        }
    }
}
