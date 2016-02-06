
/**
 * Write a description of class IRS here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
import java.util.*;
public class IRS
{
    // instance variables - replace the example below with your own
    private int intMyStatus;
    private int intMyIncome;
    Scanner myScan;

    /**
     * Constructor for objects of class IRS
     */
    public IRS()
    {
        // initialise instance variables
        intMyStatus = 0;
        intMyIncome = 0;
        myScan = new Scanner(System.in);
    }//ends IRS contructor

    /**
     * An example of a method - replace this comment with your own
     * 
     * @param  y   a sample parameter for a method
     * @return     the sum of x and y 
     */
    public void getStatus()
    {
        // Gets the user's marital status
        System.out.println("Are you single or married");
        System.out.print("Enter 1 for single or 2 for married: ");
        intMyStatus = myScan.nextInt();
        
        //Gets the user's income
        System.out.print("Enter your income: ");
        intMyIncome = myScan.nextInt();
        
        //If the user is single, then calls singleTax method
        //If the user is married, then calls marriageTax method
        if (intMyStatus == 1)  
        {
            singleTax(intMyIncome);
        }
        else
        {
            marriageTax(intMyIncome);
        }
    }//ends getStatus method
    
    /**
     * An example of a method - replace this comment with your own
     * 
     * @param  y   a sample parameter for a method
     * @return     the sum of x and y 
     */
    private void singleTax(int intIncome)
    {
        //calculates the taxes of a single user
        if (intIncome < 27050) 
        {
            double intCalc;
            intCalc =  (.015 * (intIncome-0));
            System.out.println("You taxable income is: $" + intCalc);
        }
        else if (( intIncome <= 65550) && (intIncome >= 27050))
        {
            double intCalc;
            intCalc = 4057.50 + (.275 * (intIncome-27050));
            System.out.println("You taxable income is: $" + intCalc);
        }
        else if (( intIncome <= 136750) && (intIncome >= 65550))
        {
            double intCalc;
            intCalc = 14645 + (.305 * (intIncome-65550));
            System.out.println("You taxable income is: $" + intCalc);
        }
        else if (( intIncome <= 297350) && (intIncome >= 136750))
        {
            double intCalc;
            intCalc = 36361 + (.355 * (intIncome-136750));
            System.out.println("You taxable income is: $" + intCalc);
        }
        else if ( intIncome >= 297350) 
        {
            double intCalc;
            intCalc = 93374 + (.391 * (intIncome-297350));
            System.out.println("You taxable income is: $" + intCalc);
        }
    }//ends singleTax method
    
    /**
     * An example of a method - replace this comment with your own
     * 
     * @param  y   a sample parameter for a method
     * @return     the sum of x and y 
     */
    private void marriageTax(int intIncome)
    {
         //calculates the taxes of a married user
        if (intIncome < 45200) 
        {
            double intCalc;
            intCalc =   (.015 * (intIncome-0));
            System.out.println("You taxable income is: $" + intCalc);
        }
        else if (( intIncome <= 109250) && (intIncome >= 45200))
        {
            double intCalc;
            intCalc = 6780 + (.275 * (intIncome-45200));
            System.out.println("You taxable income is: $" + intCalc);
        }
        else if (( intIncome <= 166500) && (intIncome >= 109250))
        {
            double intCalc;
            intCalc = 24393.75 + (.305 * (intIncome-109250));
            System.out.println("You taxable income is: $" + intCalc);
        }
        else if (( intIncome <= 297350) && (intIncome >= 166500))
        {
            double intCalc;
            intCalc = 41855 + (.355 * (intIncome-166500));
            System.out.println("You taxable income is: $" + intCalc);
        }
        else if ( intIncome >= 297350) 
        {
            double intCalc;
            intCalc = 88306 + (.391 * (intIncome-297350));
            System.out.println("You taxable income is: $" + intCalc);
        }
    }//ends marriageTax method
}//ends IRS class