using System;
using System.IO;
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
    class BattleManager
    {
        //Creates an instance of BattleZane
        BattleZane myZane;
        BattleAeren myAeren;
        public Vector2 zanePosition;

        //Arraylists to hold the solid objects and texture **TO BE WORKED ON LATER
        ArrayList solidsList;
        ArrayList BGlist; //**May not be needed

        ArrayList listLead;
        ArrayList listSupport;
        ArrayList listOfEnemies;
        ArrayList allEnemies;
        BattleEnemyCreator defaultEnemies;

        PowerArts[] paEquips;

        int numEnemies;

        public Vector2 camPos;

        public BattleManager()
        {
            //Initializes variables
            myZane = new BattleZane();

            zanePosition = myZane.myPosition;
            myAeren = new BattleAeren(zanePosition);

            defaultEnemies = new BattleEnemyCreator(zanePosition);

            solidsList = new ArrayList();
            BGlist = new ArrayList();


            listOfEnemies = new ArrayList();
            listLead = new ArrayList();
            listSupport = new ArrayList();
            allEnemies = new ArrayList();

            listLead.Add(myZane);
            listSupport.Add(myAeren);

            Random myRandom = new Random();
            numEnemies = myRandom.Next(1, 4);

            paEquips = new PowerArts[4];

        }//ends BattleManager();

        /*
         * Adds in a solid object
         * TO BE WORKED ON LATER
         */
        public void loadSolids(ContentManager theCM)
        {
            Texture2D ground = theCM.Load<Texture2D>("Backgrounds/TownBattleBackgroundFloor"); //Adds in ground texture
            Texture2D back = theCM.Load<Texture2D>("Backgrounds/TownBattleBackground");
            BGlist.Add(back); //Adds it to texture list


            //solidsList.Add(new Solid(ground, new Vector2(100, 600), "ground"));
            //solidsList.Add(new Solid(ground, new Vector2(132, 600), "ground"));
            //solidsList.Add(new Solid(ground, new Vector2(164, 600), "ground"));
            //solidsList.Add(new Solid(ground, new Vector2(232, 600), "ground"));
            //solidsList.Add(new Solid(ground, new Vector2(264, 600), "ground")); 


            for (int column = 0; column < 3; column++)
            {
                //Creates a new Solid object), adds it to list of solid objects
                Vector2 position = new Vector2(column * ground.Width, 768 - ground.Height);
                solidsList.Add(new Solid(ground, position, "ground"));
            }

        }//ends loadSolids() method

        /*
        * Loads Content for RoomManager and calls some other LoadContents for objects
        */
        public void LoadContent(ContentManager theCM)
        {
            foreach (BattleZane myCharacter in listLead)
                myCharacter.LoadContent(theCM); //Calls BattleZane LoadContent()

            foreach (BattleAeren myCharacter in listSupport)
                myCharacter.LoadContent(theCM); //Calls BattleZane LoadContent()

            loadSolids(theCM); //Calls loadSolid() method

            defaultEnemies.LoadContent(theCM);

            listOfEnemies = defaultEnemies.getEnemyList();

        }//ends LoadContent() method

        public void updateEquips(PowerArts[] Equips)
        {
            paEquips = Equips;
            myZane.getEquips(paEquips);
        }

        public void pickEnemies()
        {
            Random myRandom = new Random();
            int intTemp;
            ArrayList temp = new ArrayList();

            intTemp = myRandom.Next(allEnemies.Count);
            Console.WriteLine(intTemp);
            listOfEnemies.Add(allEnemies[intTemp]);

        }

        public bool isBattleDone()
        {
            if (listOfEnemies.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*
         * 
         */
        public void Update(GameTime gameTime)
        {
            this.collisionHandler(gameTime); //Checks for collision

            zanePosition = myZane.myPosition;
            myZane.get

            defaultEnemies.updateFollowPos(zanePosition);
            myAeren.setfollowPosition(zanePosition);
            defaultEnemies.Update(gameTime);


        }//ends Update() method

        public void collisionHandler(GameTime gameTime)
        {
            foreach (BattleZane myCharacter in listLead)
                myCharacter.Update(gameTime); //Keeps Zane moving

            foreach (BattleAeren myCharacter in listSupport)
            {
                myCharacter.Update(gameTime);

                if (myCharacter.isHealing() == true)
                {
                    if (myZane.HP < myZane.maxHP)
                        myCharacter.heal(myZane);
                }

                if (myCharacter.isABuffing() == true)
                {
                    myCharacter.buffAttack(myZane);
                }

                if (myCharacter.isDBuffing() == true)
                {
                    myCharacter.buffDefense(myZane);
                }

                myCharacter.buffDefenseDuration(gameTime, myZane);
                myCharacter.buffAttackDuration(gameTime, myZane);
            }

            foreach (BattleEnemy enemy in listOfEnemies)
            {
                enemy.Update(gameTime);
            }


            //Checks to see if myZane collides with a solid object in the solidsList
            foreach (Solid solid in solidsList)
            {

                if (myZane.BoundingBox.Intersects(solid.BoundingBox) || solid.BoundingBox.Contains(myZane.BoundingBox))
                {
                    //myZane.currentState = BattleZane.State.Standing; //Changes myZane's state to standing
                    myZane.hasJumped(false); //Zane is not in the air
                    myZane.gravity(); //Makes sure Zane does not fall through the ground
                    break;

                }

            }//ends foreach


            //Checks to see if myAeren collides with a solid object in the solidsList
            foreach (Solid solid in solidsList)
            {

                if (myAeren.BoundingBox.Intersects(solid.BoundingBox) || solid.BoundingBox.Contains(myAeren.BoundingBox))
                {
                    //myZane.currentState = BattleZane.State.Standing; //Changes myZane's state to standing
                    myAeren.hasJumped(false); //Zane is not in the air
                    myAeren.gravity(); //Makes sure Zane does not fall through the ground
                    break;

                }

            }//ends foreach

            foreach (Skill attack in defaultEnemies.getAttackList())
            {
                foreach (BattleZane myCharacter in listLead)
                {
                    if (myCharacter.BoundingBox.Intersects(attack.BoundingBox) || attack.BoundingBox.Contains(myCharacter.BoundingBox))
                    {
                        //Zane taking FULL damage
                        if (myCharacter.isDodging() == false && myCharacter.isDefending() == false)
                        {
                            myCharacter.getHurt(attack.getDamage()); //Reduces Zane's HP by the enemy's damage
                            myCharacter.isHurt(gameTime); //Changes Zane's State to "Hurt"
                        }//ends if statement
                        else if (myZane.isDefending() == true)
                        {
                            myCharacter.defendDamage(attack.getDamage());
                        }
                    }
                }
            }


            foreach (BattleEnemy enemy in listOfEnemies)
            {
                foreach (Skill attacks in myZane.getSkills())
                {
                    if (enemy.BoundingBox.Intersects(attacks.BoundingBox) || attacks.BoundingBox.Contains(myZane.BoundingBox))
                    {
                        enemy.getHurt(attacks.getDamage());
                        enemy.isHurt(gameTime);
                    }
                }
            }

            foreach (BattleEnemy enemy in listOfEnemies)
            {
                foreach (Solid solid in solidsList)
                {
                    if ((enemy.BoundingBox.Intersects(solid.BoundingBox)) || solid.BoundingBox.Contains(enemy.BoundingBox))
                    {
                        enemy.hasJumped(false);
                        enemy.gravity();
                        break;
                    }
                }
            }

            foreach (BattleEnemy enemy in listOfEnemies)
            {
                if (enemy.isDead() == true)
                {
                    listOfEnemies.Remove(enemy);
                    break;
                }
            }

            foreach (BattleZane myCharacter in listLead)
            {
                if (myCharacter.isDead() == true)
                {
                    listLead.Remove(myCharacter);
                    break;
                }
            }

        }//ends collisionHandler() method

        /*
         * Draws sprites
         */
        public void Draw(SpriteBatch spriteBatch)
        {

            foreach (Texture2D texture in BGlist)
            {
                spriteBatch.Draw(texture, new Rectangle(0, 0, 1024, 768), Color.White);
            }//ends foreach

            foreach (Solid solid in solidsList)
            {
                spriteBatch.Draw(solid.solidTexture, solid.solidPosition, Color.White);
            }//ends foreach


            foreach (BattleAeren myCharacter in listSupport)
                myCharacter.Draw(spriteBatch);

            foreach (BattleZane myCharacter in listLead)
            {
                myCharacter.Draw(spriteBatch);
            }


            foreach (BattleEnemy enemy in listOfEnemies)
                enemy.Draw(spriteBatch);
            //Draws all the solids in solidsList


        }//ends Draw() method

    }//ends BattleManager class
}
