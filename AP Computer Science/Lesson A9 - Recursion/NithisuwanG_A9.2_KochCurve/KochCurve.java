
/**
 * Draws a KochCurve
 * 
 * @Gosone Nithisuwan
 * @P5
 */

import java.util.*;
import gpdraw.*;

public class KochCurve
{
    private DrawingTool myPen; //Pen tool
    private SketchPad myPaper; //Paper tool
    private int intMyLevel; //the number of kochcurves to include
    private double dblMyLength; //the length of the kochcurve
    Scanner myScan;


    /**
     * Constructor for objects of class KochCurve
     */
    public KochCurve()
    {
        // initialise instance variables
        myPaper = new SketchPad(500,500);
        myPen = new DrawingTool(myPaper);
        intMyLevel = 0;
        dblMyLength = 0;
        myScan = new Scanner(System.in);
    }//ends KochCurve method
    
    
    /**
     * Asks the user for the length and the levels
     * 
     * Pre: dblMyLength, intMyLevel
     * Param: None
     * Return: Void
     * Post: dblMyLength, intMyLevel
     */
    public void askMeasurements()
    {
        //Has the user input a length and a level
        System.out.print("Enter in a length: ");
        dblMyLength = myScan.nextDouble();
        System.out.print("Enter in the levels of Koch Curves: ");
        intMyLevel = myScan.nextInt();
        
        myPen.setDirection(0);
        this.draw(dblMyLength, intMyLevel);
    }//ends askMeasurements method
    
    /**
     * Draws the KochCurve
     * 
     * Pre: dblMyLength, intMyLevel
     * Param: dblLength, intLevel
     * Return: Void
     * Post: None
     */
    public void draw(double dblLength, double intLevel)
    {
        //sets the pen at coordinates (0,0)
       
        intLevel = intLevel;
        if ( intLevel < 1 )
        {
            myPen.forward(dblLength);
        }
        else
        {
            draw(dblLength/3, intLevel-1);
            myPen.turnLeft(60);
            draw(dblLength/3, intLevel-1);
            myPen.turnRight(120);
            draw(dblLength/3, intLevel-1);
            myPen.turnLeft(60);
            draw(dblLength/3, intLevel-1);
        }
    }//ends draw method
}//ends KochCurve class
