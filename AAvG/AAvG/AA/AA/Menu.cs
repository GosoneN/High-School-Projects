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
    class Menu
    {
        Texture2D mainMenuBG;
        Texture2D loadGame, startGame, exit; //textures for the three main menu buttons
        Texture2D items, skills, save, settings; //textures for the 4 OW menu buttons
        
        Texture2D menuBG; //the bg for the ingame normal menu
        Texture2D mapBG; //the map image
             
        Rectangle RecMenu; //rectangle for the normal menu

        //three rectangles, one for each button
        public Rectangle RecStart {get; set;} 
        public Rectangle RecLoad {get; set;} 
        public Rectangle RecExit{get; set;}

        public Rectangle RecItems { get; set; }
        public Rectangle RecSkills { get; set; }
        public Rectangle RecSave { get; set; }
        public Rectangle RecSettings { get; set; } 

        /**
         * Constructor for Menus
         */ 
        public Menu()
        {
            RecMenu = new Rectangle(0, 0, 1024, 768); //x:112, y:84, width:800, height:600

            RecStart = new Rectangle(248, 575, 128, 64); //x:448, y:400, width:128, height:64
            RecLoad = new Rectangle(448, 575, 128, 64); //x:448, y:500, width:128, height:64
            RecExit = new Rectangle(648, 575, 128, 64); //x:448, y:600, width:128, height:64

            RecItems = new Rectangle(720, 200, 296, 75); //x:448, y:600, width:128, height:64
            RecSkills = new Rectangle(720, 300, 296, 75); //x:448, y:600, width:128, height:64
            RecSave = new Rectangle(720, 400, 296, 75); //x:448, y:600, width:128, height:64
            RecSettings = new Rectangle(720, 500, 296, 75); //x:448, y:600, width:128, height:64

        }//ends the constructor for Menu

        public void LoadContent(ContentManager theCM)
        {
            mainMenuBG = theCM.Load<Texture2D>("MainMenu/AA Logo"); //loads the BG of the main menu
            menuBG = theCM.Load<Texture2D>("Menu/OWmenu"); //loads the BG of the normal menu
            mapBG = theCM.Load<Texture2D>("Backgrounds/AA Map"); //loads the map image

            //loads up the three images for the main menu buttons
            loadGame = theCM.Load<Texture2D>("MainMenu/Load2"); 
            startGame = theCM.Load<Texture2D>("MainMenu/Start2"); 
            exit = theCM.Load<Texture2D>("MainMenu/Exit2"); 

            //loads up the four button images for the overworld menu
            items = theCM.Load<Texture2D>("Menu/items");
            skills = theCM.Load<Texture2D>("Menu/skills");
            save = theCM.Load<Texture2D>("Menu/save");
            settings = theCM.Load<Texture2D>("Menu/settings"); 

        } //ends the LoadContent method

        /**
         *  To be used for the normal in-game menu
         */ 
        public void DrawMenu(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(menuBG, RecMenu, Color.White); //texture, draw in rectangle , no shading
            spriteBatch.Draw(items, RecItems, Color.White); 
            spriteBatch.Draw(skills, RecSkills, Color.White); 
            spriteBatch.Draw(save, RecSave, Color.White); 
            spriteBatch.Draw(settings, RecSettings, Color.White); 

        } //ends the Draw method

        /**
         *  Draws the main menu at the start of the game
         *  Draws when State is MainMenu
         */ 
        public void DrawMainMenu(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(mainMenuBG, Vector2.Zero, Color.White); //texture, position at 0,0 , no shading
            spriteBatch.Draw(startGame, RecStart, Color.White); //texture, draw in rectangle , no shading
            spriteBatch.Draw(loadGame, RecLoad, Color.White); //texture, draw in rectangle , no shading
            spriteBatch.Draw(exit, RecExit, Color.White); //texture, draw in rectangle , no shading

        } //ends the Draw method

        /**
         *  Just draws the map, thats it
         */
        public void DrawMap(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(mapBG, new Rectangle(0,0,1024,768), Color.White); //texture, full window rectangle, no shading

        } //ends the Draw method

    }
}
