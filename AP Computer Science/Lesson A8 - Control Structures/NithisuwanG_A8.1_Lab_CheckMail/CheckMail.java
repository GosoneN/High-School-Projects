
/**
 * Prompts the user for three dimensions and a weight of a package to determine if the package is to large or heavy.
 * 
 * @Gosone Nithisuwan
 * @P5
 * Feedback: Yes
 */

import java.util.*;
public class CheckMail
{
    //initialize instance variables
    private Scanner myScan;
    private double dblMyLength;
    private double dblMyWidth;
    private double dblMyHeight;
    private double dblMyWeight;
    

    /**
     * Constructor for objects of class CheckMail
     */
    public CheckMail()
    {
        // initialise instance variables
        myScan = new Scanner(System.in);
        dblMyLength = 0;
        dblMyWidth = 0;
        dblMyHeight = 0;
        dblMyWeight = 0;
    }//ends the CheckMail constructor

    /**
     * Prompts the user for input
     * 
     * @Pre: dblMyLength, dblMyWidth, dblMyHeight, dblMyWeight
     * @Parameter: None
     * @Return: Void
     * @Post: dblMyLength, dblMyWidth, dblMyHeight, dblMyWeight
     */
    public void getDimensions()
    {
        //Asks for the length
        System.out.println("Enter the length of the package: ");
        dblMyLength = myScan.nextDouble();
        
        //Asks for the width
        System.out.println("Enter the width of the package: ");
        dblMyWidth = myScan.nextDouble();
        
        //Asks for the height
        System.out.println("Enter the height of the package: ");
        dblMyHeight = myScan.nextDouble();
        
        //Asks for the weight
        System.out.println("Enter the weight of the package: ");
        dblMyWeight = myScan.nextDouble();
        
        
    }//ends getDimensions() method
    
    /**
     * Calculates the girth
     * 
     * @Pre: dblMyWidth, dblMyHeight
     * @Parameter: None
     * @Return: Void
     * @Post: girth()
     */
    public double girth()
    {
       return (dblMyWidth + dblMyHeight);
    }//ends girth() methods
    
    /**
     * Calculates if the package is too large or acceptable 
     * 
     * @Pre: dblMyLength, dblMyWeight, girth()
     * @Parameter: None
     * @Return: Void
     * @Post: 
     */
    public void calculatePackage()
    {
       double dblTemp;
       if ( dblMyLength < girth() || dblMyLength < dblMyWeight)
       {
         if ( dblMyWeight > girth() )
         {
            dblTemp = dblMyLength;
            dblMyLength = dblMyWeight;
            dblMyWeight = dblTemp;
         }//ends the if statement 
         else if ( dblMyWeight < girth() )
         {
            dblTemp = dblMyLength;
            dblMyLength = girth();
            }//ends the if else statement
       }//ends the if statement
       
       if ((dblMyLength + girth() > 100) && ( dblMyWeight > 70  ))
        {
            System.out.println("The pacakage is too large and too heavy");
        }//ends the if statement
       else if (dblMyLength + girth() > 100)
        {
            System.out.println("The pacakage is too large");
        }//ends the else if statement
       else if ( dblMyWeight > 70 )
        {
            System.out.println("The pacakage is too heavy");
        }//ends the else if statement
       else 
        System.out.println("The package is acceptable");
    }//ends calculatePackage() method
}//ends CheckMail class
