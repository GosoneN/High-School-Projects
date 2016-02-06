using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace AA
{
    class Sprite
    {
        public Vector2 myPosition; //Holds the position of the Sprite
        public Vector2 myPreviousPosition; //Holds the previous position of Sprite
        public int mySpeed; //Walking speed of sprite

        protected Texture2D myTexture; //The texture of the sprite

        //The dimensions of the entire image
        public int myWidth;
        public int myHeight;

        //The dimensions of a single sprite
        private int spriteWidth;
        private int spriteHeight;


        /*
         * Loads the sprite
         */
        public void LoadContent(ContentManager theContentManager, string theAssetName)
        {
            myTexture = theContentManager.Load<Texture2D>(theAssetName);

            //Sets dimensions of sprite SHEET
            myWidth = myTexture.Width;
            myHeight = myTexture.Height;

            //Sets the dimensions of a SPRITE ONLY
            spriteWidth = 20;
            spriteHeight = 25;

        }//ends LoadContent() method

        /*
         * This bounding box will be used for collision checking
         */
        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle((int)myPosition.X, (int)myPosition.Y, spriteWidth, spriteHeight); 
            } //this is read only, just an accessor

        }

        /*
         * Draws the sprite
         */
        public void Draw(SpriteBatch theSpriteBatch)
        {
            theSpriteBatch.Draw(myTexture, myPosition, Color.White);
        }//ends Draw() method

        //Getter Method for myPosition
        public Vector2 getPosition()
        {
            return myPosition;
        }//ends getPosition() method

        //Getter Method for mySpeed
        public int getSpeed()
        {
            return mySpeed;
        }///ends getSpeed() method

        //Setter method for myPosition
        public void setPosition(Vector2 newPosition)
        {
            myPosition = newPosition;
        }//ends setPoisiton() method

        //Setter method for mySpeed
        public void setSpeed(int newSpeed)
        {
            mySpeed = newSpeed;
        }//ends setSpeed() method

        //Getter method for myPreviousPosition
        public Vector2 getPreviousPosition()
        {
            return myPreviousPosition;
        }//ends getPreviousPosition() method

        /*
         * This method makes it easier to get the previous position of a sprite
         * *Helps collision code be cleaner in RoomManager.cs
         */
        public void Update(GameTime theGameTime)
        {
           
        }//ends Update() method

    }//ends Sprite class

}//ends AA namespace
