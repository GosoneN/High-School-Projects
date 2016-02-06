import gpdraw.*;

/**
 * Draws different types of circles from the values of the parameters.
 * 
 * @Gosone Nithisuwan
 * @P5
 * Feedback: Yes
 */
public class Circle
{
    // instance variables - replace the example below with your own
    private double dblMyX;      // the x coordinate of the Circle
    private double dblMyY;      // the y coordinate of the Circle
    private double dblMyRadius;  // the radius of the Circle

    private DrawingTool pen;
    private SketchPad paper;


    /**
     * Constructor for objects of class Circle
     */
    public Circle(double x, double y, double radius)
    {
        // initialise instance variables
        dblMyX = x;
        dblMyY = y;
        dblMyRadius = radius;
        paper = new SketchPad ( 500 , 500 );
        pen = new DrawingTool( paper );
    }//ends Circle

    /**
     * Gets the perimeter
     * 
     * @Pre: 
     * @Parameters: None
     * @Return: The Perimeter:(double) (myWidth*2 + myHeight*2) 
     * @Post: returns a calculated perimeter
     */
    public double getPerimeter()
    {
        // put your code here
        return (double) (dblMyRadius * 2 * Math.PI);
    }//ends getPerimeter method
    
    /**
     * Gets the area
     * 
     * @Pre:
     * @Parameters: None
     * @Return: The Area:(double) (myWidth * myHeight)
     * @Post: returns a calculated area
     */
    public double getArea()
    {
        // put your code here
        return (double) (Math.pow(dblMyRadius,2) * Math.PI);
    }//ends getArea method
    
    /**
     * Prints out the perimeter and area of the Circle and draws it
     * 
     * @Pre: 
     * @Parameters: None
     * @Return: Void
     * @Post: 
     */
    public void draw()
    {
        // put your code here
        System.out.println("The perimeter of the Circle is: "+getPerimeter());
        System.out.println("The area of the Circle is: "+getArea());
        pen.up();
        pen.move(dblMyX,dblMyY);
        pen.down();
        pen.drawCircle(dblMyRadius);

    }//ends draw method
}//ends Ractangle class
