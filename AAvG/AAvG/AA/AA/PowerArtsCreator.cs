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
    class PowerArtsCreator
    {
        PowerArts Fire1;
        PowerArts Earth1;
        PowerArts Earth2;
        PowerArts Wind1;

        ArrayList totalPowerArtsList;
        ArrayList obtainedPowerArtsList;

        public PowerArtsCreator()
        {

            Fire1 = new PowerArts("Fire Slash", 1f, 5, true);
            Earth1 = new PowerArts("Fury", 1f, 5, true);
            Earth2 = new PowerArts("Critical Clash", 1f, 5, false);
            Wind1 = new PowerArts("Wind Fury", 1f, 5, false);

            totalPowerArtsList = new ArrayList();
            totalPowerArtsList.Add(Fire1);
            totalPowerArtsList.Add(Earth1);
            totalPowerArtsList.Add(Earth2);
            totalPowerArtsList.Add(Wind1);

            obtainedPowerArtsList = new ArrayList();
        }

        public void LoadContent(ContentManager contentManager)
        {
            Fire1.LoadContent(contentManager, "Power Arts/Fire1", "CharacterImages/Slash", new Vector2(32, 32), new Vector2(0, 2), new Vector2(3, 5));
            Earth1.LoadContent(contentManager, "Power Arts/Earth1", "Power Arts/Earth1", new Vector2(32, 32), new Vector2(0, 3), new Vector2(0, 3));
            Earth2.LoadContent(contentManager, "Power Arts/Earth2", "Power Arts/Earth2", new Vector2(32, 32), new Vector2(0, 3), new Vector2(0, 3));
            Wind1.LoadContent(contentManager, "Power Arts/Wind1", "Power Arts/Wind1", new Vector2(32, 32), new Vector2(0, 3), new Vector2(0, 3));

        }

        public void updateObtained()
        {
            foreach (PowerArts pa in totalPowerArtsList)
            {
                if (pa.isObtained() == true)
                {
                    if (obtainedPowerArtsList.Contains(pa) == false)
                    {
                        obtainedPowerArtsList.Add(pa);
                    }
                }//ends if statement
            }
        }

        public ArrayList getTotalList()
        {
            return totalPowerArtsList;
        }

        public ArrayList getObtainedList()
        {
            return obtainedPowerArtsList;
        }

        public void Update(GameTime gameTime)
        {
            this.updateObtained();
        }

    }
}
