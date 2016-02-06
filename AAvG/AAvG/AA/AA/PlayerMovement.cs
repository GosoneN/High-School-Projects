using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace AA
{
    class PlayerMovement
    {

        //KeyboardState myKeyboard;

        int mySpeed; // The speed of the character

        //The window size
        int MinX; 
        int MaxX;
        int MinY;
        int MaxY;

        //Sprite to be moved
        Sprite myCharacter;

        //Booleans to tell if the sprite can move in a direction
        public bool canLeft;
        public bool canRight;
        public bool canUp;
        public bool canDown;

        //Holds the direction of the player
        public int playerDirection;

        /*
         * Constructor
         * 
         * movementSpeed - How fast the character will move
         * windowHeight - The height of the window
         * windowWidth- The width of the window
         */
        public PlayerMovement(Sprite character)
        {
            //Sets the character
            myCharacter = character;

            //myKeyboard = Keyboard.GetState();
            mySpeed = myCharacter.getSpeed();


            //Sets varibles as window size
            MinX = 0;
            MinY = 0;
            MaxX = 1024 - 20; //Sets the max X boundary to move
            MaxY = 768 - 25; //Sets the max Y boundary to move

            //Enables character to move in a direction
            canRight = true;
            canLeft = true;
            canUp = true;
            canDown = true;

            //Sets player direction to South defaultly
            playerDirection = 270;

        }//ends constructor

        /*
         * Moves the character with keyboard
         * 
         * character - The sprite to move
         */        
        public void moveChar(GameTime gameTime)
        {
            
            KeyboardState myKeyboard = Keyboard.GetState();

            /*
            if (canRight)
                if (myKeyboard.IsKeyDown(Keys.Right)) //Right Key
                    if (myCharacter.getPosition().X < MaxX) //Keeps character from exiting the window
                    {
                        myCharacter.myPosition.X += mySpeed;
                        playerDirection = 180;
                    }
            if (canLeft)
                if (myKeyboard.IsKeyDown(Keys.Left)) //Left Key
                    if (myCharacter.getPosition().X > MinX) //Keeps character from exiting the window
                    {
                        myCharacter.myPosition.X -= mySpeed;
                        playerDirection = 0;
                    }
            if (canUp)
                if (myKeyboard.IsKeyDown(Keys.Up)) //Up Key
                    if (myCharacter.getPosition().Y > MinY) //Keeps character from exiting the window
                    {
                        myCharacter.myPosition.Y -= mySpeed;
                        playerDirection = 90;
                    }
            if (canDown)
                if (myKeyboard.IsKeyDown(Keys.Down)) //Down Key
                    if (myCharacter.getPosition().Y < MaxY) //Keeps character from exiting the window
                    {
                        myCharacter.myPosition.Y += mySpeed;
                        playerDirection = 270;
                    }
            */
        }//ends moveChar()
          

    }
}
