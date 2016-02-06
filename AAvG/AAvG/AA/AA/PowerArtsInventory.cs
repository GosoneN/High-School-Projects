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
    class PowerArtsInventory
    {

        ArrayList myPowerArts; //

        PowerArts paEquip1, paEquip2, paEquip3, paEquip4;
        PowerArts[] Equips;

        PowerArtsCreator myPowerArtsUpdater;

        public PowerArtsInventory(PowerArtsCreator PowerArts)
        {

            myPowerArts = new ArrayList();

            myPowerArtsUpdater = PowerArts;

            paEquip1 = (PowerArts)myPowerArtsUpdater.getTotalList()[0];
            paEquip2 = (PowerArts)myPowerArtsUpdater.getTotalList()[1];
            paEquip3 = (PowerArts)myPowerArtsUpdater.getTotalList()[2];
            paEquip4 = (PowerArts)myPowerArtsUpdater.getTotalList()[3];

            Equips = new PowerArts[4];

        }

        public void LoadContent(ContentManager contentManager)
        {
            myPowerArtsUpdater.LoadContent(contentManager);
        }

        public void setEquip1(PowerArts PowerArt)
        {
            paEquip1 = PowerArt;
            this.updateEquips();
        }

        public void setEquip2(PowerArts PowerArt)
        {
            paEquip2 = PowerArt;
            this.updateEquips();
        }

        public void setEquip3(PowerArts PowerArt)
        {
            paEquip3 = PowerArt;
            this.updateEquips();
        }

        public void setEquip4(PowerArts PowerArt)
        {
            paEquip4 = PowerArt;
            this.updateEquips();
        }

        public void updatePAInvetory()
        {
            myPowerArts = myPowerArtsUpdater.getObtainedList();
        }

        public ArrayList inventoryPowerArts()
        {
            return myPowerArts;
        }

        public void updateEquips()
        {
            if (Equips[0] != paEquip1)
                Equips[0] = paEquip1;

            if (Equips[1] != paEquip2)
                Equips[1] = paEquip2;

            if (Equips[2] != paEquip3)
                Equips[2] = paEquip3;

            if (Equips[3] != paEquip4)
                Equips[3] = paEquip4;
        }

        public void printPA()
        {
            foreach (PowerArts pa in myPowerArts)
            {
                Console.WriteLine(pa.getName());
            }
        }

        public Array getEquips()
        {
            return Equips;
        }

        public void Update(GameTime gameTime)
        {
            this.updatePAInvetory();

            this.updateEquips();
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            int x = 0;

            foreach (PowerArts pa in myPowerArts)
            {
                pa.setIconPosition(new Vector2(x * 32, 0));
                pa.drawIcon(spriteBatch);
                x++;
            }
        }

    }
}
