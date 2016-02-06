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
    class Enemy
    {
        float timer = 0f;
        float interval = 100f;
        public int currentFrame = 0; //Starting Frame
        public Rectangle frameSize;

        Vector2 enemyPosition, originalPosition;
        bool blnAlive;
        int direction; //0 means up, 1 means down

        public Enemy(Vector2 tilePosition)
        {
            //The position of the sprite
            enemyPosition = tilePosition;
            originalPosition = tilePosition;

            //the enemy is alive
            blnAlive = true;

            //this means down
            direction = 0; 
        }

        //The start of movement methods

        /*
         * This bounding box will be used for collision checking
         */
        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle((int)enemyPosition.X, (int)enemyPosition.Y, 32, 32); //returns the rectangle bounding box

            } //this is read only, just an accessor used to check collision

        }

        /*
         * Moves the enemy North(Up)
         */
        public void moveUp()
        {
            if(enemyPosition.Y <= 32)
                direction = 1; //go down now, changes the direction
            else
                enemyPosition -= new Vector2(0, 2);

        }//ends moveUp() method

        /*
         * Moves the enemy South(Down)
         */
        public void moveDown()
        {
            if (enemyPosition.Y >= 2240)
                direction = 0; //go up now, changes the direction
            else
                enemyPosition += new Vector2(0, 2);

        }//ends moveDown() method

        public void kill()
        {
            blnAlive = false;
        }

        public Vector2 getPosition()
        {
            return enemyPosition;              
        }

        public Vector2 getOriginalPosition()
        {
            return originalPosition;
        }

        /*
         * A method solely used for the update method
         * Keeps the enemy moving the right direction after myDirection changes
         */
        public void moveUpdater(GameTime gameTime)
        {
            if (blnAlive)
            {
                if (direction == 0) //0 means go up
                    moveUp();
                else if (direction == 1) //1 means go down
                    moveDown();

                timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

                if (timer > interval)
                {
                    currentFrame++;

                    if (currentFrame > 3)
                    {
                        currentFrame = 0;
                    }
                    timer = 0f;
                }

                //Creates a frame size according to movement and currentFrame
                frameSize = new Rectangle(currentFrame * 32, 0, 32, 32);
            }
        }//ends moveUpdater() method

    }//ends Enemy class
}
