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
    class BattleAeren : BattleSprites
    {

        public enum State
        {
            Following,
            Staying,
            Healing,
            ABuffing,
            DBuffing
        }

        State currentState;

        Vector2 followPosition;

        ArrayList skillList;
        Skill skillHeal;
        Skill skillDefenseBuff;
        Skill skillAttackBuff;

        int attackBuffed, defenseBuffed;

        Vector2 camPos;

        public BattleAeren(Vector2 ZanePosition)
        {

            //Sets the frames of animation
            //Only has one animation facing one way
            downFrames = new Vector2(0, 0);
            upFrames = new Vector2(0, 0);
            leftFrames = new Vector2(8, 13);
            rightFrames = new Vector2(2, 7);

            followPosition = ZanePosition;

            mySpeed = 3;

            myPosition = new Vector2(275, 300);
            frameSize = new Rectangle(currentFrame * spriteWidth, 0, spriteWidth, spriteHeight);

            currentState = State.Following;

            skillList = new ArrayList();
            skillHeal = new Skill(10f);
            skillDefenseBuff = new Skill(15f);
            skillAttackBuff = new Skill(15f);

            skillList.Add(skillHeal);
            skillList.Add(skillDefenseBuff);
            skillList.Add(skillAttackBuff);

            attackBuffed = 0;
            defenseBuffed = 0;
        }

        /*
        * Loads textures
        */
        public void LoadContent(ContentManager theContentManager)
        {
            base.LoadContent(theContentManager, "CharacterImages/F(F)Char"); //Loads in F(M)Char.png

            skillHeal.LoadContent(theContentManager, "CharacterImages/Heal-TobeReplaced", new Vector2(48, 48));
            skillDefenseBuff.LoadContent(theContentManager, "CharacterImages/Heal-TobeReplaced", new Vector2(48, 48));
            skillAttackBuff.LoadContent(theContentManager, "CharacterImages/Heal-TobeReplaced", new Vector2(48, 48));

            //Sets the dimensions of a single sprite
            spriteWidth = 26;
            spriteHeight = 46;
            frameSize = new Rectangle(currentFrame * spriteWidth, 0, spriteWidth, spriteHeight);
        }//ends LoadContent() method


        //Press the keys and use skills
        public void battleMovement()
        {
            currentKeyState = Keyboard.GetState();

            if (currentKeyState.IsKeyDown(Keys.Q))
            {
                if (skillHeal.isCooldown() == false)
                {
                    currentState = State.Healing;
                }
            }

            if (currentKeyState.IsKeyDown(Keys.W))
            {
                if (skillDefenseBuff.isCooldown() == false)
                {
                    currentState = State.DBuffing;
                }
            }

            if (currentKeyState.IsKeyDown(Keys.E))
            {
                if (skillAttackBuff.isCooldown() == false)
                {
                    currentState = State.ABuffing;
                }
            }
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
        }

        public void setfollowPosition(Vector2 pos)
        {
            followPosition = pos;
        }

        public bool isHealing()
        {
            if (currentState == State.Healing)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void heal(BattleSprites target)
        {
            target.HP += 1;
        }

        public bool isABuffing()
        {
            if (currentState == State.ABuffing)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void buffAttack(BattleZane target)
        {
            target.strength += 25;
            attackBuffed = 1;
            currentState = State.Following;
        }

        public void buffAttackDuration(GameTime gameTime, BattleZane target)
        {
            if (attackBuffed == 1)
            {
                currentTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (currentTime >= 5)
                {
                    target.strength -= 25;
                    attackBuffed = 2;
                }
            }

        }

        public bool isDBuffing()
        {
            if (currentState == State.DBuffing)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void buffDefense(BattleZane target)
        {
            target.defense += 25;
            defenseBuffed = 1;
            currentState = State.Following;
        }

        public void buffDefenseDuration(GameTime gameTime, BattleZane target)
        {
            if (defenseBuffed == 1)
            {
                currentTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (currentTime >= 5)
                {
                    target.defense -= 25;
                    defenseBuffed = 2;
                }
            }

        }

        public void cooldown(GameTime gameTime, State usedState, State returnState, float interval)
        {
            currentState = usedState;

            currentTime += (float)gameTime.ElapsedGameTime.TotalMilliseconds; //Gets the total amount of time passed

            if (currentTime >= interval)
            {
                currentTime = 0; //Resets the time
                currentState = returnState; //Sets the state to Ready
                //Console.Write("Skill is ready.");

            }//ends if statement

        }//ends onCooldown()

        /*
        * Animates The Character doing a skill
        * Parameters
        * 1. Gametime
        * 2. skillName - The State's name in BattleZane
        * 3. skill - The Skill object
        * 4. leftFrame
        * 5. rightFrames
        * 6. interval - How long the animation lasts
        */
        public void skillAnimate(GameTime gameTime, State skillName, Skill skill, Vector2 leftFrames, Vector2 rightFrames, float interval)
        {

            Vector2 skillFrames; //The frames for the skill

            if (currentState == skillName) //If the current state is enabled
            {
                skill.activate(); //Activates the skill

                if (charDirection == "left") //Left animation
                {
                    skillFrames = leftFrames; //Sets frames
                    Vector2 newPosition = new Vector2(myPosition.X - 32, myPosition.Y + 4);  //Positions the skill to the left of the character
                    skill.setPosition(newPosition); //Sets the position
                }
                else //Right animation
                {
                    skillFrames = rightFrames; //Sets frames
                    Vector2 newPosition = new Vector2(myPosition.X + 32, myPosition.Y + 4); //Positions the skill to the right of the character
                    skill.setPosition(newPosition);//Sets the position
                }//ends if-else

                animateSomething(gameTime, skillFrames, interval); //Animates character 
                if (currentFrame >= skillFrames.Y)
                {
                    currentState = State.Following;

                }//ends if statement

            }//ends if statement
        }

        public void updateCameraPos(Vector2 camPos)
        {
            this.camPos = camPos;
        }

        public void Update(GameTime gameTime)
        {
            Vector2 previousPos = myPosition;
            frameSize = new Rectangle(currentFrame * spriteWidth, 0, spriteWidth, spriteHeight);
            myPosition += myVelocity; //Keeps the character moving when there is a change in velocity

            this.battleMovement();

            if (charDirection == "right")
            {
                base.animateRight(gameTime);
            }
            else
            {
                base.animateLeft(gameTime);
            }

            if (currentState == State.Following)
            {
                moveToPlayer();
            }


            foreach (Skill skill in skillList)
            {
                skill.Update(gameTime, charDirection);
            }

            skillAnimate(gameTime, State.Healing, skillHeal, new Vector2(0, 1), new Vector2(1, 2), 500);
            skillAnimate(gameTime, State.DBuffing, skillDefenseBuff, new Vector2(0, 1), new Vector2(1, 2), 500);
            skillAnimate(gameTime, State.ABuffing, skillAttackBuff, new Vector2(0, 1), new Vector2(1, 2), 500);

            this.gravity();
            base.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            base.Drawbase(spriteBatch);

            int x = 0;
            foreach (Skill skill in skillList)
            {
                skill.setIconPosition(new Vector2(camPos.X + 724 , ((camPos.Y + 192 + x * skill.iconDimension.Y))));
                skill.Draw(spriteBatch);
                x++;
            }

        }
    }
}
