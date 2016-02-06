using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace AA
{
    class Tile
    {
        public TileType Type { get; set; }
        public Vector2 Position { get; set; }

        public Tile(TileType type, Vector2 position)
        {
            Type = type;
            Position = position;
        }

       /*
        * This bounding box will be used for collision checking
        */
        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, 32, 32); //returns the rectangle bounding box

            } //this is read only, just an accessor used to check collision

        }

    }
}
