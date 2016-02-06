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
    class BattleSprites : SpriteAnimation
    {
        public Vector2 myVelocity; //Holds the speed of Zane
        //int intDirection; //Holds the direction
        bool blnJumped; //Holds if Zane is in the air or not
        public float HP { get; set; }
        public float maxHP { get; set; }
        float healthPercentage { get; set; }
        public float currentTime = 0f; //A cooldown timer

        Texture2D hpTexture;

        public enum State
        {
            Standing,
            Attacking,
            Moving
        }

        State currentState;


        public BattleSprites()
        {
            //Sets the framesize to view
            frameSize = new Rectangle(currentFrame * spriteWidth, 0, spriteWidth, spriteHeight);

            //Defaultly, not jumping
            blnJumped = true;

            //Default HP
            HP = 100;
            maxHP = 100;
        }

        /*
        * This bounding box will be used for collision checking
         */
        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle((int)myPosition.X, (int)myPosition.Y, spriteWidth, spriteHeight);
            } //this is read only, just an accessor

        }

        public void LoadContent(ContentManager contentManager, String textureName)
        {
            hpTexture = contentManager.Load<Texture2D>("CharacterImages/HPBar"); //Loads the HP Bar texture
            base.LoadContent(contentManager, textureName); //Called to load the sprite's texture
        }

        /*
         * Provides a everlasting force downwards
         */
        public void gravity()
        {
            //If the character is in the air
            if (blnJumped == true)
            {
                float i = 2.5f; //How long the character stays in air
                myVelocity.Y += .045f * i; //How fast he falls down
            }//ends if statement

            //If the character is not in the air
            if (blnJumped == false)
            {
                myVelocity.Y = 0f; //Sets falling speed to zero
            }//ends if statement
        }//ends gravity() method

        /*
         * Getter method for velocity
         */
        public Vector2 getVelocity()
        {
            return myVelocity;
        }//ends getVelocity()

        /*
         * Setter method for velocity
         */
        public void setVelocity(Vector2 velocity)
        {
            myVelocity = velocity;
        }//ends setVelocity

        public float getHP()
        {
            return HP / maxHP;
        }

        /*
         * Getter method for blnJumped
         */
        public bool getJumped()
        {
            return blnJumped;
        }//ends getJumped()

        /*
         * Setter method for blnJumped
         */
        public void hasJumped(bool hasJump)
        {
            blnJumped = hasJump;
        }//ends hasJumped()

        public bool isDead()
        {
            if (HP <= 0)
                return true; //Sad face
            else
                return false;
        }

        /*
        * A method that runs repeatedly to check for action
        */
        public void Update(GameTime theGameTime)
        {
            base.Update(theGameTime); //Gets the previous position

            healthPercentage = HP / maxHP; //Updates amount of heatlh

            //myPosition += myVelocity;

            //this.gravity();
            //this.animate(theGameTime); //Animation 

        }//Ends Update() method

        public void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch); //Draws myTexure

            float visibleHealth = ((float)hpTexture.Width - spriteWidth / 5) * healthPercentage; //A value that shows how much the bar should be shown

            //Draws the back of the hp bar
            Rectangle hpBar = new Rectangle((int)myPosition.X + (spriteWidth / 2) - (hpTexture.Width / 2), (int)myPosition.Y - spriteHeight / 5, hpTexture.Width - spriteWidth / 5, hpTexture.Height);
            spriteBatch.Draw(hpTexture, hpBar, Color.Black);

            //Draws the front of the hp bar, the actually amount of HP
            Rectangle currentHPBar = new Rectangle((int)myPosition.X + (spriteWidth / 2) - (hpTexture.Width / 2), (int)myPosition.Y - spriteHeight / 5, (int)(visibleHealth), hpTexture.Height);
            spriteBatch.Draw(hpTexture, currentHPBar, Color.LimeGreen);


        }//ends Draw() method

        public void Drawbase(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
