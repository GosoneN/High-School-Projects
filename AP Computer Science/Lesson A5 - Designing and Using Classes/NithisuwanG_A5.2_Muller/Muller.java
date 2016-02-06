
import gpdraw.*;
/**
 * Creates an optical illusion with lines
 * 
 * @Gosone Nithisuwan 
 * @P 5
 * Modify: Yes
 */
public class Muller
{
    // instance variables - replace the example below with your own
    DrawingTool myPen1; //for the Muller Illusion
    SketchPad myPaper1; //for the Muller Illusion
    DrawingTool myPen2; //for the Ponzo Illusion
    SketchPad myPaper2; //for the Ponzo Illusion

    /**
     * Constructor for objects of class Muller
     */
    public Muller()
    {
        // initialise instance variables
        myPaper1 = new SketchPad ( 500 , 500 ); //for the Muller Illusion
        myPen1 = new DrawingTool ( myPaper1 ); //for the Muller Illusion
        myPaper2 = new SketchPad ( 500, 500); //for the Ponzo Illusion
        myPen2 = new DrawingTool ( myPaper2); //for the Ponzo Illusion
    }//ends Muller constructor

    /**
     * Draws the Muller illusion
     * 
     * @param  None
     * @return Void 
     */
    public void drawMuller()
    {
        // Draws the top line
        myPen1.up();
        myPen1.move( -25 , 100 );
        myPen1.down();
        myPen1.move( 25 , 100);
        myPen1.move( 5 , 105);
        myPen1.up();
        myPen1.move( 25 , 100);
        myPen1.down();
        myPen1.move( 5 , 95 );
        myPen1.up();
        myPen1.move( -25 , 100 );
        myPen1.down();
        myPen1.move( -5 , 105);
        myPen1.up();
        myPen1.move( -25 , 100);
        myPen1.down();
        myPen1.move( -5 , 95 );
        
        // Draws the bottom line
        myPen1.up();
        myPen1.move( -25 , 50 );
        myPen1.down();
        myPen1.move( 25 , 50);
        myPen1.move( 45 , 55);
        myPen1.up();
        myPen1.move( 25 , 50);
        myPen1.down();
        myPen1.move( 45 , 45 );
        myPen1.up();
        myPen1.move( -25 , 50 );
        myPen1.down();
        myPen1.move( -45 , 55);
        myPen1.up();
        myPen1.move( -25 , 50);
        myPen1.down();
        myPen1.move( -45 , 45 );  
    }//ends drawMuller method
    
    /**
    * Draws the Ponzo illusion
    * 
    * @param  None
    * @return Void 
    */
    public void drawPonzo()
    {
        //draws left line
        myPen2.down();
        myPen2.setWidth(5);
        myPen2.up();
        myPen2.move( -100 , -100 );
        myPen2.down();
        myPen2.move( -100 , 100 );
        
        //draws right line
        myPen2.up();
        myPen2.move ( 100, -100 );
        myPen2.down();
        myPen2.move( 100 , 100 );
        myPen2.up();
        
        //draws the lines of intersecting
        int intY = -500;
        
        myPen2.setWidth(1);
            for (int i = 1; i <45 ; i++)
        {
            myPen2.move(-500, 0);
            myPen2.down();
            myPen2.move(500, intY );
            myPen2.up();
            intY += 25;
        }

        
        
    }//ends the drawPonzo method
}//ends Muller class
