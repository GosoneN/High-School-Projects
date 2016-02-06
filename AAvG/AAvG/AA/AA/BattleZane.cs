using System;
using System.Collections;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace AA
{
    class BattleZane : BattleSprites
    {

        Vector2 myVelocity; //Holds the speed of Zane
        //int intDirection; //Holds the direction
        bool blnJumped; //Holds if Zane is in the air or not
        //bool isLeader; //Checks to see if the character is the leader

        public int strength, defense, agility;

        Skill slash;
        Skill stab;
        Skill skillDodge;
        Skill skillDefend;

        ArrayList skillList;
        PowerArts[] PowerArtsList;

        PowerArts selectedPA;

        int intCounter;
        Texture2D textureSelected;

        bool canMoveLeft, canMoveRight;

        Vector2 camPos;

        //A "State", any type of action, of the sprite 
        public enum State
        {
            Standing,
            Walking, //Walking State
            Jumping, //Jumping State
            JumpLeft,
            JumpRight,
            Slash,
            Stab, //Stab state (Attack)
            Defend,
            Dodge,
            Hurt,
            PASkill
        }
        public State currentState;


        public BattleZane()
        {
            //The dimensions of the sprite
            spriteWidth = 26;
            spriteHeight = 48;

            //Sets the frames of animation
            //Only has one animation facing one way
            //downFrames = new Vector2(0, 1);
            upFrames = new Vector2(0, 1);
            leftFrames = new Vector2(8, 15);
            rightFrames = new Vector2(16, 23);


            //The position of the sprite
            myPosition = new Vector2(300, 300);

            //The speed at it travels
            mySpeed = 3;

            strength = 50;
            defense = 50;
            agility = 50;


            canMoveLeft = true;
            canMoveRight = true;

            //Sets a new frame size to make character viewable
            frameSize = new Rectangle(currentFrame * spriteWidth, 0, spriteWidth, spriteHeight);

            skillList = new ArrayList();

            //Automatically sets Zane as not in the air
            blnJumped = true;

            //Starts off in the air
            currentState = State.Jumping;

            //Initializes Starter Skills
            stab = new Skill(2f, myPosition, Vector2.Zero, (20 + strength / 25));
            slash = new Skill(2f, myPosition, Vector2.Zero, (14 + strength / 25));
            skillDodge = new Skill(4f);
            skillDefend = new Skill(4f);

            this.addSkill(stab);
            this.addSkill(slash);
            this.addSkill(skillDodge);
            this.addSkill(skillDefend);

            PowerArtsList = new PowerArts[4];

            intCounter = 0;
            selectedPA = PowerArtsList[intCounter];
            

        }//ends Constructor

        /*
         * Loads textures
         */
        public void LoadContent(ContentManager theContentManager)
        {

            base.LoadContent(theContentManager, "CharacterImages/F(M)CharA"); //Loads in F(M)Char.png

            stab.LoadContent(theContentManager, "Default Skills/Slash", "CharacterImages/Slash", new Vector2(32, 32), new Vector2(0, 2), new Vector2(3, 5));
            slash.LoadContent(theContentManager, "Default Skills/Stab", "CharacterImages/Slash", new Vector2(32, 32), new Vector2(0, 2), new Vector2(3, 5));
            skillDodge.LoadContent(theContentManager, "Default Skills/Dodge", new Vector2(32, 32));
            skillDefend.LoadContent(theContentManager, "Default Skills/Guard", new Vector2(32, 32));

            textureSelected = theContentManager.Load<Texture2D>("Power Arts/PASelect");

            //Sets the dimensions of a single sprite
            spriteWidth = 26;
            spriteHeight = 46;

        }//ends LoadContent() method

        /*
         * Controls movement in battle
         */
        public void battleMovement(GameTime gameTime)
        {
            //Initializes keyboard variables
            previousState = currentKeyState;
            currentKeyState = Keyboard.GetState();

            //Jumping
            if (currentKeyState.IsKeyDown(Keys.Up) && currentState != State.Jumping && currentState != State.Hurt)
            {
                //charDirection = "up"; //Changes the character direction to up
                //base.animateUp(gameTime);
                myPosition.Y -= 5f; //Moves position up 
                myVelocity.Y = -3; //Sets speed of falling
                blnJumped = true; //True- Zane is in the air
                currentState = State.Jumping; //Sets state to "Jumping"

            }//ends if statement

            //Moving West Animation
            if ((((currentKeyState.IsKeyDown(Keys.Left) && currentState == State.Standing) || (currentKeyState.IsKeyDown(Keys.Left) && currentState == State.Hurt)) && currentState != State.Stab && currentState != State.Slash && currentState != State.PASkill))
            {
                canMoveLeft = true;
                //base.animateLeft(gameTime);
                charDirection = "left"; //Changes the character direction to left
                //currentFrame = (int)leftFrames.X;
                myVelocity.X = (float)-mySpeed; //Moves position left
                if (currentState != State.Hurt && currentState != State.Jumping)
                    currentState = State.Walking; //Sets state to "Walking"
            }//ends if statement

            if ((currentKeyState.IsKeyDown(Keys.Left) && currentState == State.Jumping))
            {
                charDirection = "left"; //Changes the character direction to left
                myVelocity.X = (float)-mySpeed; //Moves position left
                blnJumped = true; //True- Zane is in the air
                currentState = State.JumpLeft;
            }

            //Moving East Animation
            if (((currentKeyState.IsKeyDown(Keys.Right) && currentState == State.Standing) || (currentKeyState.IsKeyDown(Keys.Right) && currentState == State.Hurt)) && currentState != State.Stab && currentState != State.Slash && currentState != State.PASkill)
            {

                canMoveRight = true;
                charDirection = "right"; //Changes the character direction to right
                //currentFrame = (int)rightFrames.X;
                //base.animateRight(gameTime);
                myVelocity.X = (float)mySpeed; //Moves position right
                if (currentState != State.Hurt && currentState != State.Jumping)
                    currentState = State.Walking; //Sets state to "Walking"

            }//ends if statement

            if ((currentKeyState.IsKeyDown(Keys.Right) && currentState == State.Jumping))
            {
                charDirection = "right"; //Changes the character direction to left
                myVelocity.X = (float)mySpeed; //Moves position left
                blnJumped = true; //True- Zane is in the air
                currentState = State.JumpRight;
            }

            //Makes sure the chracter is not moving when no keys are pressed
            /*Preconditions:
             * 1. Keys "Right" and "Left" must NOT be pressed
             * 2. Zane's State is "Walking"
             * 3. OR Zane's State is "Jumping"
             */
            if ((currentKeyState.IsKeyUp(Keys.Right) && currentKeyState.IsKeyUp(Keys.Left)) && currentState == State.Walking || currentState == State.Jumping || ((currentKeyState.IsKeyUp(Keys.Right) && currentKeyState.IsKeyUp(Keys.Left)) && currentState == State.Hurt))
            {
                myVelocity.X = 0f; //Changes the X speed to zero
            }//ends if statement

            //Makes sure the character is standing when no movement is detected
            /*Preconditions:
             * 1. Velocity on X-Axis is zero
             * 2. Velocity on Y-Axis is zero
             * 3. Zane's State can NOT be "Stab"
             */
            if (myVelocity.X == 0f && myVelocity.Y == 0f && currentState != State.Stab && currentState != State.Slash && currentState != State.Hurt && currentState != State.Dodge && currentState != State.Defend && currentState != State.PASkill)
            {
                currentState = State.Standing; //Changes the character state to "Standing"
            }//ends if statement

            //Makes sure the character is walking when movement along the X-Axis is detected
            /*Preconditions:
             * 1. Velocity on X-Axis is NOT zero
             */
            if (myVelocity.X != 0 && currentState != State.Hurt && currentState != State.Dodge && currentState != State.JumpRight && currentState != State.JumpLeft)
            {
                currentState = State.Walking; //Changes the character state to "Walking"
            }//ends if statement

            //Makes sure the character is able to use the skill stab
            /*Preconditions:
             * 1. Press Z
             * 2. Cannot hold Z
             * 3. Stab's State is in "Ready"
             * 4. Zane's State must be "Standing"
             */
            if ((currentKeyState.IsKeyDown(Keys.Z) && currentKeyState != previousState && stab.getState() == stab.getReady()) && currentState == State.Standing)
            {
                if (currentState != State.Hurt)
                    currentState = State.Stab; //Changes the character state to "Stab"
            }//ends if statement

            //Makes sure the character is able to use the skill stab
            /*Preconditions:
             * 1. Press Z
             * 2. Cannot hold Z
             * 3. Stab's State is in "Ready"
             * 4. Zane's State must be "Standing"
             */
            if ((currentKeyState.IsKeyDown(Keys.X) && currentKeyState != previousState && slash.getState() == stab.getReady()) && currentState == State.Standing)
            {
                if (currentState != State.Hurt)
                    currentState = State.Slash; //Changes the character state to "Stab"
            }//ends if statement

            if ((currentKeyState.IsKeyDown(Keys.C)) && currentKeyState != previousState && currentState != State.Hurt)
            {
                if (skillDodge.isCooldown() == false)
                    currentState = State.Dodge;
            }

            if ((currentKeyState.IsKeyDown(Keys.V)) && currentKeyState != previousState && currentState != State.Hurt)
            {
                if (skillDefend.isCooldown() == false)
                    currentState = State.Defend;
            }

            if (currentKeyState.IsKeyDown(Keys.S) && currentKeyState != previousState && currentState != State.PASkill)
            {
                if (intCounter < 3)
                {
                    intCounter++;
                }
                else
                {
                    intCounter = 0;
                }
            }

            if (currentKeyState.IsKeyDown(Keys.A) && currentKeyState != previousState && currentState != State.PASkill)
            {
                if (intCounter > 0)
                {
                    intCounter--;
                }
                else
                {
                    intCounter = 3;
                }
            }

            if (currentKeyState.IsKeyDown(Keys.D) && currentKeyState != previousState && currentState != State.PASkill)
            {
                currentState = State.PASkill;
            }

            //Sets a new frame for animation
            frameSize = new Rectangle(currentFrame * spriteWidth, 0, spriteWidth, spriteHeight);

        }//ends battleMovement() method

        /*
        * This bounding box will be used for collision checking
         */
        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle((int)myPosition.X, (int)myPosition.Y, spriteWidth, spriteHeight);
            } //this is read only, just an accessor

        }//ends BoundingBox

        public ArrayList getSkills()
        {
            return skillList;
        }

        /*
         * Provides a everlasting force downwards
         */
        public void gravity()
        {
            //If the character is in the air
            if (blnJumped == true)
            {
                currentState = State.Jumping; //Sets state to "Jumping"
                float i = 2f; //How long the character stays in air
                myVelocity.Y += .040f * i; //How fast he falls down
            }//ends if statement

            //If the character is not in the air
            if (blnJumped == false)
            {
                myVelocity.Y = 0f; //Sets falling speed to zero
                if (currentState == State.Jumping || currentState == State.JumpLeft || currentState == State.JumpRight)
                {
                    currentState = State.Standing;
                }

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

        public void isHurt(GameTime gameTime)
        {
            currentState = State.Hurt;

        }

        public void getHurt(float damage)
        {
            if (currentState != State.Hurt)
            {
                HP -= damage / (defense / 10);
                myVelocity.X = 0f; //Changes the X speed to zero
            }
        }

        public void hurtCooldown(GameTime gameTime)
        {
            currentState = State.Hurt;

            if (charDirection == "left")
            {
                currentFrame = 26;
                animateSomething(gameTime, new Vector2(26, 27), 400);
            }
            else
            {
                currentFrame = 28;
                animateSomething(gameTime, new Vector2(28, 29), 400);
            }

            currentTime += (float)gameTime.ElapsedGameTime.TotalSeconds; //Gets the total amount of time passed

            if (currentTime >= 2)
            {
                currentTime = 0; //Resets the time
                currentState = State.Standing; //Sets the state to Ready
                //Console.Write("Skill is ready.");

            }//ends if statement

        }//ends hurtCooldown()

        public bool isDodging()
        {
            if (currentState == State.Dodge)
                return true;
            else
                return false;
        }

        public void dodge(GameTime gameTime)
        {
            if (charDirection == "left")
            {
                myVelocity.X = -9;
            }
            else
            {
                myVelocity.X = 9;
            }

            dodgeCooldown(gameTime);
        }

        public void dodgeCooldown(GameTime gameTime)
        {
            currentState = State.Dodge;

            currentTime += (float)gameTime.ElapsedGameTime.TotalMilliseconds; //Gets the total amount of time passed

            if (currentTime >= 75)
            {
                currentTime = 0; //Resets the time
                currentState = State.Standing; //Sets the state to Ready
                //Console.Write("Skill is ready.");

            }//ends if statement

        }//ends dodgeCooldown()

        public bool isDefending()
        {
            if (currentState == State.Defend)
                return true;
            else
                return false;
        }

        public void defend(GameTime gameTime)
        {
            currentState = State.Defend;
            defendCooldown(gameTime);
        }

        public void defendCooldown(GameTime gameTime)
        {
            currentState = State.Defend;

            currentTime += (float)gameTime.ElapsedGameTime.TotalMilliseconds; //Gets the total amount of time passed

            if (currentTime >= 1000)
            {
                currentTime = 0; //Resets the time
                currentState = State.Standing; //Sets the state to Ready
                //Console.Write("Skill is ready.");

            }//ends if statement

        }//ends defendCooldown()

        public void defendDamage(float damage)
        {
            if (currentState == State.Defend)
            {
                HP -= damage / (defense);
                myVelocity.X = 0f; //Changes the X speed to zero
            }
        }


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
                    currentState = State.Standing;

                }//ends if statement

            }//ends if statement
        }//ends skillAnimate


        public void addSkill(Skill skillName)
        {
            skillList.Add(skillName);
        }

        public void getEquips(PowerArts[] Equips)
        {
            PowerArtsList[0] = (Equips[0]);
            PowerArtsList[1] = (Equips[1]);
            PowerArtsList[2] = (Equips[2]);
            PowerArtsList[3] = (Equips[3]);
        }

        public void updateSelection()
        {
            selectedPA = PowerArtsList[intCounter];
        }

        public void updateCameraPos( Vector2 camPos)
        {
            this.camPos = camPos;
        }

        /*
        * A method that runs repeatedly to check for action
        */
        public void Update(GameTime theGameTime)
        {
            Vector2 previousPos = myPosition;
            myPosition += myVelocity; //Keeps the character moving when there is a change in velocity

            mySpeed = 3 + (agility / 50);
            stab.setDamage(20 + strength / 25);
            slash.setDamage(14 + strength / 25);


            this.battleMovement(theGameTime); //Activates movement

            if (myPosition.X < 0)
            {
                myPosition = previousPos;
            }

            if (myPosition.X > 1024 - spriteWidth)
            {
                myPosition = previousPos;
            }


            if (currentState == State.Standing)
            {
                if (charDirection == "left")
                {
                    currentFrame = (int)leftFrames.X;
                }
                else
                {
                    currentFrame = (int)rightFrames.X;
                }
            }
            else if (currentState == State.Walking)
            {
                if (charDirection == "left")
                {
                    base.animateLeft(theGameTime);
                }
                else
                {
                    base.animateRight(theGameTime);
                }
            }
            else if (currentState == State.Jumping || currentState == State.JumpLeft || currentState == State.JumpRight)
            {
                if (charDirection == "left")
                {
                    currentFrame = 24;
                }
                else
                {
                    currentFrame = 25;
                }
            }

            if (currentState == State.Hurt)
            {
                hurtCooldown(theGameTime);
            }

            if (currentState == State.Dodge)
            {
                dodge(theGameTime);
            }

            if (currentState == State.Defend)
            {
                defend(theGameTime);
            }

            this.updateSelection();

            //stab.Update(theGameTime);
            foreach (Skill skill in skillList)
            {
                skill.Update(theGameTime, charDirection);
            }

            if (selectedPA != null)
            {
                foreach (PowerArts pa in PowerArtsList)
                {
                    pa.Update(theGameTime, charDirection);
                }
            }

            this.skillAnimate(theGameTime, State.Stab, stab, new Vector2(5, 7), new Vector2(2, 4), 200f); //For the Stab skill
            this.skillAnimate(theGameTime, State.Slash, slash, new Vector2(11, 13), new Vector2(8, 10), 400f);

            this.skillAnimate(theGameTime, State.Dodge, skillDodge, new Vector2(2, 4), new Vector2(5, 7), 200f);
            this.skillAnimate(theGameTime, State.Defend, skillDefend, new Vector2(2, 4), new Vector2(5, 7), 500f);

            this.skillAnimate(theGameTime, State.PASkill, selectedPA, new Vector2(0, 2), new Vector2(0, 2), 200f);

            Console.WriteLine(currentState);
            this.gravity(); //Activates gravity
            base.Update(theGameTime); //Gets the previous position

        }//Ends Update() method

        public void Draw(SpriteBatch spriteBatch)
        {

            base.Draw(spriteBatch);
            int x = 0;
            foreach (Skill skill in skillList)
            {
                skill.setIconPosition(new Vector2(camPos.X + 332 , (camPos.Y + 192) + x * 48));
                skill.Draw(spriteBatch);
                x++;
            }

            int i = 0;
            foreach (PowerArts pa in PowerArtsList)
            {
                pa.setIconPosition(new Vector2((camPos.X + 332) + (i * pa.iconDimension.X + 32), camPos.Y + 192));
                pa.drawIcon(spriteBatch);
                pa.Draw(spriteBatch);
                i++;
            }

            spriteBatch.Draw(textureSelected, new Rectangle((int)camPos.X + 364 + intCounter * textureSelected.Width, (int)camPos.Y + 192, textureSelected.Width, textureSelected.Height), Color.White);
            
        }
    }
}
