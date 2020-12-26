using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SoftUni.AlienShooter
{
    class Program
    {
        static void Main(string[] args)
        {
            //Indicator that our game is started/running
            bool isGameOn = true;

            //We are hiding the cursor, so the
            //gaming experience is say better
            Console.CursorVisible = false;

            //Setting the width and height of our screen
            int screenWidth = 30;
            int screenHeight = 20;

            //It's very important to set the window size first
            //and then the buffer size. Otherwise you will get an error
            Console.SetWindowSize(screenWidth, screenHeight);
            Console.SetBufferSize(screenWidth, screenHeight);

            //These are our variables where we are going to store
            //the current horizontal (projextileX) and vetical (projectileY) possition of the bullet
            int projectileX = 0;
            int projectileY = 0;
            //The boolean variable is going to indicate 
            //should we draw the bullet on the screen or not
            bool isShotMade = false;

            //Using the same logic for as for the projectile
            //we are holding the current possition of the player in two variables
            int playerX = screenWidth / 2;
            int playerY = screenHeight - 1;

            while (isGameOn)
            {
                //Using Console.ReadKey to obtain 
                //information of what key is being pressed

                //Console.KeyAvailable indicates when a keyboard button is pressed
                //Only then we pull the information about that key from the buffer
                if (Console.KeyAvailable)
                {
                    var pressedKey = Console.ReadKey();
                    switch (pressedKey.Key)
                    {
                        case ConsoleKey.RightArrow:
                            //If the key is right arrow
                            //then we move the player right with one possition

                            //playerX++;
                            //playerX += 1;
                            playerX = playerX + 1;
                            break;
                        case ConsoleKey.LeftArrow:
                            //If the key is left arrow
                            //then we move the player left with one possition

                            //playerX--;
                            //playerX -= 1;
                            playerX = playerX - 1;
                            break;
                        case ConsoleKey.Spacebar:
                            //If the key is spacebar
                            //then we set the initial possition of the projectile
                            //to be right above the player drawwing and we raise the flag
                            //in order to start visualizing the symbol, which represents the bullet

                            projectileX = playerX;
                            projectileY = playerY - 1;

                            isShotMade = true;
                            break;
                    }
                }
                //Every time before we re-draw all the game objects
                //We need to completely wipe-out everything from the screen
                Console.Clear();

                //After we know where our player is we are moving the currsor
                //to that excact possition, so we can draw (write) our player
                Console.SetCursorPosition(playerX, playerY);
                Console.Write("^");

                //We should draw projectile only if it's been fired
                if (isShotMade == true)
                {
                    //Setting the cursor position where the projectile should be drawn
                    Console.SetCursorPosition(projectileX, projectileY);
                    Console.Write("*");

                    //A condition which checks is the projectile on the top line of the screen
                    //if it is not then we are moving the bullet with one position up
                    //if it is then we are marking that item as 'destroyed', so we are not going to draw it next time
                    if (projectileY > 0)
                    {
                        projectileY = projectileY - 1;
                    }
                    else
                    {
                        //isShotMade = false;
                        isShotMade = !isShotMade;
                    }
                }

                //We are using Thread.Speep to force the CPU to stop working for 100 ms
                //This way we can clearly see what's been drawn on the screen
                Thread.Sleep(100);
            }
        }
    }
}