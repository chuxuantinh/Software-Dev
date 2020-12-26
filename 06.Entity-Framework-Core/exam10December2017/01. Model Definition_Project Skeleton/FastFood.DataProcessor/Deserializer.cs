using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using FastFood.Data;
using FastFood.DataProcessor.Dto.Import;
using FastFood.Models;
using FastFood.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace FastFood.DataProcessor
{
	public static class Deserializer
	{
		private const string FailureMessage = "Invalid data format.";
		private const string SuccessMessage = "Record {0} successfully imported.";
		private const string DateFormat = "dd/MM/yyyy HH:mm";
		private const string OrderSuccessMessage = "Order for {0} on {1} added";

		public static string ImportEmployees(FastFoodDbContext context, string jsonString)
		{
			var sb = new StringBuilder();

			var deserializedImployees = JsonConvert.DeserializeObject<ImportEmployeeDto[]>(jsonString);

			var employees = new List<Employee>();
			var positions = new List<Position>();

			foreach (var dto in deserializedImployees)
			{
				if (!IsValid(dto))
				{
					sb.AppendLine(FailureMessage);
					continue;
				}

				var position = positions.SingleOrDefault(p => p.Name == dto.Position);

				if (position == null)
				{
					position = new Position
					{
						Name = dto.Position
					};

					positions.Add(position);
				}
				
				var employee = new Employee
				{
					Name = dto.Name,
					Age = dto.Age,
					Position = position
				};

				employees.Add(employee);
				sb.AppendLine(string.Format(SuccessMessage, employee.Name));
				
			}

			context.Employees.AddRange(employees);
			context.SaveChanges();

			return sb.ToString().TrimEnd();
		}

		public static string ImportItems(FastFoodDbContext context, string jsonString)
		{
			var sb = new StringBuilder();

			var deserializedItems = JsonConvert.DeserializeObject<ImportItemDto[]>(jsonString);

			var items = new List<Item>();
			var categories = new List<string>();
			var categoriesType = new List<Category>();

			foreach (var dto in deserializedItems)
			{
				if (!IsValid(dto))
				{
					sb.AppendLine(FailureMessage);
					continue;
				}

				var itemExists = items.Any(i => i.Name == dto.Name);

				if (itemExists)
				{
					sb.AppendLine(FailureMessage);
					continue;
				}

				var categoryExists = categories.Any(c => c.Contains(dto.Category));

				Item item;

				if (!categoryExists)
				{
					var category = new Category
					{
						Name = dto.Category
					};

					categoriesType.Add(category);
					categories.Add(dto.Category);

					item = new Item
					{
						Name = dto.Name,
						Price = dto.Price,
						Category = category
					};
				}
				else
				{
					item = new Item
					{
						Name = dto.Name,
						Price = dto.Price,
						Category = categoriesType.Single(c => c.Name == dto.Category)
					};
				}

				items.Add(item);
				sb.AppendLine($"Record {item.Name} successfully imported.");
			}

			context.Items.AddRange(items);
			context.SaveChanges();

			return sb.ToString().TrimEnd();
		}

		public static string ImportOrders(FastFoodDbContext context, string xmlString)
		{
			//My solution!
			
			var serializer = new XmlSerializer(typeof(ImportOrderDto[]), new XmlRootAttribute("Orders"));
			var objects = (ImportOrderDto[])serializer.Deserialize(new StringReader(xmlString));

			var sb = new StringBuilder();

			var orders = new List<Order>();

			foreach (var dto in objects)
			{
				var isValidEnum = Enum.TryParse(dto.Type, out OrderType type);
				var employee = context.Employees.SingleOrDefault(e => e.Name == dto.Employee);

				if (!IsValid(dto) || !dto.Items.All(IsValid) || !isValidEnum || employee == null)
				{
					sb.AppendLine(FailureMessage);
					continue;
				}

				var order = new Order
				{
					Customer = dto.Customer,
					Employee = employee,
					DateTime = DateTime.ParseExact(dto.DateTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
					Type = type
				};

				var allItemsExist = true;

				foreach (var itemDto in dto.Items)
				{
					var item = context.Items.SingleOrDefault(i => i.Name == itemDto.Name);

					if (item == null)
					{
						sb.AppendLine(FailureMessage);
						allItemsExist = false;
						break;
					}

					order.OrderItems.Add(new OrderItem
					{
						Item = item,
						Quantity = itemDto.Quantity
					});
				}

				if (allItemsExist == false)
				{
					continue;
				}

				orders.Add(order);
				sb.AppendLine($"Order for {order.Customer} on {order.DateTime.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)} added");
			}

			context.Orders.AddRange(orders);
			context.SaveChanges();

			return sb.ToString().TrimEnd();


			//Solution from Internet!
			
			//var serializer = new XmlSerializer(typeof(ImportOrderDto[]), new XmlRootAttribute("Orders"));
			//var deserializedOrders = (ImportOrderDto[])serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));

			//var sb = new StringBuilder();

			//var validOrders = new List<Order>();

			//foreach (var orderDto in deserializedOrders)
			//{
			//	if (!IsValid(orderDto))
			//	{
			//		sb.AppendLine(FailureMessage);
			//		continue;
			//	}

			//	var areAllItemsValid = true;
			//	var orderItems = new List<OrderItem>();
			//	foreach (var oi in orderDto.Items)
			//	{
			//		var item = context.Items
			//			.FirstOrDefault(i => i.Name.Equals(oi.Name, StringComparison.OrdinalIgnoreCase));

			//		if (!IsValid(oi) || item == null)
			//		{
			//			areAllItemsValid = false;
			//			break;
			//		}

			//		var orderItem = new OrderItem
			//		{
			//			ItemId = item.Id,
			//			Quantity = oi.Quantity
			//		};

			//		orderItems.Add(orderItem);
			//	}

			//	var employee = context.Employees
			//		.FirstOrDefault(e => e.Name.Equals(orderDto.Employee, StringComparison.OrdinalIgnoreCase));

			//	DateTime date;
			//	var isDateValid = DateTime.TryParseExact(orderDto.DateTime,
			//		DateFormat,
			//		CultureInfo.InvariantCulture,
			//		DateTimeStyles.None,
			//		out date);

			//	if (employee == null || !areAllItemsValid || !isDateValid)
			//	{
			//		sb.AppendLine(FailureMessage);
			//		continue;
			//	}

			//	var order = new Order
			//	{
			//		Customer = orderDto.Customer,
			//		Employee = employee,
			//		DateTime = date,
			//		Type = Enum.Parse<OrderType>(orderDto.Type),
			//		OrderItems = orderItems
			//	};

			//	sb.AppendLine(string.Format(OrderSuccessMessage,
			//		order.Customer,
			//		order.DateTime.ToString(DateFormat, CultureInfo.InvariantCulture)));

			//	validOrders.Add(order);
			//}

			//context.Orders.AddRange(validOrders);
			//context.SaveChanges();

			//var result = sb.ToString();
			//return result;



			//Author's solution below!

			//var xml = XDocument.Parse(xmlString);

			//var deserializedOrders = xml.Element("Orders");

			//var validOrders = new List<Order>();
			//var sb = new StringBuilder();

			//foreach (var orderElement in deserializedOrders.Elements())
			//{
			//	var order = new Order();

			//	var customer = orderElement.Element("Customer").Value;
			//	order.Customer = customer;

			//	var employee = FindEmployee(context, orderElement.Element("Employee").Value);

			//	if (employee == null)
			//	{
			//		sb.AppendLine(FailureMessage);
			//		continue;
			//	}

			//	order.Employee = employee;

			//	var orderType = Enum.Parse<OrderType>(orderElement.Element("Type").Value);
			//	order.Type = orderType;

			//	var dateTime = DateTime.ParseExact(orderElement.Element("DateTime").Value, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
			//	order.DateTime = dateTime;

			//	var orderItems = new List<OrderItem>();

			//	var itemsElement = orderElement.Element("Items");
			//	foreach (var itemElement in itemsElement.Elements())
			//	{
			//		var item = FindItem(context, itemElement.Element("Name").Value);

			//		if (item == null)
			//		{
			//			sb.AppendLine(FailureMessage);
			//			continue;
			//		}

			//		var quantity = int.Parse(itemElement.Element("Quantity").Value);

			//		var orderItem = new OrderItem { Item = item, Quantity = quantity };
			//		orderItems.Add(orderItem);
			//	}

			//	order.OrderItems = orderItems;
			//	if (!IsValid(order))
			//	{
			//		sb.AppendLine(FailureMessage);
			//		continue;
			//	}

			//	validOrders.Add(order);
			//	sb.AppendLine(string.Format("Order for {0} on {1} added",
			//		order.Customer,
			//		order.DateTime.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)));
			//}

			//context.Orders.AddRange(validOrders);
			//context.SaveChanges();

			//var result = sb.ToString();

			//return result;


			//Refactored brom above
			//Not working in judge
			//var serializer = new XmlSerializer(typeof(ImportOrderDto[]), new XmlRootAttribute("Orders"));
			//var objects = (ImportOrderDto[])serializer.Deserialize(new StringReader(xmlString));

			//var sb = new StringBuilder();

			//var validOrders = new List<Order>();

			//foreach (var orderElement in objects)
			//{
			//	var order = new Order();

			//	var customer = orderElement.Customer;
			//	order.Customer = customer;

			//	var employee = context.Employees.SingleOrDefault(e => e.Name == orderElement.Employee);

			//	if (employee == null)
			//	{
			//		sb.AppendLine(FailureMessage);
			//		continue;
			//	}

			//	order.Employee = employee;

			//	var orderType = orderElement.Type;
			//	order.Type = orderType;

			//	var dateTime = DateTime.ParseExact(orderElement.DateTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
			//	order.DateTime = dateTime;

			//	var orderItems = new List<OrderItem>();

			//	var itemsElement = orderElement.Items;
			//	foreach (var itemElement in itemsElement)
			//	{
			//		var item = context.Items.SingleOrDefault(i => i.Name == itemElement.Name);

			//		if (item == null)
			//		{
			//			sb.AppendLine(FailureMessage);
			//			continue;
			//		}

			//		var quantity = itemElement.Quantity;

			//		var orderItem = new OrderItem { Item = item, Quantity = quantity };
			//		orderItems.Add(orderItem);
			//	}

			//	order.OrderItems = orderItems;
			//	if (!IsValid(order))
			//	{
			//		sb.AppendLine(FailureMessage);
			//		continue;
			//	}

			//	validOrders.Add(order);
			//	sb.AppendLine(string.Format("Order for {0} on {1} added",
			//		order.Customer,
			//		order.DateTime.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)));
			//}

			//context.Orders.AddRange(validOrders);
			//context.SaveChanges();

			//var result = sb.ToString();

			//return result;

			//Solution from internet!

			//var sb = new StringBuilder();
			//var employees = context.Employees.ToList();
			//var employeeNames = employees.Select(e => e.Name).ToList();
			//var items = context.Items.ToList();
			//var itemNames = items.Select(i => i.Name).ToList();

			//var orders = new List<Order>();
			//var orderItems = new List<OrderItem>();

			//var serializer = new XmlSerializer(typeof(ImportOrderDto[]), new XmlRootAttribute("Orders"));
			//ImportOrderDto[] importOrderDtos;

			//using (var reader = new StringReader(xmlString))
			//{
			//	importOrderDtos = (ImportOrderDto[])serializer.Deserialize(reader);
			//}

			//foreach (var orderDto in importOrderDtos)
			//{
			//	var itemsExists = orderDto.Items.Select(i => i.Name).ToList().All(n => itemNames.Contains(n));

			//	if (!IsValid(orderDto) ||
			//		!employeeNames.Contains(orderDto.Employee) ||
			//		!itemsExists)
			//	{
			//		sb.AppendLine(FailureMessage);
			//		continue;
			//	}

			//	var order = new Order
			//	{
			//		Customer = orderDto.Customer,
			//		DateTime = DateTime.ParseExact(orderDto.DateTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
			//		Employee = employees.First(e => e.Name == orderDto.Employee),
			//		Type = (OrderType)Enum.Parse(typeof(OrderType), orderDto.Type),
			//	};

			//	foreach (var item in orderDto.Items)
			//	{
			//		orderItems.Add(new OrderItem
			//		{
			//			Order = order,
			//			Item = items.First(i => i.Name == item.Name),
			//			Quantity = item.Quantity,
			//		});
			//	}

			//	sb.AppendLine($"Order for {order.Customer} on {order.DateTime.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)} added");
			//	orders.Add(order);
			//}

			//context.Orders.AddRange(orders);
			//context.OrderItems.AddRange(orderItems);
			//context.SaveChanges();

			//return sb.ToString().TrimEnd();
		}

		private static bool IsValid(object dto)
		{
			var validationContext = new ValidationContext(dto);
			var validationResult = new List<ValidationResult>();

			return Validator.TryValidateObject(dto, validationContext, validationResult, true);
		}

		private static Item FindItem(FastFoodDbContext context, string itemName)
		{
			var item = context.Items.SingleOrDefault(i => i.Name == itemName);
			return item;
		}

		private static Employee FindEmployee(FastFoodDbContext context, string employeeName)
		{
			var employee = context.Employees.SingleOrDefault(e => e.Name == employeeName);
			return employee;
		}
	}
}