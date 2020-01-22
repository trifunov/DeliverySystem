using DeliverySystem.Data.Interfaces;
using DeliverySystem.Service.DTOs;
using DeliverySystem.Service.Interfaces;
using System;
using System.Collections.Generic;
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
            var shipmentDTO = new ShipmentDTO();
            var shipments = _shipmentRepository.GetByAddressAndCategoryId(address, categoryId);
            var orderId = 0;

            foreach (var shipment in shipments)
            {
                if (orderId != shipment.OrderId)
                {
                    shipmentDTO = new ShipmentDTO
                    {
                        OrderId = shipment.OrderId,
                        Address = shipment.Address,
                        FirstName = shipment.FirstName,
                        LastName = shipment.LastName,
                        Products = new List<ShipmentProductDTO>()
                    };
                    shipmentDTOs.Add(shipmentDTO);
                    orderId = shipment.OrderId;
                }

                var product = new ShipmentProductDTO();
                product.Id = shipment.ProductId;
                product.Name = shipment.ProductName;
                product.Description = shipment.ProductDescription;
                product.SKU = shipment.ProductSKU;
                product.Quantity = shipment.ProductQuantity;
                product.Price = string.Format("{0:0.00#}", shipment.ProductPrice);
                product.Total = string.Format("{0:0.00#}", shipment.TotalProductPrice);
                product.CategoryName = shipment.CategoryName;
                shipmentDTO.Products.Add(product);
            }

            return shipmentDTOs;
        }
    }
}
