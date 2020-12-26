using SharedTrip.Models;
using SharedTrip.ViewModels.Trips;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.Services
{
    public interface ITripsService
    {
        string Add(TripAddInputModel tripAddInputModel);

        IEnumerable<AllTripViewModel> GetAll();

        GetTripViewModel GetTrip(string id);

        bool AddUserToTrip(string tripId, string userId);
    }
}
