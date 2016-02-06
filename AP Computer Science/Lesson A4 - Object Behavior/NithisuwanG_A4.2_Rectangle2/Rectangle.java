import gpdraw.*;

/**
 * Draws different types of rectangles from the values of the parameters.
 * 
 * @Gosone Nithisuwan
 * @P5
 * Feedback: Yes
 */
public class Rectangle
{
    // instance variables - replace the example below with your own
    private double dblMyX;      // the x coordinate of the rectangle
    private double dblMyY;      // the y coordinate of the rectangle
    private double dblMyWidth;  // the width of the rectangle
    private double dblMyheight; // the height of the rectangle
    private static DrawingTool pen;
    private SketchPad paper;


    /**
     * Constructor for objects of class Rectangle
     */
    public Rectangle(double x, double y, double width, double height)
    {
        // initialise instance variables
        dblMyX = x;
        dblMyY = y;
        dblMyWidth = width;
        dblMyheight = height;
        paper = new SketchPad ( 500 , 500 );
        pen = new DrawingTool( paper );
    }//ends Rectangle

    /**
     * Gets the perimeter
     * 
     * @Pre: 
     * @Parameters: None
     * @Return: The Perimeter:(double) (dblMyWidth*2 + dblMyheight*2) 
     * @Post: returns a calculated perimeter
     */
    public double getPerimeter()
    {
        // put your code here
        return (double) (dblMyWidth*2 + dblMyheight*2);
    }//ends getPerimeter method
    
    /**
     * Gets the area
     * 
     * @Pre:
     * @Parameters: None
     * @Return: The Area:(double) (dblMyWidth * dblMyheight)
     * @Post: returns a calculated area
     */
    public double getArea()
    {
        // put your code here
        return (double) (dblMyWidth * dblMyheight);
    }//ends getArea method
    
    public static void getQuadratic (double a, double b, double c)
    {
        System.out.println( -b + Math.sqrt( Math.pow( b , 2) - 4*a*c)/(2*a));
        System.out.println( -b - Math.sqrt( Math.pow( b , 2) - 4*a*c)/(2*a));
    }


    
    /**
     * Prints out the perimeter and area of the rectangle and draws it
     * 
     * @Pre: 
     * @Parameters: None
     * @Return: Void
     * @Post: 
     */
    public void draw()
    {
        // put your code here
        System.out.println("The perimeter of the rectangle is: "+getPerimeter());
        System.out.println("The area of the rectangle is: "+getArea());
        pen.up();
        pen.move(dblMyX,dblMyY);
        pen.down();
        pen.drawRect(dblMyWidth, dblMyheight);

    }//ends draw method
}//ends Ractangle class
