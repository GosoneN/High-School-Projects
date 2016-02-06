using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace AA
{
    class SpriteAnimation : Sprite
    {
        //Global Variables
        float timer = 0f;
        float interval = 100f;
        public int currentFrame = 0; //Starting Frame
        public int spriteWidth; //Width of the sprite (Not the whole sprite sheet)
        public int spriteHeight;//Height of the sprite (Not the whole sprite sheet)

        public String charDirection; //to hold the character's direction

        //Contains which frame holds what animation/movement
        //X contains the beginning of the animation
        //Y contains the end of the animation
        public Vector2 upFrames;
        public Vector2 downFrames;
        public Vector2 leftFrames;
        public Vector2 rightFrames;

        //Allows animation with keyboard
        public bool isPlayer;

        public Rectangle frameSize; //The frame containing the sprite

        //Gets keyboard actions
        public KeyboardState currentKeyState;
        public KeyboardState previousState;


        public SpriteAnimation()
        {
            isPlayer = false;
        }

        /*
         * Animates the player
         */
        public void animate(GameTime gameTime)
        {
            previousState = currentKeyState;
            currentKeyState = Keyboard.GetState();

            if (isPlayer)
            {
                //Moving South Animation
                if (currentKeyState.IsKeyDown(Keys.Down))
                {
                    charDirection = "down";
                    animateDown(gameTime);
                }//ends if statement

                //Moving North Animation
                if (currentKeyState.IsKeyDown(Keys.Up))
                {
                    charDirection = "up";
                    animateUp(gameTime);
                }//ends if statement

                //Moving West Animation
                if (currentKeyState.IsKeyDown(Keys.Left))
                {
                    charDirection = "left";
                    animateLeft(gameTime);
                }//ends if statement

                //Moving East Animation
                if (currentKeyState.IsKeyDown(Keys.Right))
                {
                    charDirection = "right";
                    animateRight(gameTime);
                }//ends if statement
            }
            else
            {
                animateDown(gameTime);
            }
            //Creates a frame size according to movement and currentFrame
            frameSize = new Rectangle(currentFrame * spriteWidth, 0, spriteWidth, spriteHeight);
        }

        /*
        * Animation for enemy class
        * *Movement for enemy is in Enemy class
        */
        public void animateEnemy(int direction, GameTime gameTime)
        {
            {
                //Moving South Animation
                if (direction == 270)
                {
                    animateDown(gameTime);
                }//ends if statement

                //Moving North Animation
                if (direction == 90)
                {
                    animateUp(gameTime);
                }//ends if statement

                //Moving West Animation
                if (direction == 0)
                {
                    animateLeft(gameTime);
                }//ends if statement

                //Moving East Animation
                if (direction == 180)
                {
                    animateRight(gameTime);
                }//ends if statement

                //Creates a frame size according to movement and currentFrame
                frameSize = new Rectangle(currentFrame * spriteWidth, 0, spriteWidth, spriteHeight);
            }
        }

        /*
         * Animates a sprite moving down
         */
        public void animateDown(GameTime gameTime)
        {
            if (currentKeyState != previousState)
                currentFrame = (int)downFrames.X;

            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (timer > interval)
            {
                currentFrame++;

                if (currentFrame > downFrames.Y)
                {
                    currentFrame = (int)downFrames.X;
                }
                timer = 0f;
            }
        }//ends animateDown() method

        /*
         * Animates a sprite moving up
         */
        public void animateUp(GameTime gameTime)
        {
            if (currentKeyState != previousState)
                currentFrame = (int)upFrames.X;

            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (timer > interval)
            {
                currentFrame++;

                if (currentFrame > upFrames.Y)
                {
                    currentFrame = (int)upFrames.X;
                }
                timer = 0f;
            }//ends if statement
        }//ends animateUp() method

        /*
         * Animates a sprite moving right
         */
        public void animateRight(GameTime gameTime)
        {
            if (currentKeyState != previousState)
                currentFrame = (int)rightFrames.X;

            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (timer > interval)
            {
                currentFrame++;

                if (currentFrame > rightFrames.Y)
                {
                    currentFrame = (int)rightFrames.X;
                }
                timer = 0f;
            }//ends if statement
        }//ends animateRight() method

        /*
         * Animates a sprite moving left
         */
        public void animateLeft(GameTime gameTime)
        {
            if (currentKeyState != previousState)
                currentFrame = (int)leftFrames.X;

            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (timer > interval)
            {
                currentFrame++;

                if (currentFrame > leftFrames.Y)
                {
                    currentFrame = (int)leftFrames.X;
                }
                timer = 0f;
            }//ends if statement
        }//ends animateLeft() method

        /*
         * Animates a sprite doing something else
        */
        public void animateSomething(GameTime gameTime, Vector2 frames, float interval)
        {
            if (currentKeyState != previousState)
                currentFrame = (int)frames.X;

            if (currentFrame < frames.Y)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

                if (timer > interval)
                {
                    currentFrame++;
                    timer = 0f;
                }//ends if statement
            }
        }//ends animateSomething() method


        public void DrawZane(SpriteBatch spriteBatch)
        {
            Vector2 zanePosition = new Vector2(1024 / 2, 768 / 2); //center of the window vertically and horizontally
            spriteBatch.Draw(myTexture, zanePosition, this.frameSize, Color.White); //draw Zane
        }//ends the DrawZane method

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.myTexture, this.myPosition, this.frameSize, Color.White);
        }//ends Draw() method

    }
}
