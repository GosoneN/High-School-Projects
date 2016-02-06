using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace AA
{
    class Zane : SpriteAnimation
    {
        //A "State", any type of action, of the sprite 
        enum State
        {
            Standing,
            Walking //Walking State
        }

        //State currentKeyState = State.Walking; //Variable to hold the state of the sprite
        public PlayerMovement myMovement; //Enables player controls
        private bool blnCanMove; //Allows movement

        public Zane()
        {
            //Initialize Variables
            mySpeed = 3; //Sets the movement speed
            spriteWidth = 20; //Width of the sprite (Not the whole sprite sheet)
            spriteHeight = 25; //Height of the sprite (Not the whole sprite sheet)

            //Sets the frames of animation
            downFrames = new Vector2(0, 1);
            upFrames = new Vector2(2, 3);
            leftFrames = new Vector2(6, 7);
            rightFrames = new Vector2(4, 5);
            myPosition = new Vector2(1024 / 2, 768 / 2); //center of the window vertically and horizontally

            //Allows animation with keyboard
            isPlayer = true;

            //Allows movement
            blnCanMove = true;

        }//Ends Zane() constructor

        public void LoadContent(ContentManager theContentManager)
        {
            base.LoadContent(theContentManager, "CharacterImages/CharacterStripe"); //Loads in Zane.png

            myMovement = new PlayerMovement(this); //Creates movement for this character

            spriteWidth = 20; //Width of the sprite (Not the whole sprite sheet)
            spriteHeight = 25; //Height of the sprite (Not the whole sprite sheet)

        }//ends LoadContent() method

        /*
         *Enables movement for Zane
         */
        public void canMove(bool canMove)
        {
            blnCanMove = canMove;
        }//ends canMove() method

        /*
         * A method that runs repeatedly to check for action
         */
        public void Update(GameTime theGameTime)
        {
            base.Update(theGameTime); //Gets the previous position
            if (blnCanMove)
                //myMovement.moveChar(theGameTime); //Movement
            this.animate(theGameTime); //Animation 

        }//Ends Update() method

    }
}//End Zane class
