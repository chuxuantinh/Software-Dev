using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SharedTrip.ViewModels.Trips
{
    public class TripDetailsViewModel
    {
        public string Id { get; set; }

        public string ImagePath { get; set; }

        public string StartPoint { get; set; }

        public string EndPoint { get; set; }

        public DateTime DepartureTime { get; set; }

        public string DepartureTimeAsString => this.DepartureTime.ToString(CultureInfo.GetCultureInfo("bg-BG"));

        public int Seats { get; set; }

        public int AvailableSeats => this.Seats - this.UsedSeats;

        public string Description { get; set; }

        public int UsedSeats { get; set; }

        public string DepartureTimeFormatted => this.DepartureTime.ToString("s");
    }
}
