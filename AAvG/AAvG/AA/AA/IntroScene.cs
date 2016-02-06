using System;
using System.IO;
using System.Collections;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace AA
{
    class IntroScene
    {
        SpriteFont courierNew; //the font of the sprite
        Vector2 fontPos; //position of the text
        float fontRotation; //rotation of the text, none (0)
        Vector2 fontOrigin; //where the font starts 
        ArrayList dialogueList = new ArrayList();
        String output; //the string to be printed

        int numOfDialogues; //the number of dialogues displayed already, a counter
        float timer = 0f;

        bool isIntroFinished;

        GifAnimation.GifAnimation govtAnim; //the animated gif of the gov't scene
        Texture2D bedroom; //bg of the bedroom
        Texture2D dialogueBox; //the text box
        Texture2D zane, aeren, master, off1, off2; //sprites for the characters
        Texture2D currentSpeaker; //holds the image of the current person speaking
        Texture2D currentBG; //holds the current BG image

        /**
         * Constructor for IntroScene class
         */ 
        public IntroScene()
        {
            fontPos = new Vector2(150, 625); //set the position of the text
            fontRotation = 0;
            //fullOutput = loadText("IntroScene/IntroDialogue.txt"); //load the text file into this string
            
            loadText(); //load the lines of dialogue into arraylist 
            numOfDialogues = 0; //no dialogues have happened yet
            output = dialogueList[numOfDialogues].ToString(); //load the first line of text into the output

            

            isIntroFinished = false; //intro is NOT finished
        }

        public void loadText()
        {
            try
            {
                using (StreamReader reader = new StreamReader("Content/IntroScene/IntroDialogue.txt")) //StreamReader created for the specified file
                {
                    while ((output = reader.ReadLine()) != null) //the c# version of nextLine()
                        dialogueList.Add(output); //reads a line and stores it in the list of strings
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

        }

        /**
         * Used for timing the text displays
         */ 
        public void timerCheck(GameTime gameTime, int interval)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timer > interval)
            {
                numOfDialogues++; //increment
                timer = 0; //Resets the timer
            }//ends if statement

        }

        /**
         * Get method, checks if intro is done. 
         * If true, eventHandler will change state to State.Overworld
         */ 
        public bool getIsIntroFinished()
        {
            return isIntroFinished;
        }

        public void Update(GameTime gameTime)
        {
            govtAnim.Update(gameTime.ElapsedGameTime.Ticks); //updates animation

            //create the sequence of text using the timer for each

            if (numOfDialogues < 7)
            {
                currentSpeaker = zane; //assign Zane's image to the current speaker
                output = dialogueList[numOfDialogues].ToString(); //load the next line of text into the output  
                timerCheck(gameTime, 3); //after 3 seconds, increment numOfDialogues                    
            }
            else if(numOfDialogues < 14)
            {

            }
            else
                isIntroFinished = true;

        }

        public void LoadContent(ContentManager theCM)
        {
            courierNew = theCM.Load<SpriteFont>("Courier New");
            govtAnim = theCM.Load<GifAnimation.GifAnimation>("IntroScene/Govt-Animation");
            bedroom = theCM.Load<Texture2D>("IntroScene/Bedroom");
            dialogueBox = theCM.Load<Texture2D>("IntroScene/dialogueBox");

            zane = theCM.Load<Texture2D>("DialogueFaces/zanesmall");
            aeren = theCM.Load<Texture2D>("DialogueFaces/aerensmall");
            master = theCM.Load<Texture2D>("DialogueFaces/mastersmall");
            off1 = theCM.Load<Texture2D>("DialogueFaces/off1small");
            off2 = theCM.Load<Texture2D>("DialogueFaces/off2small");

            currentSpeaker = zane; //assign Zane's image to the current speaker
                        
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //puts the origin of the font where the position is specified
            //code to center text at position: courierNew.MeasureString(output) / 2
            fontOrigin = new Vector2(0, 0);
            
            //Adds new lines if the characters extend too much
            char temp;

            for (int i = 0; i < output.Length; i++)
            {
                temp = output[i]; //hold the current character

                if (temp == ' ' && i > 65) //if the character is a whitespace and index is over 30
                {
                    output = output.Insert(i + 1, "\n"); //immediately after the char at the index, insert a new line
                    break; //break out of the loop
                }
            } //ends the for loop

            //draws the current background
            if (currentBG == null)
                spriteBatch.Draw(govtAnim.GetTexture(), new Rectangle(0, 0, 1024, 768), Color.White); 
            else if (currentBG == bedroom)
                spriteBatch.Draw(bedroom, new Rectangle(0, 0, 1024, 768), Color.White);

            spriteBatch.Draw(dialogueBox, new Rectangle(0, 576, 1024, 192), Color.White); //draws the text box
            spriteBatch.Draw(currentSpeaker, new Rectangle(40, 600, 96, 160), Color.White); //draws the dialogue face
            spriteBatch.DrawString(courierNew, output, fontPos, Color.Black, fontRotation, fontOrigin, 1.0f, SpriteEffects.None, 0.5f); //draws the text
            
        }


    } //ends the IntroScene class
}
