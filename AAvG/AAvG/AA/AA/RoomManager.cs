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
    /// <summary>
    /// Will be used to handle rooms
    /// Note: full window use holds 24 vert and 32 horiz tiles
    /// </summary>
    class RoomManager
    {
        public Room currentRoom; //this will determine what room is displayed

        String wester1Room, wester2Room; //names of rooms
        public String strCurrentRoom, strPreviousRoom;  //this will hold the name of the current room and previous room
        public bool blnRoomChanged; //true or false, did the room just change?
                
        public ArrayList zaneList; //Holds which Zane to use;
                
        public bool hitEdge; //for collision checking

        //Create Zane
        public Zane myZane;

        Dictionary<TileType, Texture2D> texturesFromType; //accesses textures based on its type
        TileType[] tileTypes; //array of TileTypes

        public bool blnInBattle;

        /*
         * Constructor to initialize rooms
         * Game1's spriteBatch is passed in for drawing purposes
         */ 
        public RoomManager()
        {
            //names of available rooms, rooms are created in moveRoom so everything is not loaded at once
            wester1Room = "wester1Room";
            wester2Room = "wester2Room";

            strCurrentRoom = ""; //currently has no name
            blnRoomChanged = false; //the room has not changed

            zaneList = new ArrayList();

            hitEdge = false;

            //Initialize Zane
            myZane = new Zane(); //ZANE IS REBORN
            zaneList.Add(myZane);

            blnInBattle = false;

            texturesFromType = new Dictionary<TileType, Texture2D>();//instantiate the dictionary
            tileTypes = (TileType[])Enum.GetValues(typeof(TileType));  //get all the different TileTypes

            moveRooms(wester1Room); //changes the currentRoom to westerwood1            
            
        }//ends the RoomManager constructor

        /*
         * Loads Content for RoomManager and calls some other LoadContents for objects
         */
        public void LoadContent(ContentManager theCM)
        {
            foreach (Zane zane in zaneList)
                zane.LoadContent(theCM); //Loads Zane

            foreach (TileType type in tileTypes)
            {
                texturesFromType.Add(type, theCM.Load<Texture2D>("Tiles/" + type.ToString()));
            }

        }//ends LoadContent() method

        /// <summary>
        /// Updates for the rooms, this affects tiles and objects seen
        /// </summary>
        /// <param name="theGT"></param>
        public void Update(GameTime theGT)
        {
            CollisionHandler(theGT);
            currentRoom.Update(theGT);
        }

        public void CollisionHandler(GameTime theGT)
        {
            foreach (Zane zane in zaneList)
                myZane.Update(theGT); //update Zane, allows him to move and animate            

            foreach (Tile tile in currentRoom.theFGMap) //check each tile in the map
            {
                if ((tile.Type == TileType.tree || tile.Type == TileType.stump || tile.Type == TileType.rock) //if tile is tree, stump, or rock
                    && myZane.BoundingBox.Intersects(tile.BoundingBox)) //and Zane intersects tile
                {                    
                    hitEdge = true; //change boolean to true      
                }

                if (tile.Type == TileType.transfer && myZane.BoundingBox.Intersects(tile.BoundingBox)) //zane intersects transfer tile
                {
                    //move to approprate room  
                    moveRooms(wester2Room); //move to wester2Room
                }
                               
            }

            foreach (Enemy enemy in currentRoom.enemiesList)
                if (myZane.BoundingBox.Intersects(enemy.BoundingBox))
                    blnInBattle = true;
            
            
        }//ends CollisionHandler method

        /*
         * For moving rooms
         * Creates and Draws the appropriate room
         * A room will be created each time this is called. Newly created.
         */ 
        public void moveRooms(String nextRoom)
        {
            if (nextRoom == wester1Room)
            {
                //creates the wester1 room using its file layouts
                currentRoom = new Room("Content/RoomLayouts/Wester1FG.txt", "Content/RoomLayouts/Wester1BG.txt", texturesFromType);
            }
            else if (nextRoom == wester2Room)
            {
                //creates the wester2 room using its file layouts
                currentRoom = new Room("Content/RoomLayouts/Wester2FG.txt", "Content/RoomLayouts/Wester2BG.txt", texturesFromType);
            }
            else
            {
                //handle missing room
            }

            blnRoomChanged = true; //force the Update method to LoadContent for the new room
            strPreviousRoom = strCurrentRoom; //save the previous room name
            strCurrentRoom = nextRoom; //assign the room name to current room
            currentRoom.setRoomName(nextRoom); //change the room name within the Room class
        }//ends the moveRooms method

        /*
         * Returns the current room 
         */
        public Room getCurrentRoom()
        {
            return currentRoom;
        }

        /*
         * Draws player into the room
         */ 
        public void DrawPlayer(SpriteBatch spriteBatch)
        {
            foreach (Zane zane in zaneList)
                zane.DrawZane(spriteBatch); //Draws Zane
        }//ends DrawPlayer()


    }
}
