
/**
 * Gets the average of numbers inside a file
 * 
 * @Gosone Nithisuwan
 * @version (a version number or a date)
 */

import java.util.*;
import java.io.*;

public class Average
{
    
    Scanner myScan;
    File myFile;
    double dblMyTotal;
    
    /**
     * Constructor
     */
    public Average()
    {
        myFile = new File("numbers.txt");
        try
        {
            myScan = new Scanner(myFile);
        }catch (IOException e)
        {
            System.out.println("No file found");
        }
        
        System.out.println(getAverage());
    }//ends Average() Constructor
    
    /**
     * Gets the average of the numbers.txt file
     * 
     * @Pre: numbers.txt file
     * @Parameter: None
     * @Return: Double
     * @Post: Returns a number
     */
    public double getAverage()
    {
        int intCount = 0;
        
        while(myScan.hasNext())
        {
            dblMyTotal += myScan.nextInt();
            intCount ++;
        }//ends while loop
        
        System.out.println("The total is: " + dblMyTotal);
        System.out.println("The total amount of numbers is: " + intCount);
        
        double dblAverage = dblMyTotal / intCount;
        
        return dblAverage;
    }//ends getAverage() method
    
}//ends Average class
