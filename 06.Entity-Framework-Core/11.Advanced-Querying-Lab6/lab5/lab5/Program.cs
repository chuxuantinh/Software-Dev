using lab5.Data;
using lab5.Data.Models;
using lab5.Data.Queries;
using lab5.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;

namespace lab5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using var db = new CarDbContext();

            db.Database.Migrate();

            var price = 5000;

            db.Cars.Where(c => c.Price > price).ToList();
            db.Cars.FromSqlInterpolated($"SELECT * FROM Cars WHERE Price > {price}").ToList();
            db.Cars.FromSqlRaw("SELECT * FROM Cars WHERE Price > {0}", price).ToList();

            db.Cars
                .Where(c => c.Price > price)
                .Select(c => new ResultModel
                { 
                    FullName = c.Model.Make.Name
                })
                .ToList();

            var query = EF.CompileQuery<CarDbContext, IEnumerable<ResultModel>>(
                db => db.Cars
                .Where(c => c.Price > price)
                .Select(c => new ResultModel
                {
                    FullName = c.Model.Make.Name
                }));

            var result = query(db);

            CarQueries.ToREsult(db, 5000);

            using var data = new CarDbContext();

            var car = db.Cars.FirstOrDefault();

            data.Attach(car);

            car.Price += 100;

            data.Entry(car).State = EntityState.Detached;

            data.SaveChanges();

            var newCar = new Car { Id = 2 };

            data.Attach(newCar);

            newCar.Price = 100;

            data.SaveChanges();

            var entry = data.Entry(newCar);

            entry.State = EntityState.Added;

            data.SaveChanges();

            var cars = data
                .Cars
                .Where(c => c.Price > 1000)
                .Delete();

            

            var cars2 = data
                .Cars
                .Where(c => c.Price < 20000)
                .Update(c => new Car { Price = c.Price * 1.2m });

            var car3 = data
               .Cars
               .FirstOrDefault(c => c.Id == 1);

            var owners = car.Owners;

            data.Entry(car3)
                .Reference(c => c.Model)
                .Load();

            var car4 = data
               .Cars
               .Where(c => c.Id == 1)
               .FirstOrDefault();

            Console.WriteLine(car4.Model.Name);

            var cars5 = GetAllCars(data);

            foreach (var car5 in cars5)
            {
                Console.WriteLine(car5.Model.Make.Name);

                foreach (var owner in car5.Owners)
                {
                    Console.WriteLine(owner.Customer.Address.Town);
                }
            }

            var cars6 = data
               .Cars
               .Select(c  => new 
               {
                    Make = c.Model.Make.Name,
                    OwnerTowns = c.Owners.Select(o => o.Customer.Address.Town)
               })
               .ToList();

            foreach (var car6 in cars6)
            {
                Console.WriteLine(car6.Make);

                foreach (var town in car6.OwnerTowns)
                {
                    Console.WriteLine(town);
                }
            }
        }

        private static List<Car> GetAllCars(CarDbContext data)
        {
            return data.Cars.ToList();
        }
    }
}
