using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections;

namespace AA
{
    class Skill : SpriteAnimation
    {

        float cooldownTime; //Holds how long the cooldown is
        float currentTime = 0f; //A cooldown timer
        float timer; //Animation timer
        float interval;

        public Vector2 spwnPosition; //The place the skill spawns when used by character
        public Vector2 iconPosition; //Position of icon
        public Vector2 iconDimension;

        public Texture2D skillTexture; //The sprite of the skill used
        public Texture2D iconTexture; //The sprite of the icon

        public float myTransparency; //

        public int currentFrame = 0; //Starting Frame

        public enum State
        {
            Active, //State of being used
            Ready, //State of ready to use
            Cooldown, //State of unable to use
        }

        public State currentState; //Holds what state it is current in

        int damage;

        public Skill()
        {
            //Default sets the skill to be ready
            currentState = State.Ready;
            myTransparency = 1f;
            //Initializes Cooldown
            cooldownTime = 10f;

            spwnPosition = Vector2.Zero;
            myPosition = spwnPosition;

            iconDimension = Vector2.Zero;

            interval = 100f;

            currentFrame = 0;

            damage = 1;
        }//ends constructor

        public Skill(float cooldown)
        {
            //Default sets the skill to be ready
            currentState = State.Ready;
            myTransparency = 1f;
            //Initializes Cooldown
            cooldownTime = cooldown;

            spwnPosition = Vector2.Zero;
            myPosition = spwnPosition;

            iconDimension = Vector2.Zero;

            interval = 100f;

            currentFrame = 0;

            damage = 1;
        }//ends constructor

        public Skill(float cooldown, int damage)
        {
            //Default sets the skill to be ready
            currentState = State.Ready;
            myTransparency = 1f;
            //Initializes Cooldown
            cooldownTime = cooldown;

            spwnPosition = Vector2.Zero;
            myPosition = spwnPosition;

            iconDimension = Vector2.Zero;

            interval = 100f;

            currentFrame = 0;

            this.damage = damage;
        }//ends constructor

        public Skill(float cooldown, Vector2 spawnPos, int damage)
        {
            //Default sets the skill to be ready
            currentState = State.Ready;

            //Initializes Cooldown
            cooldownTime = cooldown;

            iconDimension = Vector2.Zero;

            spwnPosition = spawnPos; //Sets spwnPosition equal to where the skill will spawn when used

            interval = 200f;

            currentFrame = 0;

            this.damage = damage;
        }//ends constructor

        public Skill(float cooldown, Vector2 spawnPos, Vector2 iconPos, int damage)
        {
            //Default sets the skill to be ready
            currentState = State.Ready;

            //Initializes Cooldown
            cooldownTime = cooldown;

            spwnPosition = spawnPos; //Sets spwnPosition equal to where the skill will spawn when used

            iconPosition = iconPos; //Sets the position of the icon
            iconDimension = Vector2.Zero;

            interval = 200f;

            currentFrame = 0;

            this.damage = damage;
        }//ends constructor

        /*
        * Loads the sprite
        */
        public void LoadContent(ContentManager theContentManager, string iconName, string spriteName, Vector2 spriteDimensions, Vector2 leftFrame, Vector2 rightFrame)
        {

            skillTexture = theContentManager.Load<Texture2D>(spriteName);

            if (iconName != null)
            {
                iconTexture = theContentManager.Load<Texture2D>(iconName);
                iconDimension = new Vector2(iconTexture.Width, iconTexture.Height);
            }

            spriteWidth = (int)spriteDimensions.X;
            spriteHeight = (int)spriteDimensions.Y;

            leftFrames = leftFrame;
            rightFrames = rightFrame;

            frameSize = new Rectangle(currentFrame * spriteWidth, 0, spriteWidth, spriteHeight);
        }//ends LoadContent() method

        /*
        * Loads the sprite
        */
        public void LoadContent(ContentManager theContentManager, string iconName, Vector2 iconDimension)
        {
            iconTexture = theContentManager.Load<Texture2D>(iconName);

            this.iconDimension.X = (int)iconDimension.X;
            this.iconDimension.Y = (int)iconDimension.Y;

            frameSize = new Rectangle(currentFrame * spriteWidth, 0, spriteWidth, spriteHeight);
        }//ends LoadContent() method

