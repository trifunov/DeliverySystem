using DeliverySystem.Data.Interfaces;
using DeliverySystem.Service.DTOs;
using DeliverySystem.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliverySystem.Service.Concretes
{
    public class ProductManager : IProductManager
    {
        private readonly IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<ProductDTO> GetByOrderId(int orderId)
        {
            var result = new List<ProductDTO>();
            var products = _productRepository.GetByOrderId(orderId);

            foreach (var product in products)
            {
                var productDto = new ProductDTO();
                productDto.Name = product.Item1;
                productDto.Description = product.Item2;
                productDto.Sku = product.Item3;
                productDto.CategoryName = product.Item4;
                productDto.Price = string.Format("{0:0.00#}", product.Item5 ?? 0);
                productDto.Quantity = product.Item6 ?? 0;
                productDto.Total = string.Format("{0:0.00#}", product.Item7 ?? 0);
                result.Add(productDto);
            }

            return result;
        }
    }
}
