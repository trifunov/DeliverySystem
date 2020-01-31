using DeliverySystem.Data.Interfaces;
using DeliverySystem.Service.DTOs;
using DeliverySystem.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliverySystem.Service.Concretes
{
    public class OrderManager : IOrderManager
    {
        private readonly IOrderRepository _orderRepository;

        public OrderManager(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public List<OrderDTO> GetAll()
        {
            var result = new List<OrderDTO>();
            var orders = _orderRepository.GetAll();

            foreach (var order in orders)
            {
                var orderDto = new OrderDTO();
                orderDto.Id = order.Item1;
                orderDto.FirstName = order.Item2;
                orderDto.LastName = order.Item3;
                orderDto.Address = order.Item4;
                orderDto.City = order.Item5;
                orderDto.State = order.Item6;
                orderDto.Country = order.Item7;
                orderDto.TotalProducts = order.Rest.Item1;
                result.Add(orderDto);
            }

            return result;
        }
    }
}
