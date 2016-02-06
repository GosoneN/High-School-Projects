using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace AA
{
    /*
     * Solids will have a texture, position, and type
     * The type identifies the solid. Ex: tree, rock, entrance, exit
     */
    class Solid
    {
        //initializes variables, creates easy automatic get and set for variables
        public Texture2D solidTexture { get; set; }
        public Vector2 solidPosition { get; set; }
        public String solidType { get; set; }

        /*
         * Constructor for Solid
         */
        public Solid(Texture2D texture, Vector2 position, String type)
        {
            //assign the passed in variables to the local variables
            solidTexture = texture;
            solidPosition = position;
            solidType = type;
        }

        /*
        * Constructor for Solid
        */
        public Solid(Texture2D texture)
        {
            //assign the passed in variables to the local variables
            solidTexture = texture;
        }

        /*
         * This bounding box will be used for collision checking
         */
        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle((int)solidPosition.X, (int)solidPosition.Y,
                    solidTexture.Width, solidTexture.Height); //returns the rectangle bounding box

            } //this is read only, just an accessor used to check collision

        }


    }//ends the Solid class
}
