using System;
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
    class Inventory
    {
        ArrayList myItems;

        PowerArtsInventory myPowerArtsInventory;

        public Inventory(PowerArtsCreator PowerArts)
        {

            myItems = new ArrayList();

            myPowerArtsInventory = new PowerArtsInventory(PowerArts);

        }//ends Inventory constructor

        public PowerArts[] getPAEquips()
        {
            return (PowerArts[])myPowerArtsInventory.getEquips();
        }

        public void LoadContent(ContentManager contentManager)
        {
            myPowerArtsInventory.LoadContent(contentManager);
        }

        public void Update(GameTime gameTime)
        {
            myPowerArtsInventory.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            myPowerArtsInventory.Draw(spriteBatch);
        }

    }
}
