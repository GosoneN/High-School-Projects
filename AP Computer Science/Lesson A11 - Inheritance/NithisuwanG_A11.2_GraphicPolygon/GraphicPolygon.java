
/**
 * Draws a polygon
 * 
 * @Gosone Nithisuwan
 * @P5
 */

import gpdraw.*;

public class GraphicPolygon extends RegularPolygon
{
       private DrawingTool myPen;
       private SketchPad myPaper;
       private double dblMyX;
       private double dblMyY;
       
        /**
         * Constructor for GraphicPolygon
         * 
         * Pre: dblMyX, dblMyY, myPen, myPaper
         * Param: int intSides, double dblSideLength
         * Return: None
         * Post: Initializes Variables
         */
       public GraphicPolygon ( int intSides, double dblSideLength)
       {
           super(intSides, dblSideLength);
           
           dblMyX = 0;
           dblMyY = 0;
           
           myPaper = new SketchPad (500,500);
           myPen = new DrawingTool (myPaper);
           
           super.calcr();
           draw();
           
        }//ends GraphicPolygon constructor
       
        /**
         * Constructor for GraphicPolygon
         * 
         * Pre: dblMyX, dblMyY, myPen, myPaper
         * Param: int intSides, double dblSideLength, double dblX, double dblY
         * Return: None
         * Post: Initializes Variables
         */
       public GraphicPolygon ( int intSides, double dblSideLength, double dblX, double dblY)
       {
           super(intSides, dblSideLength);
           
           dblMyX = dblX;
           dblMyY = dblY;
        }//ends GraphicPolygon constructor

         /**
         * Moves myPen to specified point
         * 
         * Pre: dblMyX, dblMyY, myPen
         * Param: double dblX, double dblY
         * Return: Void
         * Post: Moves myPen coordinates
         */
       public void moveTo(double dblX, double dblY)
       {
           dblMyX = dblX;
           dblMyY = dblY;
           
           myPen.up();
           myPen.move(dblMyX,dblMyY);
           myPen.down();
        }//ends moveTo() method
        
       
        /**
         * Draws the polygon along with inscribed circle
         * 
         * Pre:dblSideLength, intNumSides, dblMyX, myPen
         * Param: None
         * Return: Void
         * Post: Draws polygon
         */
       public void draw()
       {
           double dblTemp = dblSideLength/intNumSides ;
           
           myPen.drawCircle(getr());
           
           myPen.up();
           myPen.move(getr()+dblMyX, 0);
           myPen.setDirection(90);
           myPen.down();
           
           myPen.forward(dblSideLength/2);
           myPen.turnLeft(360/intNumSides);
           
           for (int i = 0; i<= intNumSides - 1; i++)
           {
               myPen.forward(dblSideLength);
               myPen.turnLeft(360/intNumSides);
            }//ends for loop
            
        }//ends draw() method
}//ends GraphicPolygon class
