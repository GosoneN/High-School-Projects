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
    class BattleEnemy : BattleSprites
    {

        public enum State
        {
            Following,
            Staying,
            Returning,
            Attacking,
            Hurt
        }

        State currentState;

        Skill defaultattack;

        float currentTime = 0f; //A cooldown timer

        Vector2 followPosition;

        Vector2 spawnPosition;

        int strength, defense, agility;

        Random myRandom;

        public BattleEnemy(int enemyMaxHP, int Strength, int Defense, int Agility)
        {
            HP = enemyMaxHP;
            maxHP = enemyMaxHP;

            strength = Strength;
            defense = Defense;
            agility = Agility;

            mySpeed = 1 + (agility / 10);

            myRandom = new Random();
            spawnPosition = new Vector2(myRandom.Next(800, 1000), 500);

            myPosition = spawnPosition;

            currentFrame = 0;

            hasJumped(true);

            currentState = State.Staying;

            defaultattack = new Skill(2f, myPosition, strength);
        }

        public void LoadContent(ContentManager contentManager, String textureName, int spriteWidth, int spriteHeight, String attackName)
        {
            base.LoadContent(contentManager, textureName);

            defaultattack.LoadContent(contentManager, null, attackName, new Vector2(32, 32), new Vector2(4, 6), new Vector2(1, 3));

            this.spriteWidth = spriteWidth;
            this.spriteHeight = spriteHeight;
            frameSize = new Rectangle(currentFrame * spriteWidth, 0, spriteWidth, spriteHeight);
        }//ends LoadContent()

        public Skill getDefaultAttack()
        {
            return defaultattack;
        }

        public void setfollowPosition(Vector2 pos)
        {
            followPosition = pos;
        }

        public void setFollow()
        {
            currentState = State.Following;
        }

        public void setReturn()
        {
            currentState = State.Returning;
        }

        public void setAttack()
        {
            currentState = State.Attacking;
        }


        public void moveToPlayer()
        {
            if (myPosition.X - 26 > followPosition.X)
            {
                myPosition.X -= mySpeed;
                charDirection = "right";

            }
            else if (myPosition.X + spriteWidth < followPosition.X)
            {
                myPosition.X += mySpeed;
                charDirection = "left";

            }

            if ((myPosition.X >= followPosition.X - spriteWidth) && (myPosition.X <= followPosition.X + spriteWidth / 2))
            {
                setAttack();
            }
        }


        public void returnToSpawn()
        {
            if (myPosition.X > spawnPosition.X)
            {
                myPosition.X -= mySpeed;
                charDirection = "right";

            }
            else if (myPosition.X < spawnPosition.X)
            {
                myPosition.X += mySpeed;
                charDirection = "left";

            }

            if (myPosition.X == spawnPosition.X)
            {
                setFollow();
            }
        }

        public void attack(GameTime gameTime)
        {

            if (charDirection == "left")
            {
                defaultattack.setPosition(new Vector2(myPosition.X + spriteWidth, myPosition.Y + (spriteWidth / 2) - (defaultattack.spriteHeight / 2)));
            }
            else
            {
                defaultattack.setPosition(new Vector2(myPosition.X - defaultattack.spriteWidth, myPosition.Y + (spriteWidth / 2) - (defaultattack.spriteHeight / 2)));
            }
            defaultattack.activate();

            onCooldown(gameTime);
        }

        public void isHurt(GameTime gameTime)
        {
            currentState = State.Hurt;
        }

        public void getHurt(float damage)
        {
            if (currentState != State.Hurt)
            {
                HP -= damage - (defense / 10);
            }
        }

        public void hurtCooldown(GameTime gameTime)
        {
            currentState = State.Hurt;

            currentTime += (float)gameTime.ElapsedGameTime.TotalMilliseconds; //Gets the total amount of time passed

            if (currentTime >= 700)
            {
                currentTime = 0; //Resets the time
                currentState = State.Returning; //Sets the state to Ready
                //Console.Write("Skill is ready.");

            }//ends if statement

        }//ends onCooldown()


        public void onCooldown(GameTime gameTime)
        {
            currentState = State.Attacking;

            currentTime += (float)gameTime.ElapsedGameTime.TotalSeconds; //Gets the total amount of time passed

            if (currentTime >= 2)
            {
                currentTime = 0; //Resets the time
                currentFrame = 0;
                defaultattack.ready();
                currentState = State.Returning; //Sets the state to Ready
                //Console.Write("Skill is ready.");

            }//ends if statement

        }//ends onCooldown()

        public void Update(GameTime gameTime)
        {
            myPosition += getVelocity();
            gravity();
            if (currentState == State.Following)
            {
                moveToPlayer();
            }

            if (currentState == State.Attacking)
            {
                attack(gameTime);
            }

            if (currentState == State.Returning)
            {
                returnToSpawn();
            }

            if (currentState == State.Hurt)
            {
                hurtCooldown(gameTime);
            }

            defaultattack.Update(gameTime, charDirection);

            base.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            if (defaultattack.getState() == defaultattack.getActive())
                defaultattack.Draw(spriteBatch);
        }
    }
}
