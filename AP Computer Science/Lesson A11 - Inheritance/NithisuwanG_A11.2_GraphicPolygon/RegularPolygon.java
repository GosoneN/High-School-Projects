import java.util.*;

/**
 * Finds the area, perimeter, and the angle of a polygon
 * 
 * @Gosone Nithisuwan
 * @P5
 * @Feedback: Yes
 */
public class RegularPolygon
{


   int intNumSides;        // # of sides
   double dblSideLength;   // length of side
   double dblR;            // radius of circumscribed circle
   double dblr;            // radius of inscribed circle
    
   // constructors
   /**
     * Constructor for objects of class RegularPolygon
     * 
     * @Pre: intNumSides, dblSideLength, dblR, dblr
     * @Parameters: None
     * @Return: None
     * @Post: intNumSides, dblSideLength, dblR, dblr
     */
   public RegularPolygon()
   {
       intNumSides = 3;
       dblSideLength = 5;
       dblR = 0;
       dblr = 0;
   }//ends RegularPolygon constructor
   
   /**
     * Constructor for objects of class RegularPolygon
     * 
     * @Pre: intNumSides, dblSideLength, dblR, dblr
     * @Parameters: None
     * @Return: None
     * @Post: intNumSides, dblSideLength, dblR, dblr
     */
   public RegularPolygon(int numSides, double sideLength)
   {
       intNumSides = numSides;
       dblSideLength = sideLength;
       dblR = 0;
       dblr = 0;
   }//ends RegularPolygon constructor

   /**
     * Calculates r
     * 
     * @Pre: intNumSides, dblSideLength,, dblr
     * @Parameters: None
     * @Return: Void
     * @Post: dblr
     */
   public void calcr()
   {
      dblr =  ( .5)* dblSideLength * 1 / ( Math.tan( Math.PI / intNumSides ));
   }//ends calcr method
   
   /**
     * Calculates R
     * 
     * @Pre: intNumSides, dblSideLength,, dblR
     * @Parameters: None
     * @Return: Void
     * @Post: dblR
     */
   public void calcR()
   {
       dblR = .5 * dblSideLength * 1 / ( Math.sin ( Math.PI / intNumSides ));
   }//ends calcR method
   
   // public methods
   /**
     * Calculates the vertex angle
     * 
     * @Pre: intNumSides
     * @Parameters: None
     * @Return: (double)(intNumSides - 2)/ intNumSides * 180;
     * @Post: vertexAngle()
     */
   public double vertexAngle()
   {
        return (double)(intNumSides - 2)/ intNumSides * 180;
   }//ends vertexAngle method
   
   /**
     * Calculates the perimeter
     * 
     * @Pre: intNumSides, dblSideLength
     * @Parameters: None
     * @Return: dblSideLength*intNumSides;
     * @Post: perimeter()
     */
   public double perimeter()
   {
       return dblSideLength*intNumSides;
   }//ends perimeter method
   
   /**
     * Calculates the area
     * 
     * @Pre: intNumSides, dblR
     * @Parameters: None
     * @Return: .5* intNumSides * Math.pow(dblR, 2) * Math.sin((2* Math.PI)/ intNumSides);
     * @Post: area()
     */
   public double area()
   {
       return .5* intNumSides * Math.pow(dblR, 2) * Math.sin((2* Math.PI)/ intNumSides);
   }//ends area method
   
   /**
     * getter method for intNumSides
     * 
     * @Pre: intNumSides
     * @Parameters: None
     * @Return: intNumSides;
     * @Post: intNumSides
     */
   public double getNumside()
   {
       return intNumSides;
   }//ends getNumSide method
   
   /**
     * getter method for dblSideLength
     * 
     * @Pre: dblSideLength
     * @Parameters: None
     * @Return: dblSideLength;
     * @Post: dblSideLength
     */
   public double getSideLength()
   {
       return dblSideLength;
   }//ends getSideLength method
   
   /**
     * getter method for dblR
     * 
     * @Pre: dblR
     * @Parameters: None
     * @Return: dblR;
     * @Post: dblR
     */
   public double getR()
   {
       return dblR;
   }//ends getR method
   
   /**
     * getter method for dblr
     * 
     * @Pre: dblr
     * @Parameters: None
     * @Return: dblr;
     * @Post: dblr
     */
   public double getr()
   {
       return dblr;
   }//ends getr method
   
   /**
     * Prints out the results
     * 
     * @Pre: intNumSides, dblSideLength, vertexAngle(), getr(), getR(), perimeter(), area()
     * @Parameters: None
     * @Return: void
     * @Post: calcr(), calcR()
     */
   public void print()
   {
       this.calcr();
       this.calcR();
       
       System.out.println("Number of sides = " + intNumSides );
       System.out.println("Length of sides = " + dblSideLength );
       System.out.println("Vertex Angle = " + vertexAngle());
       System.out.println("r = " + getr() );
       System.out.println("R = " + getR() );
       System.out.println("Perimeter = " + perimeter() );
       System.out.println("Area = " + area() + "\n");
    }//ends draw method
}//ends RegularPolygon class