        /*
       * This bounding box will be used for collision checking
       */
        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle((int)spwnPosition.X, (int)spwnPosition.Y, spriteWidth, spriteHeight);
            } //this is read only, just an accessor

        }

        /*
         * Puts the Skill on cooldown
         * Changes the state of the skill to Ready after a certain amount of time
         */
        public void onCooldown(GameTime gameTime)
        {
            currentState = State.Cooldown;

            currentTime += (float)gameTime.ElapsedGameTime.TotalSeconds; //Gets the total amount of time passed
            myTransparency += (currentTime / (cooldownTime) - .3f);

            if (currentTime >= cooldownTime)
            {
                currentTime = 0; //Resets the time
                currentFrame = 0;
                myTransparency = 1; //No transparency
                currentState = State.Ready; //Sets the state to Ready
                //Console.Write("Skill is ready.");

            }//ends if statement

        }//ends onCooldown()

        public void activate()
        {
            if (currentState == State.Ready)
            {
                currentState = State.Active;
            }
        }//ends activate() method

        public void ready()
        {
            currentState = State.Ready;
        }//ends activate() method

        public void setPosition(Vector2 newPosition)
        {
            spwnPosition = newPosition;
        }

        public void setIconPosition(Vector2 newPosition)
        {
            iconPosition = newPosition;
        }

        public State getState()
        {
            return currentState;
        }

        public State getActive()
        {
            return State.Active;
        }

        public State getCooldown()
        {
            return State.Cooldown;
        }

        public bool isCooldown()
        {
            if (currentState == State.Cooldown)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public State getReady()
        {
            return State.Ready;
        }

        public void setDamage(int newDamage)
        {
            damage = newDamage;
        }

        public int getDamage()
        {
            return damage;
        }

        public void animateSkillLeft(GameTime gameTime)
        {
            if (currentState == State.Active)
            {

                if (currentFrame < leftFrames.X || currentFrame > leftFrames.Y)
                {
                    currentFrame = (int)leftFrames.X;
                }

                if (currentFrame < leftFrames.Y)
                {
                    timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

                    if (timer > interval)
                    {
                        currentFrame++;
                        timer = 0f;
                    }//ends if statement
                }

                if (currentFrame == leftFrames.Y)
                {
                    currentState = State.Cooldown;
                }
            }
        }

        public void animateSkillRight(GameTime gameTime)
        {
            if (currentState == State.Active)
            {

                if (currentFrame < rightFrames.X || currentFrame > rightFrames.Y)
                {
                    currentFrame = (int)rightFrames.X;
                }

                if (currentFrame < rightFrames.Y)
                {
                    timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

                    if (timer > interval)
                    {
                        currentFrame++;
                        timer = 0f;
                    }//ends if statement
                }

                if (currentFrame == rightFrames.Y)
                {
                    currentState = State.Cooldown;
                }
            }
        }


        public void drawIcon(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(iconTexture, iconPosition, Color.White * myTransparency);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (currentState == State.Active)
            {
                if (skillTexture != null)
                    spriteBatch.Draw(this.skillTexture, this.spwnPosition, this.frameSize, Color.White);

            }
            if (iconTexture != null)
                drawIcon(spriteBatch);
        }

        public void Update(GameTime gameTime, String charDirection)
        {
            frameSize = new Rectangle(currentFrame * spriteWidth, 0, spriteWidth, spriteHeight);
            myPosition = spwnPosition;

            if (currentState == State.Cooldown)
            {
                myTransparency = .25f;
                spwnPosition = Vector2.Zero;
                onCooldown(gameTime);
            }
            if (currentState == State.Ready)
            {
                myTransparency = 1;
                spwnPosition = Vector2.Zero;
            }

            if (charDirection == "left")
            {
                animateSkillLeft(gameTime);
            }
            else
            {
                animateSkillRight(gameTime);
            }


        }//ends Update() method

    }
}
