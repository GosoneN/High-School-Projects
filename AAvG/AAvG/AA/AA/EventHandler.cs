using System;
using System.IO;
using System.Collections;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;


namespace AA
{
    class EventHandler
    {
        //Create RoomManager, BattleManager, and Menus
        public RoomManager myRoomManager;
        public BattleManager myBattleManager;
        Menu myMenus;

        //Create IntroScene
        IntroScene myIntro;

        //Mouse variables
        MouseState currentMouseState, lastMouseState; //create a mouseState for current and previous
        Point mousePosition; //create a point, holds the mouse's position relative to 0,0 (top left corner)

        //Keyboard variables
        KeyboardState previousKeyState;
        KeyboardState currentKeyState;

        public bool blnInGame; //check if you are in game, if this is false, the game exits

        public State currentState; //this will hold the current state of the game

        public enum State //only one can be active at a time
        {
            MainMenu,
            Menu,
            Intro,
            Overworld,
            Map,
            Dialogue,
            Battle
        }


        //Gosan's Section
        PowerArtsCreator paCreator;
        Inventory myInventory;

        public EventHandler()
        {
            //CAN CHANGE BETWEEN MAINMENU, OVERWORLD, AND BATTLE (for now)
            currentState = State.MainMenu; //assign MainMenu as the first state, game will start at MainMenu

            myRoomManager = new RoomManager(); //initialize the RoomManager
            myBattleManager = new BattleManager(); //initialize the BattleManager
            myMenus = new Menu(); //initialize the Menus
            myIntro = new IntroScene(); //initialize the IntroScene

            blnInGame = true; //initialize boolean to true, yes you are in game

            currentMouseState = Mouse.GetState(); //initialize the mouseState
            mousePosition = new Point(currentMouseState.X, currentMouseState.Y); //holds the mouse's position relative to 0,0 (top left corner)
            
            currentKeyState = Keyboard.GetState(); //get the current state of the keyboard

            //Gosan's Section
            paCreator = new PowerArtsCreator();
            myInventory = new Inventory(paCreator);

        }

        /**
         *  Loads up the content all the things that need to be handled
         *  Rooms, Battle Rooms, Sprites, Menus, etc
         */ 
        public void LoadContent(ContentManager contentManager)
        {
            //load up the content for the intro scene
            myIntro.LoadContent(contentManager);

            //load up the textures for both Managers and the Menus
            myBattleManager.LoadContent(contentManager);
            myRoomManager.LoadContent(contentManager);
            myMenus.LoadContent(contentManager);            

            //Gosan Section
            paCreator.LoadContent(contentManager);
            myInventory.LoadContent(contentManager);
        } //ends the LoadContent method

        /**
         * Gets the camera's position for battlemanager
         */
        public void getCameraPos(Vector2 camPos)
        {
            myBattleManager.camPos = camPos;
        }

        /**
         *  The all important update method for the event handler
         *  Takes 2 parameters from the Game1 class so it can manage the events and everything
         *  needed to make them happen.
         */ 
        public void Update(GameTime gameTime, ContentManager theCM)
        {
            //be sure to check the mouse's position at all times
            lastMouseState = currentMouseState; //the previous state is now old
            currentMouseState = Mouse.GetState(); //get the new mouse state
            mousePosition = new Point(currentMouseState.X, currentMouseState.Y); //holds the mouse's position relative to 0,0 (top left corner)

            //be sure to check the keyboard state each update
            previousKeyState = currentKeyState;
            currentKeyState = Keyboard.GetState();

            if (currentState == State.MainMenu)
            {
                if (lastMouseState.LeftButton == ButtonState.Released && currentMouseState.LeftButton == ButtonState.Pressed)
                {
                    if (myMenus.RecStart.Contains(mousePosition)) //if the mouse is inside the Start Button
                    {
                        //if the mouse is clicked inside the start game button, change to overworld
                        currentState = State.Intro; //change to overworld
                    }
                    else if (myMenus.RecLoad.Contains(mousePosition))
                    {
                        //move straight to overworld, just for debugging purposes
                        currentState = State.Overworld;
                             
                        //logic for clicking on LoadGame Button
                    }
                    else if (myMenus.RecExit.Contains(mousePosition))
                    {
                        //exit the game if Exit button is clicked
                        blnInGame = false; //end the game, Game1 takes care of this
                    }
                }//ends the if for mouse click                          
                                   
            }
            else if (currentState == State.Intro)
            {
                myIntro.Update(gameTime); //update the intro scene

                if (myIntro.getIsIntroFinished()) //if the intro is finished
                    currentState = State.Overworld; //change state to overworld
            }
            else if (currentState == State.Overworld)
            {
                myRoomManager.Update(gameTime); //update Rooms

                if (myRoomManager.blnRoomChanged) //if the room changed
                {
                    //myRoomManager.currentRoom.LoadContent(theCM); //load up the new room
                    myRoomManager.blnRoomChanged = false; //set the boolean back to false
                }

                if (myRoomManager.blnInBattle == true)
                    currentState = State.Battle; //change to Battle state if you're in battle

                //M key was up, but now is down -> for Menu
                if ((!previousKeyState.IsKeyDown(Keys.M)) && (currentKeyState.IsKeyDown(Keys.M)))
                    currentState = State.Menu; //change to Menu state if M key is pressed 
        
                //N key was up, but now is down -> for Map
                if ((!previousKeyState.IsKeyDown(Keys.N)) && (currentKeyState.IsKeyDown(Keys.N)))
                    currentState = State.Map; //change to Map state if N key is pressed      

            }
            else if (currentState == State.Map)
            {
                //N key was up, but now is down
                if ((!previousKeyState.IsKeyDown(Keys.N)) && (currentKeyState.IsKeyDown(Keys.N)))
                    currentState = State.Overworld; //go back to Overworld state when N is pressed       
            }
            else if (currentState == State.Battle)
            {
                myBattleManager.Update(gameTime); //update the battle room
            }
            else if (currentState == State.Menu)
            {
                //M key was up, but now is down
                if ((!previousKeyState.IsKeyDown(Keys.M)) && (currentKeyState.IsKeyDown(Keys.M)))
                    currentState = State.Overworld; //go back to Overworld state when M is pressed                
            }


            //Gosan's Section

            paCreator.Update(gameTime);
            myInventory.Update(gameTime);

        }//ends the Update method

        public void Draw(SpriteBatch spriteBatch)
        {
            if (currentState == State.MainMenu)
            {
                myMenus.DrawMainMenu(spriteBatch); //draw the main menu
            }
            else if (currentState == State.Battle)
            {
                myBattleManager.updateEquips(myInventory.getPAEquips());
                myBattleManager.Draw(spriteBatch); //draws the battle room
            }
            else if (currentState == State.Menu)
            {
                myMenus.DrawMenu(spriteBatch); //draws the normal menu        
                myInventory.Draw(spriteBatch);
            }
            else if (currentState == State.Map)
            {
                myMenus.DrawMap(spriteBatch); //draws the map
            }
            else if (currentState == State.Intro)
            {
                myIntro.Draw(spriteBatch); //draws the intro scene
            }

        }

        /**
         * Only called when currentState is Overworld
         */ 
        public void DrawOverworld(SpriteBatch spriteBatch, RenderTarget2D target, Vector2 offset)
        {
            myRoomManager.currentRoom.DrawMap(offset ,spriteBatch);
            myRoomManager.DrawPlayer(spriteBatch);

        }
    } //ends the EventHandler class
}
