using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Core.Contracts;
using ViceCity.Models.Guns;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Players;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Core
{
    public class Controller : IController
    {
        private IPlayer mainPlayer;
        private Queue<IGun> queueOfGuns;
        private INeighbourhood gangNeighbourhood;
        private IList<IPlayer> civilPlayers;

        public Controller()
        {
            this.mainPlayer = new MainPlayer();
            this.queueOfGuns = new Queue<IGun>();
            this.gangNeighbourhood = new GangNeighbourhood();
            this.civilPlayers = new List<IPlayer>();
        }

        public string AddGun(string type, string name)
        {
            if (type == "Pistol")
            {
                IGun gun = new Pistol(name);
                this.queueOfGuns.Enqueue(gun);
                return $"Successfully added {name} of type: {type}";
            }
            else if (type == "Rifle")
            {
                IGun gun = new Rifle(name);
                this.queueOfGuns.Enqueue(gun);
                return $"Successfully added {name} of type: {type}";
            }
            else
            {
                return $"Invalid gun type!";
            }
        }

        public string AddGunToPlayer(string name)
        {
            string gunName = string.Empty;
            if (this.queueOfGuns.Count == 0)
            {
                return "There are no guns in the queue!";
            }
            if (name == "Vercetti")
            {
                gunName = this.queueOfGuns.Peek().Name;
                this.mainPlayer.GunRepository.Add(this.queueOfGuns.Dequeue());
                return $"Successfully added {gunName} to the Main Player: Tommy Vercetti";
            }
            if (!this.civilPlayers.Any(p => p.Name == name) && name != "Vercetti")
            {
                return "Civil player with that name doesn't exists!";
            }
            gunName = this.queueOfGuns.Peek().Name;
            this.civilPlayers.First(p => p.Name == name).GunRepository.Add(this.queueOfGuns.Dequeue());
            return $"Successfully added {gunName} to the Civil Player: {name}";
        }

        public string AddPlayer(string name)
        {
            this.civilPlayers.Add(new CivilPlayer(name));
            return $"Successfully added civil player: {name}!";
        }

        public string Fight()
        {
            int numberOfCivilPlayers = this.civilPlayers.Count;
            this.gangNeighbourhood.Action(this.mainPlayer, this.civilPlayers);
            if (this.mainPlayer.LifePoints == 100 && this.civilPlayers.Count == numberOfCivilPlayers && this.civilPlayers.All(p => p.LifePoints == 50))
            {
                return $"Everything is okay!";
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("A fight happened:");
                sb.AppendLine($"Tommy live points: {this.mainPlayer.LifePoints}!");
                sb.AppendLine($"Tommy has killed: {numberOfCivilPlayers - this.civilPlayers.Count} players!");
                sb.AppendLine($"Left Civil Players: {this.civilPlayers.Count}!");
                return sb.ToString().TrimEnd();
            }
        }
    }
}
