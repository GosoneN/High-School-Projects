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
    class PowerArts : Skill
    {


        bool obtained; //Does the character have the Power Arts
        public String artName; //Name of the Power Art

        float cooldownTime;
        int damage;

        public PowerArts( String name ,float cooldown, int damage, bool didGet)
        {

            this.artName = name;

            this.cooldownTime = cooldown;

            this.damage = damage;

            this.obtained = didGet;

        }

        public void LoadContent(ContentManager contentManager, String IconName, String SpriteName, Vector2 SpriteDimensions, Vector2 leftFrame, Vector2 rightFrame)
        {

            base.LoadContent(contentManager, IconName, SpriteName, SpriteDimensions, leftFrame, rightFrame);
        }

        public String getName()
        {
            return artName;
        }

        public void setObtained(bool didGet)
        {
            obtained = didGet;
        }

        public bool isObtained()
        {
            if (obtained == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void drawIcon(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(iconTexture, iconPosition, Color.White * myTransparency);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }


    }
}
