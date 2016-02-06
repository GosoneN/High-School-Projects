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
    class BattleEnemyCreator
    {

        Vector2 followPosition; //Position of to follow

        BattleEnemy testBird;
        BattleEnemy testDragon, testDragon2;

        public BattleEnemyCreator(Vector2 characterPos)
        {

            followPosition = characterPos;

            testBird = new BattleEnemy(50, 1, 1, 1);
            testDragon = new BattleEnemy(100, 5, 1, 10);

            testDragon.setFollow();

            foreach (BattleEnemy enemy in getEnemyList())
            {
                enemy.setfollowPosition(followPosition);
            }

        }

        public void LoadContent(ContentManager contentManager)
        {
            testBird.LoadContent(contentManager, "CharacterImages/(M)Wind1", 32, 24, "CharacterImages/Slash");
            testDragon.LoadContent(contentManager, "CharacterImages/(M)Fire3v2", 72, 72, "CharacterImages/Slash");
        }

        public ArrayList getEnemyList()
        {
            ArrayList temp = new ArrayList();

            temp.Add(testBird);
            temp.Add(testDragon);

            return temp;
        }

        public ArrayList getAttackList()
        {
            ArrayList temp = new ArrayList();

            foreach (BattleEnemy enemy in getEnemyList())
            {
                temp.Add(enemy.getDefaultAttack());
            }

            return temp;
        }

        public void updateFollowPos(Vector2 followPos)
        {
            followPosition = followPos;
        }

        public void Update(GameTime gameTime)
        {
            foreach (BattleEnemy enemy in getEnemyList())
            {
                enemy.setfollowPosition(followPosition);
                //enemy.Update(gameTime);
            }


        }
    }
}
