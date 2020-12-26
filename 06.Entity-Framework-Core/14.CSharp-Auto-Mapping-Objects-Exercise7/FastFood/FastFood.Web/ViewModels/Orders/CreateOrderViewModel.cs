namespace FastFood.Web.ViewModels.Orders
{
    using FastFood.Models;
    using System.Collections.Generic;

    public class CreateOrderViewModel
    {
        public List<Item> Items { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
