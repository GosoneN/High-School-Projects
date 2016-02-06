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
    /// Creates a room
    /// Loads and Draws all tiles, solid, etc for this location
    /// </summary>
    class Room
    {
        public ArrayList arrObjects { get; set; }
        public ArrayList enemiesList; //Holds all the enemies in a room

        String roomName; //the name of the room
        String roomFGLayout; //series of numbers for foreground drawing
        String roomBGLayout; //series of numbers for background drawing

        //Size of the room in tiles
        public int roomWidth, roomHeight;

        //positions of the transfer objects
        public Vector2 transferTop { get; set; }
        public Vector2 transferBottom { get; set; }

        Dictionary<TileType, Texture2D> dictionaryTextures; //accesses textures based on its type
        TileType[] tileTypes; //array of TileTypes
        public Tile[,] theBGMap; //the entire background map
        public Tile[,] theFGMap; //the entire foreground map

        /*
         * A constructor for rooms that will have tiles
         * This constructor will be used for overworld rooms
         */
        public Room(String foregroundLayout, String backgroundLayout, Dictionary<TileType, Texture2D> texturesFromType)
        {
            //gets layouts from files, turns them into Strings that will work for the code
            roomFGLayout = this.ParseFiles(foregroundLayout);
            roomBGLayout = this.ParseFiles(backgroundLayout);

            enemiesList = new ArrayList();

            //initialize the positions of the transfers to default (0,0)
            transferTop = Vector2.Zero;
            transferBottom = Vector2.Zero;

            //set the width and height of the rooms (in tiles)
            //will vary by room, adding if statements later
            roomWidth = 128;
            roomHeight = 72;

            dictionaryTextures = texturesFromType;  //get the dictionary ready
            tileTypes = (TileType[])Enum.GetValues(typeof(TileType));  //get all the different TileTypes
            theBGMap = CreateNewMap(32, roomBGLayout); //create map, tiles ares 32x32, pass in layout of BG
            theFGMap = CreateNewMap(32, roomFGLayout); //create map, tiles are 32x32, pass in layout of FG
        }

        /*
         * Takes file reference, reads from file, converts characters from file to useable string
         * Returns String with readable layout inside
         */ 
        public String ParseFiles(String fileReference)
        {
            String strTextTemp = null;
            String strTemp = null;
            int intTemp; //temp var only used in this constructor            

            try
            {
                using (StreamReader sr = new StreamReader(fileReference)) //StreamReader created for the specified file
                {
                    strTextTemp = sr.ReadToEnd(); //reads the whole file and puts it in the string
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            //This takes the values in the string and converts from ASCII to int, putting them back in the string as int
            for (int i = 0; i < strTextTemp.Length; i++)
            {
                if (!int.TryParse(strTextTemp[i].ToString(), out intTemp))
                {
                    Console.WriteLine("The value is not an int. Check Room class."); //just an error message
                }
                else
                {
                    intTemp = int.Parse(strTextTemp[i].ToString()); //get the current char at the index of the string
                    strTemp = strTemp + intTemp; //add the integer to new string
                }
            }//end for loop

            return strTemp; //return the String, expect to catch it on other end (the place that called this method)

        } //ends the ParseFiles method

        //Create a map with random tiles and bordertiles around the edges
        public Tile[,] CreateNewMap(int tileSize, String layout)
        {
            Tile[,] map = new Tile[roomWidth, roomHeight];
            TileType tileType;
            int i = 0,tileRef = 0;

            for (int y = 0; y < roomHeight; y++)
            {
                for (int x = 0; x < roomWidth; x++)
                {

                    tileRef = int.Parse(layout[i].ToString()); //determine tile reference from the string                        
                    tileType = tileTypes[tileRef];

                    //get the appropraite tile and position it
                    map[x, y] = new Tile(tileType, Vector2.Zero);
                    map[x, y].Position = new Vector2(x * tileSize, y * tileSize);

                    if (tileType == TileType.enemy) //if it is an enemy
                        enemiesList.Add(new Enemy(new Vector2(x * tileSize, y * tileSize))); //create new enemies and pass in their position

                    i++; //increment index

                }
            }
            return map;
        }

        /*
         * Takes a passed in name and sets the room name
         */ 
        public void setRoomName(String name)
        {
            roomName = name; //change the room name
        }

        /*
         * Loads Content for Rooms
         */
        public void LoadContent(ContentManager theCM)
        {

        }//ends LoadContent() method 

        public void Update(GameTime gameTime)
        {
            foreach (Enemy enemy in enemiesList)
                enemy.moveUpdater(gameTime);
        }

        /*
         * Draws all the objects in the ArrayList 
         */ 
        public void DrawObjects(SpriteBatch spriteBatch)
        {
            foreach (Solid obj in arrObjects)
                spriteBatch.Draw(obj.solidTexture, obj.solidPosition, Color.White); 

        }//end the drawObjects method       

        //Draw some or all of a maps tiles at a specific offset
        public void DrawMap(Vector2 drawOffset, SpriteBatch spriteBatch)
        {
            Tile tile = null;

            int topVisibleRow = 0;
            int leftVisibleColumn = 0;
            int visibleColumns = roomWidth;
            int visibleRows = roomHeight;       

            //** FIND FIRST AND LAST ROW/COLUMN TO SHOW ON SCREEN
            //add the number of visible rows to find the bottom row we need to show
            int bottomVisibleRow = topVisibleRow + visibleRows;
            //add the number of visible rows to find the bottom row we need to show
            int rightVisibleColumn = leftVisibleColumn + visibleColumns;

            //for each tile we would want to show from left to right...
            for (int x = leftVisibleColumn; x <= rightVisibleColumn; x++)
            {
                //and for top to bottom...
                for (int y = topVisibleRow; y <= bottomVisibleRow; y++)
                {
                    //figure out if the tile exists (is inside the map)
                    if (x >= 0 && x < roomWidth && y >= 0 && y < roomHeight)
                    {
                        //if it is, then draw it
                        tile = theBGMap[x, y];
                        //draw the right tiletype
                        spriteBatch.Draw(dictionaryTextures[tile.Type], tile.Position + drawOffset, Color.White);

                        tile = theFGMap[x, y]; //get the current tile for the foreground

                        if(tile.Type != TileType.grass && tile.Type != TileType.enemy) //if the tile is not grass or enemy (0 and 9 in the text file)
                            spriteBatch.Draw(dictionaryTextures[tile.Type], tile.Position + drawOffset, Color.White); //draw object  

                        foreach (Enemy enemy in enemiesList)
                        {
                            //draw moving enemy with its animation
                            spriteBatch.Draw(dictionaryTextures[TileType.enemy], enemy.getPosition() + drawOffset, enemy.frameSize, Color.White);                            
                        }

                    }
                }
            }
         
        }//ends the DrawMap method
                
    }//end Room class
}
