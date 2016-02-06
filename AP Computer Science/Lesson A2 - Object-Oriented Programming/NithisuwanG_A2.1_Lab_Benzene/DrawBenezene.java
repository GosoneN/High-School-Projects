import gpdraw.*;
/**
 * Draws a circle inside a hexagon.
 * 
 * @Gosone Nithisuwan P5
 * @9/7/12
 * @Modify : Yes
 */
public class DrawBenezene
{
    // instance variables - replace the example below with your own
    private SketchPad myPaper;
    private DrawingTool myPen;

    /**
     * Constructor for objects of class DrawBenezene
     */
    public DrawBenezene()
    {
        // initialise instance variables
        myPaper = new SketchPad(500,500);
        myPen = new DrawingTool(myPaper);
    }//ends Drawbenezene method

    /**
     * Gives directions for myPen to draw benezene.
     * 
     * @param  None
     * @return void
     */
    public void draw()
    {
        //draws a cirlce
        myPen.drawCircle(100);
        
        
        //draws the hexagon
        myPen.up();
        myPen.move(0,-125);
        myPen.down();
        myPen.setDirection(90);
        myPen.turnLeft(60);
        myPen.forward(125);
        myPen.turnRight(60);
        myPen.forward(125);
        myPen.turnRight(60);
        myPen.forward(125);
        myPen.turnRight(60);
        myPen.forward(125);
        myPen.turnRight(60);
        myPen.forward(125);
        myPen.turnRight(60);
        myPen.forward(125);
    }//ends draw() method
}//ends DrawBenezene class
