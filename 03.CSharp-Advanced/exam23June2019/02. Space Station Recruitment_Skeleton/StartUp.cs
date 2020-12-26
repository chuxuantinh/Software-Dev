using System;

namespace SpaceStationRecruitment
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //Initialize the repository
            SpaceStation spaceStation = new SpaceStation("Apolo", 10);
            //Initialize entity
            Astronaut astronaut = new Astronaut("Stephen", 40, "Bulgaria");
            //Print Astronaut
            Console.WriteLine(astronaut); //Astronaut: Stephen, 40 (Bulgaria)

            //Add Astronaut
            spaceStation.Add(astronaut);
            //Remove Astronaut
            spaceStation.Remove("Astronaut name"); //false

           

        }
    }
}
