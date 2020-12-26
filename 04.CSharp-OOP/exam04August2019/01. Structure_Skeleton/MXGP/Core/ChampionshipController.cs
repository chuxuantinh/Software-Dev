using MXGP.Core.Contracts;
using MXGP.Models.Motorcycles;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Races;
using MXGP.Models.Races.Contracts;
using MXGP.Models.Riders;
using MXGP.Models.Riders.Contracts;
using MXGP.Repositories;
using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Core
{
    public class ChampionshipController : IChampionshipController
    {
        private RiderRepository riderRepository;
        private MotorcycleRepository motorcycleRepository;
        private RaceRepository raceRepository;
        private IRider rider;
        private IMotorcycle motorcycle;
        private IRace race;

        public ChampionshipController()
        {
            this.riderRepository = new RiderRepository();
            this.motorcycleRepository = new MotorcycleRepository();
            this.raceRepository = new RaceRepository();
        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            if (this.riderRepository.GetByName(riderName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, riderName));
            }
            if (this.motorcycleRepository.GetByName(motorcycleModel) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.MotorcycleNotFound, motorcycleModel));
            }

            this.rider = this.riderRepository.GetByName(riderName);
            this.motorcycle = this.motorcycleRepository.GetByName(motorcycleModel);
            this.rider.AddMotorcycle(this.motorcycle);

            return string.Format(OutputMessages.MotorcycleAdded, riderName, motorcycleModel);
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            if (this.raceRepository.GetByName(raceName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            if (this.riderRepository.GetByName(riderName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, riderName));
            }

            this.race = this.raceRepository.GetByName(raceName);
            this.rider = this.riderRepository.GetByName(riderName);
            this.race.AddRider(rider);

            return string.Format(OutputMessages.RiderAdded, riderName, raceName);
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            if (this.motorcycleRepository.GetByName(model) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.MotorcycleExists, model));
            }

            if (type == "Speed")
            {
                this.motorcycle = new SpeedMotorcycle(model, horsePower);
                
            }
            else if (type == "Power")
            {
                this.motorcycle = new PowerMotorcycle(model, horsePower);
            }

            this.motorcycleRepository.Add(motorcycle);
            return string.Format(OutputMessages.MotorcycleCreated, motorcycle.GetType().Name, model);
        }

        public string CreateRace(string name, int laps)
        {
            if (this.raceRepository.GetByName(name) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            this.race = new Race(name, laps);
            this.raceRepository.Add(race);

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string CreateRider(string riderName)
        {
            if (this.riderRepository.GetByName(riderName) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RiderExists, riderName));
            }

            this.rider = new Rider(riderName);
            this.riderRepository.Add(rider);
            return string.Format(OutputMessages.RiderCreated, riderName);
        }

        public void End()
        {
            Environment.Exit(0);
        }

        public string StartRace(string raceName)
        {
            if (this.raceRepository.GetByName(raceName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            if (this.raceRepository.GetByName(raceName).Riders.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            List<IRider> riders = this.raceRepository.GetByName(raceName).Riders.OrderByDescending(r => r.Motorcycle.CalculateRacePoints(this.raceRepository.GetByName(raceName).Laps)).ToList();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format(OutputMessages.RiderFirstPosition, riders[0].Name, raceName));
            sb.AppendLine(string.Format(OutputMessages.RiderSecondPosition, riders[1].Name, raceName));
            sb.AppendLine(string.Format(OutputMessages.RiderThirdPosition, riders[2].Name, raceName));

            return sb.ToString().TrimEnd();
        }
    }
}
