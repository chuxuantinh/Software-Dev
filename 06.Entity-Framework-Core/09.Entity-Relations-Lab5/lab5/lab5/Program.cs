using lab5.Data;
using lab5.Data.Models;
using lab5.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace lab5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using var db = new CarDbContext();

            db.Database.Migrate();

            var customer = db.Customers.FirstOrDefault();

            db.Purchases
                .Select(p => new PurchaseResultModel
                {
                    Customer = new CustomerResultModel
                    {
                        Name = p.Customer.FirstName + " " + p.Customer.LastName,
                        Town = p.Customer.Address.Town
                    },
                    Car = new CarResultModel
                    { 
                        Make = p.Car.Model.Make.Name,
                        Model = p.Car.Model.Name,
                        Vin = p.Car.Vin
                    },
                    Price = p.Price,
                    PurchaseDate = p.PurchaseDate
                })
                .ToList();

            db.SaveChanges();
        }
    }
}
