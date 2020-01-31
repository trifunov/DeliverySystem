using DeliverySystem.Data.Interfaces;
using DeliverySystem.Service.DTOs;
using DeliverySystem.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeliverySystem.Service.Concretes
{
    public class ShipmentManager : IShipmentManager
    {
        private readonly IShipmentRepository _shipmentRepository;

        public ShipmentManager(IShipmentRepository shipmentRepository)
        {
            _shipmentRepository = shipmentRepository;
        }

        public List<ShipmentAllDTO> GetAll()
        {
            var shipmentDTOs = new List<ShipmentAllDTO>();
            var shipments = _shipmentRepository.GetAll();

            foreach (var shipment in shipments)
            {
                var shipmentDto = new ShipmentAllDTO();
                shipmentDto.CategoryId = shipment.CategoryId;
                shipmentDto.CategoryName = shipment.CategoryName;
                shipmentDto.Address = shipment.Address;
                shipmentDto.TotalProductsToBeShipped = shipment.TotalProductsToBeShipped;
                shipmentDTOs.Add(shipmentDto);
            }

            return shipmentDTOs;
        }

        public List<ShipmentDTO> GetByAddressAndCategoryId(string address, int categoryId)
        {
            var shipmentDTOs = new List<ShipmentDTO>();
            //var shipmentDTO = new ShipmentDTO();
            //var shipments = _shipmentRepository.GetByAddressAndCategoryId(address, categoryId);
            //var orderId = 0;

            //foreach (var shipment in shipments)
            //{
            //    if (orderId != shipment.OrderId)
            //    {
            //        shipmentDTO = new ShipmentDTO
            //        {
            //            OrderId = shipment.OrderId,
            //            Address = shipment.Address,
            //            FirstName = shipment.FirstName,
            //            LastName = shipment.LastName,
            //            Products = new List<ShipmentProductDTO>()
            //        };
            //        shipmentDTOs.Add(shipmentDTO);
            //        orderId = shipment.OrderId;
            //    }

            //    var product = new ShipmentProductDTO();
            //    product.Id = shipment.ProductId;
            //    product.Name = shipment.ProductName;
            //    product.Description = shipment.ProductDescription;
            //    product.SKU = shipment.ProductSKU;
            //    product.Quantity = shipment.Quantity;
            //    product.Price = string.Format("{0:0.00#}", shipment.Price);
            //    product.Total = string.Format("{0:0.00#}", shipment.Total);
            //    product.CategoryName = shipment.CategoryName;
            //    shipmentDTO.Products.Add(product);
            //}

            return shipmentDTOs;
        }

        public List<ShipmentDTO> GetBySelectedOrderIds(string orderIds)
        {
            var shipmentDTOs = new List<ShipmentDTO>();
            var shipmentDTO = new ShipmentDTO { Orders = new List<ShipmentOrderDTO>() };
            var shipments = _shipmentRepository.GetBySelectedOrderIds(orderIds);
            ShipmentOrderDTO currentOrder = null;

            foreach (var shipment in shipments)
            {
                if(currentOrder == null)
                {
                    currentOrder = new ShipmentOrderDTO
                    {
                        OrderId = shipment.OrderId,
                        Address = shipment.Address,
                        City = shipment.City,
                        State = shipment.State,
                        Country = shipment.Country,
                        FirstName = shipment.FirstName,
                        LastName = shipment.LastName,
                        Products = new List<ShipmentProductDTO>()
                    };
                    //shipmentDTOs.Add(new ShipmentDTO { Orders = new List<ShipmentOrderDTO> { currentOrder } });
                }
                else if (currentOrder.OrderId != shipment.OrderId)
                {
                    var resultOrderCategories = shipmentDTOs.Select(o => o.Orders).SelectMany(sh => sh.Select(x => x.Products.Select(y => y.CategoryId).Distinct()), (orders, categories) => new { orders, categories });
                    var currentOrderCategories = currentOrder.Products.Select(x => x.CategoryId).Distinct();
                    var hasShipmentWithSameAddressAndCategory = resultOrderCategories.FirstOrDefault(x => x.orders.Any(y => y.Address == currentOrder.Address && y.City == currentOrder.City && y.State == currentOrder.State && y.Country == currentOrder.Country) && x.categories.Equals(currentOrderCategories));

                    if(hasShipmentWithSameAddressAndCategory != null)
                    {
                        var existingShipmentDto = shipmentDTOs.First(y => y.Orders.First().Address == hasShipmentWithSameAddressAndCategory.orders.First().Address);
                        existingShipmentDto.Orders.Add(currentOrder);
                    }
                    else
                    {
                        shipmentDTOs.Add(new ShipmentDTO { Orders = new List<ShipmentOrderDTO> { currentOrder } });
                    }

                    currentOrder = new ShipmentOrderDTO
                    {
                        OrderId = shipment.OrderId,
                        Address = shipment.Address,
                        City = shipment.City,
                        State = shipment.State,
                        Country = shipment.Country,
                        FirstName = shipment.FirstName,
                        LastName = shipment.LastName,
                        Products = new List<ShipmentProductDTO>()
                    };
                }

                var product = new ShipmentProductDTO();
                product.Id = shipment.ProductId;
                product.Name = shipment.ProductName;
                product.Description = shipment.ProductDescription;
                product.SKU = shipment.ProductSKU;
                product.Quantity = shipment.Quantity;
                product.Price = string.Format("{0:0.00#}", shipment.Price);
                product.Total = string.Format("{0:0.00#}", shipment.Total);
                product.CategoryId = shipment.CategoryId;
                product.CategoryName = shipment.CategoryName;
                currentOrder.Products.Add(product);

                if(shipment == shipments.Last())
                {
                    var resultOrderCategories = shipmentDTOs.Select(o => o.Orders).SelectMany(sh => sh.Select(x => x.Products.Select(y => y.CategoryId).Distinct()), (orders, categories) => new { orders, categories });
                    var currentOrderCategories = currentOrder.Products.Select(x => x.CategoryId).Distinct();
                    var hasShipmentWithSameAddressAndCategory = resultOrderCategories.FirstOrDefault(x => x.orders.Any(y => y.Address == currentOrder.Address && y.City == currentOrder.City && y.State == currentOrder.State && y.Country == currentOrder.Country) 
                                                                                                       && x.categories.All(currentOrderCategories.Contains) 
                                                                                                       && x.categories.Count() == currentOrderCategories.Count());

                    if (hasShipmentWithSameAddressAndCategory != null)
                    {
                        var existingShipmentDto = shipmentDTOs.First(y => y.Orders.First().Address == hasShipmentWithSameAddressAndCategory.orders.First().Address);
                        existingShipmentDto.Orders.Add(currentOrder);
                    }
                    else
                    {
                        shipmentDTOs.Add(new ShipmentDTO { Orders = new List<ShipmentOrderDTO> { currentOrder } });
                    }
                }
            }

            return shipmentDTOs;
        }
    }
}
