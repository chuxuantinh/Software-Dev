namespace FastFood.Web.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Linq;

    using Data;
    using ViewModels.Orders;
    using FastFood.Models;
    using AutoMapper.QueryableExtensions;
    using FastFood.Models.Enums;

    public class OrdersController : Controller
    {
        private readonly FastFoodContext context;
        private readonly IMapper mapper;

        public OrdersController(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Create()
        {
            var viewOrder = new CreateOrderViewModel
            {
                Items = this.context.Items.ToList(),
                Employees = this.context.Employees.ToList(),
            };

            return this.View(viewOrder);
        }

        [HttpPost]
        public IActionResult Create(CreateOrderInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home");
            }

            Employee employee = this.context.Employees.FirstOrDefault(e => e.Id == model.EmployeeId);

            Item item = this.context.Items.FirstOrDefault(i => i.Id == model.ItemId);

            var order = this.mapper.Map<Order>(model);
            order.DateTime = DateTime.Now;
            order.Type = Enum.Parse<OrderType>(model.OrderType);
            order.Employee = employee;

            order.OrderItems.Add(new OrderItem
            {
                Item = item,
                Order = order,
                Quantity = model.Quantity
            });

            this.context.Orders.Add(order);
            this.context.SaveChanges();

            return this.RedirectToAction("All", "Orders");
        }

        public IActionResult All()
        {
            var orders = this.context
                .Orders
                .ProjectTo<OrderAllViewModel>(this.mapper.ConfigurationProvider)
                .ToList();

            return this.View(orders);
        }
    }
}
