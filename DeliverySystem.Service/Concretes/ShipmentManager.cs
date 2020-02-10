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
            var currentAddress = "";
            var currentCategoryId = 0;

            foreach (var shipment in shipments)
            {
                var currentOrder = new ShipmentOrderDTO
                {
                    OrderId = Guid.NewGuid(),
                    Address = shipment.Address,
                    City = shipment.City,
                    State = shipment.State,
                    Country = shipment.Country,
                    FirstName = shipment.FirstName,
                    LastName = shipment.LastName,
                    ProductId = shipment.ProductId,
                    ProductName = shipment.ProductName,
                    ProductDescription = shipment.ProductDescription,
                    SKU = shipment.ProductSKU,
                    Quantity = shipment.Quantity,
                    Price = string.Format("{0:0.00#}", shipment.Price),
                    Total = string.Format("{0:0.00#}", shipment.Total),
                    CategoryId = shipment.CategoryId,
                    CategoryName = shipment.CategoryName
                };
                
                if (shipment.Address != currentAddress || shipment.CategoryId != currentCategoryId)
                {
                    if (shipment != shipments.First())
                    {
                        shipmentDTOs.Add(shipmentDTO);
                        shipmentDTO = new ShipmentDTO { Orders = new List<ShipmentOrderDTO>() };
                    }
                    shipmentDTO.Orders.Add(currentOrder);
                    currentAddress = shipment.Address;
                    currentCategoryId = shipment.CategoryId;
                }
                else
                {
                    shipmentDTO.Orders.Add(currentOrder);
                }

                if (shipment == shipments.Last())
                {
                    shipmentDTOs.Add(shipmentDTO);
                }
            }

            return shipmentDTOs;
        }
    }
}
