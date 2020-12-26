namespace SimpleSnake
{
    using NAudio.Wave;
    using SimpleSnake.Core;
    using SimpleSnake.GameObjects;
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();

            //using (var wavOut = new WaveOutEvent())
            //{
            //    using (var wavReader = new WaveFileReader(@"F:\softuni\05 CSharp OOP\18.Workshop-Exercise9\06.CSharp-OOP-Basics-Workshop-SimpleSnake\SimpleSnake\track.wav")
            //    {
            //        wavOut.Init(wavReader);
            //        wavOut.Play();
            //    }
            //}

            Wall wall = new Wall(60, 20);
            Snake snake = new Snake(wall);

            Engine engine = new Engine(wall, snake);
            engine.Run();
        }
    }
}
