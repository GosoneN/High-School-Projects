import gpdraw.*;
/**
 * Draws a house.
 * 
 * @Gosone Nithisuwan P5
 * @9/7/12
 * @Modify : Yes
 */
public class DrawHouse
{
    // instance variables - replace the example below with your own
    private SketchPad myPaper;
    private DrawingTool myPen;
    

    /**
     * Constructor for objects of class DrawHouse
     */
    public DrawHouse()
    {
        // initialise instance variables
        myPaper = new SketchPad(500,500);
        myPen = new DrawingTool(myPaper);
    }//ends DrawHouse() method

    /**
     * Gives the directions for myPen to draw.
     * 
     * @param   None
     * @return  Void
     */
    public void draw()
    {
        // Draws the box part of the house
        myPen.up();
        myPen.move(-200,-200);
        myPen.down();
        myPen.setDirection(90);
        myPen.forward(200);
        myPen.turnRight(90);
        myPen.forward(400);
        myPen.turnRight(90);
        myPen.forward(200);
        myPen.turnRight(90);
        myPen.forward(400);
        
        // Draws the roof of the house
        myPen.up();
        myPen.move(-200,0);
        myPen.down();
        myPen.move(0,200);
        myPen.move(200,0);
        
        //Draws the door
        myPen.up();
        myPen.move(-50,-200);
        myPen.down();
        myPen.setDirection(90);
        myPen.forward(100);
        myPen.turnRight(90);
        myPen.forward(100);
        myPen.turnRight(90);
        myPen.forward(100);
        
        //Draws the windows
        myPen.up();
        myPen.move(100,-75);
        myPen.down();
        myPen.setDirection(0);
        myPen.forward(50);
        myPen.turnLeft();
        myPen.forward(50);
        myPen.turnLeft();
        myPen.forward(50);
        myPen.turnLeft();
        myPen.forward(50);
        
       myPen.up();
       myPen.move(-150,-75);
       myPen.down();
       myPen.setDirection(0);
       myPen.forward(50);
       myPen.turnLeft();
       myPen.forward(50);
       myPen.turnLeft();
       myPen.forward(50);
       myPen.turnLeft();
       myPen.forward(50);
    }//ends draw() method
}//ends DrawHouse class
