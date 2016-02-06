using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace AA
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Variables for map display
        RenderTarget2D mapRender; //the visible part of the map to be drawn
        Rectangle mapDisplay; //where to draw the visible part of the map
        Vector2 mapOffset; //the topleft corner of the viewable area
        Vector2 previousMapOffset; //hold the previous offset
        Vector2 previousZanePos; //zane's old position for use in collision

        EventHandler eventHandler;

        int windowHeight;
        int windowWidth;

        Camera2d camera;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            mapDisplay = new Rectangle(0, 0, 1024, 768); //start at top left, width: 1024, height: 768

            eventHandler = new EventHandler(); //creates EventHandler, which handles the flow of the game

            graphics.PreferredBackBufferHeight = 768; //window height
            graphics.PreferredBackBufferWidth = 1024; //window width

            

            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            //Initialize window variables
            windowHeight = graphics.PreferredBackBufferHeight;
            windowWidth = graphics.PreferredBackBufferWidth;

            //Make the mouse visible
            this.IsMouseVisible = true;
            mapOffset = new Vector2(-64, -64); //moves the initial position of Zane

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here   

            //create a render targer the exact size as the viewable map we want to be seen
            mapRender = new RenderTarget2D(GraphicsDevice, mapDisplay.Width, mapDisplay.Height);

            eventHandler.LoadContent(this.Content); //call the LoadContent of EventHandler

            camera = new Camera2d(GraphicsDevice.Viewport);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            mapRender.Dispose(); //has to be deleted manually, or else it would store up memory
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit(); //closes out the program
            if (eventHandler.blnInGame == false)
                this.Exit(); //closes out the game

            // TODO: Add your update logic here            
            eventHandler.Update(gameTime, this.Content); //update the eventHandler

            Vector2 viewHoleMovement = Vector2.Zero;    //initialize to zero         

            //get all arrowkeys' input
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                viewHoleMovement -= Vector2.UnitX;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                viewHoleMovement += Vector2.UnitX;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                viewHoleMovement -= Vector2.UnitY;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                viewHoleMovement += Vector2.UnitY;
            }

            //if (Keyboard.GetState().IsKeyDown(Keys.NumPad8))
            //{
            //    cam.Move(new Vector2(0, 1));
            //}
            //if (Keyboard.GetState().IsKeyDown(Keys.NumPad4))
            //{
            //    cam.Move(new Vector2((1), 0));
            //}
            //if (Keyboard.GetState().IsKeyDown(Keys.NumPad2))
            //{
            //    cam.Move(new Vector2(0, -1));
            //}
            //if (Keyboard.GetState().IsKeyDown(Keys.NumPad6))
            //{
            //    cam.Move(new Vector2(-1, 0));
            //}
            //if (Keyboard.GetState().IsKeyDown(Keys.PageUp))
            //{
            //    cam.Zoom += .1f;
            //}
            //if (Keyboard.GetState().IsKeyDown(Keys.PageDown))
            //{
            //    cam.Zoom -= .1f;
            //}

            if (eventHandler.myRoomManager.hitEdge == true) //hitEdge is false
            {
                mapOffset = previousMapOffset;
                eventHandler.myRoomManager.myZane.setPosition(previousZanePos);

                //change back to false
                eventHandler.myRoomManager.hitEdge = false;
            }
            else //hitEdge is true
            {
                previousZanePos = eventHandler.myRoomManager.myZane.myPosition; //save the previous position
                previousMapOffset = mapOffset; //save the mapOffset in case you have to go back to it

                //add the combined movement to the offset
                mapOffset -= viewHoleMovement * (float)gameTime.ElapsedGameTime.TotalMilliseconds / 6;

                //position equals origin coordinates minus map offset!!!
                eventHandler.myRoomManager.myZane.myPosition = new Vector2(1024 / 2, 768 / 2) - mapOffset;
            }

            if (eventHandler.currentState == EventHandler.State.Battle)
            {
                camera.Limits = new Rectangle (0,0 ,1024, 768);
                camera.Zoom = 2f;
                eventHandler.getCameraPos(camera.Position);
                camera.LookAt(new Vector2(eventHandler.myBattleManager.zanePosition.X , eventHandler.myBattleManager.zanePosition.Y - 92));
            }

            if (eventHandler.currentState == EventHandler.State.Overworld)
            {
                //cam._pos = new Vector2(eventHandler.myRoomManager.myZane.myPosition.X, eventHandler.myRoomManager.myZane.myPosition.Y);
                //cam.Zoom = 2f;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.SetRenderTarget(mapRender);
            GraphicsDevice.Clear(Color.White);

            if (eventHandler.currentState != EventHandler.State.Battle)
            {
                // My drawing code
                spriteBatch.Begin();

                if (eventHandler.currentState == EventHandler.State.Overworld)
                    eventHandler.DrawOverworld(spriteBatch, mapRender, mapOffset);
                else
                    eventHandler.Draw(spriteBatch); //calls the Draw method of the EH, which will draw the appropriate room, depending on the State

                spriteBatch.End();

                //reset the GraphicsDevice to draw onto the normal offscreen buffer
                GraphicsDevice.SetRenderTarget(null);

                spriteBatch.Begin();
                //a RenderTarget2D can be cast (and therefore used for drawing) as a Texture2D
                spriteBatch.Draw((Texture2D)mapRender, mapDisplay, Color.White);
                spriteBatch.End();
            }

            if (eventHandler.currentState == EventHandler.State.Battle || eventHandler.currentState == EventHandler.State.Overworld)
            {
                // My drawing code
                spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, null, null, null, null, camera.GetViewMatrix(Vector2.One));

                if (eventHandler.currentState == EventHandler.State.Overworld)
                    eventHandler.DrawOverworld(spriteBatch, mapRender, mapOffset);
                else
                    eventHandler.Draw(spriteBatch); //calls the Draw method of the EH, which will draw the appropriate room, depending on the State

                spriteBatch.End();

                //reset the GraphicsDevice to draw onto the normal offscreen buffer
                GraphicsDevice.SetRenderTarget(null);

                spriteBatch.Begin();
                //a RenderTarget2D can be cast (and therefore used for drawing) as a Texture2D
                spriteBatch.Draw((Texture2D)mapRender, mapDisplay, Color.White);
                spriteBatch.End();
            }

            base.Draw(gameTime);
        }
    }
}
