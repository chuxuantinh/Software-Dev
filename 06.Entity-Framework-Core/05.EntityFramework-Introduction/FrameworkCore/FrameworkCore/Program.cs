using FrameworkCore.Data;
using FrameworkCore.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FrameworkCore
{
    public class Program
    {
        private static bool Filter(string name)
        {
            return name.Length == 4;
        }

        private static IEnumerable<TownResultModel> GetTownData()
        {
            using (var db = new SoftUniContext())
            {
                var result = db.Towns
                    .Where(t => t.Name.StartsWith("S"))
                    .Select(t => new TownResultModel
                    {
                        Name = t.Name,
                        Addresses = t.Addresses
                            .Select(a => a.AddressText)
                    })
                    .ToList();

                return result;
            }
        }

        public static void Main(string[] args)
        {
            var result = GetTownData();

            Func<Town, bool> func = t => t.Name.StartsWith("1");

            func(new Town
            {
                Name = "Ivan"
            });

            Expression<Func<Town, bool>> expr = t => t.Name.StartsWith("1");

            var body = expr.Body;

            Console.WriteLine(expr.Parameters[0]);

            if (body.NodeType == ExpressionType.MemberAccess)
            {
                var property = (MemberExpression)body;
            }

            using (var db = new SoftUniContext())
            {

                var result = db.Towns
                    .Where(t => t.Name.StartsWith("S"))
                    .Where(t => t.TownId > 3)
                    .Select(t => t.Name)
                    .ToList();

                //Makes SELECT(*) - wrong, always use Select, don't Include
                var result2 = db.Towns
                    .Where(t => t.Name.StartsWith("S"))
                    .Select(t => new
                    {
                        t.Name
                    })
                    .ToList();

                var result3 = db.Towns
                    .Where(t => t.Name.StartsWith("S") && Filter(t)) // can't translate Filter
                    .Select(t => new TownResultModel
                    {
                        Name = t.Name,
                        Addresses = t.Addresses
                            .Select(a => a.AddressText)
                    })
                    .ToList()
                    .Where(t => Filter(t.Name));

                var towns = db.Towns
                    .Include(t => t.Addresses)
                    .ToList();

                foreach (var town in towns)
                {
                    Console.WriteLine(town.Name);

                    foreach (var address in town.Addresses)
                    {
                        Console.WriteLine($"--- {address.AddressText}");
                    }
                }

                var towns2 = db.Towns.ToList();

                Console.WriteLine(towns.Count());

                var department = db.Departments.Find(1);
                var department2 = db.Departments.FirstOrDefault(d => d.DepartmentId == 1);
                var department3 = db.Departments.Find(new { EmployeeId = 1, ProjectId = 2 });
                var department4 = db.Towns;
                var department5 = db.Set<Town>();//.Where();

                var town = new Town
                {
                    Name = "Sofia Capital"
                };

                var entry = db.Attach(town);

                db.Towns.Add(town);
                db.Add(town);

                foreach (var town in towns)
                {
                    town.Name = town.Name + "!";
                }

                var entry2 = db.Entry(town);
                //entry.State

                db.SaveChanges();
            }

            using var db = new SoftUniContext();

            var result2 = db.Employees
                .Select(e => new
                {
                    Name = e.FirstName + " " + e.LastName,
                    Department = e.Department.Name
                })
                .ToList()
                .GroupBy(e => e.Department);

            var town = new Town
            {
                Name = "New Town"
            };

            town.Addresses.Add(new Addresses
            {
                AddressText = "Rio"
            });

            db.Add(town);

            db.SaveChanges();

            using var db2 = new SoftUniContext();

            var town2 = new Town
            {
                TownId = 33,
                Name = "Even Newer Town"
            };

            db2.Update(town);

            db.SaveChanges();

            using var db3 = new SoftUniContext();

            var town3 = db3.Towns.Find(33);

            town3.Name = "Old Town";

            db3.Towns.Remove(new Town { TownId = 33 });
            db3.Towns.Remove(town3);

            db3.SaveChanges();

            using var db4 = new SoftUniContext();

            var town4 = db4.Towns
                .Include(t => t.Addresses)
                .FirstOrDefault(t => t.TownId == 33);

            foreach (var address in town4.Addresses)
            {
                db.Addresses.Remove(address);
            }

            db4.Towns.Remove(town4);

            db4.SaveChanges();

            using var db5 = new SoftUniContext();

            var town5 = db5.Towns
                .Select(t => new
                {
                    t.TownId,
                    Addresses = t.Addresses.Select(a => a.AddressId)
                })
                .FirstOrDefault(t => t.TownId == 33);

            foreach (var address in town5.Addresses)
            {
                db.Addresses.Remove(new Addresses {AddressId = address});
            }

            db5.Towns.Remove(new Town {TownId = town5.TownId});

            db5.SaveChanges();

            using var db6 = new SoftUniContext();

            var result6 = db.Towns
                .Select(t => new
                {
                    t.Name,
                    Addresses = t.Addresses
                        .Select(a => a.AddressText)
                })
                .ToList();

            db6.Towns
                .GroupJoin(
                    db6.Addresses,
                    t => t.TownId,
                    a => a.TownId,
                    (t, a) => new
                    {
                        Name = t.Name,
                        Addresses = a.Select(a => a.AddressText)
                    })
                .ToList();
        }
    }
}
