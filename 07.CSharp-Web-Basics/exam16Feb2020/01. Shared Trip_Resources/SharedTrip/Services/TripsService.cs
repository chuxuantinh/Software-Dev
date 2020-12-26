using SharedTrip.Models;
using SharedTrip.ViewModels.Trips;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SharedTrip.Services
{
    public class TripsService : ITripsService
    {
        private readonly ApplicationDbContext dbContext;

        public TripsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public string Add(TripAddInputModel tripAddInputModel)
        {
            var trip = new Trip()
            {
                StartPoint = tripAddInputModel.StartPoint,
                EndPoint = tripAddInputModel.EndPoint,
                DepartureTime = DateTime.ParseExact(tripAddInputModel.DepartureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                ImagePath = tripAddInputModel.ImagePath,
                Seats = tripAddInputModel.Seats,
                Description = tripAddInputModel.Description,
            };

            this.dbContext.Trips.Add(trip);
            this.dbContext.SaveChanges();

            return trip.Id;
        }

        public IEnumerable<AllTripViewModel> GetAll()
        {
            return this.dbContext.Trips.Select(t => new AllTripViewModel
            {
                DepartureTime = t.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                EndPoint = t.EndPoint,
                Seats = t.Seats,
                StartPoint = t.StartPoint,
                Id = t.Id
            })
            .ToArray();
        }

        public GetTripViewModel GetTrip(string id)
        {
            return this.dbContext.Trips.Where(x => x.Id == id).Select(t => new GetTripViewModel
            {
                Id = t.Id,
                DepartureTime = t.DepartureTime.ToString("dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                Description = t.Description,
                EndPoint = t.EndPoint,
                ImagePath = t.ImagePath,
                Seats = t.Seats,
                StartPoint = t.StartPoint
            })
            .FirstOrDefault();
        }

        public bool AddUserToTrip(string tripId, string userId)
        {
            var targetTrip = this.dbContext.Trips.FirstOrDefault(x => x.Id == tripId);
            var userTrip = new UserTrip
            {
                TripId = tripId,
                UserId = userId
            };

            if (!this.dbContext.UserTrips.Any(x => x.TripId == userTrip.TripId && x.UserId == userTrip.UserId))
            {
                targetTrip.UserTrips.Add(userTrip);
                targetTrip.Seats--;
                dbContext.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
