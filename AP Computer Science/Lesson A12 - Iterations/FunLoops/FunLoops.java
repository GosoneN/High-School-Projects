
/**
 * Prints out LCM and Magic Squares
 * 
 * @Gosone Nithisuwan 
 * @P5
 * Feedback: Yes
 */

import java.util.*;

public class FunLoops
{
    Scanner myScan;
    int intUserInput;

    /**
     * Constructor for FunLoops
     * 
     * Pre: Variables declared
     * Param: None
     * Return: None
     * Post: Initialize variables
     */
    public FunLoops()
    {
        intUserInput = 4;
        myScan = new Scanner ( System.in );
        
    }//ends FunLoops() constructor
    
    /**
     * Gets user info
     * 
     * Pre: Needs two variable declared
     * Param: None
     * Return: Void
     * Post: Calls method
     */
    public void getInfo()
    {
        System.out.print("Enter the number of magic squares you want: ");
        
        intUserInput = myScan.nextInt();
        
        isMagicNum();
        
        System.out.print("Enter two integers: ");
        getLCM(myScan.nextInt(), myScan.nextInt());
    }//Ends getInfo() method
    
    /**
     * Checks if the number is a perfect square
     * 
     * Pre: Needs a parameter
     * Param: int intNum
     * Return: Boolean
     * Post: Return boolean
     */    
    public boolean isPerfectSquare(int intNum)
    {
        int intTemp = (int) Math.sqrt(intNum);
        
        if ( Math.pow(intTemp, 2) == intNum )
        {
            return true;
        }
        else
        {
            return false;
        }//ends if statement
        
    }//ends isPerfectSquare() method
    
    /**
     * Creates magic numbers
     * 
     * Pre: Needs isPerfectSquare()
     * Param: None
     * Return: Void
     * Post: Prints out magic squares
     */
    public void isMagicNum()
    {
        boolean blnTemp = true;
        int intTemp = 0;
        int intSum = 0;
        
        for (int i = 0; i < intUserInput; i++)
        {
            while(blnTemp = true)
            {
                intSum += intTemp;
                if ((isPerfectSquare(intSum) == true))
                {
                    intTemp++;
                    System.out.println(intSum);
                    break;
                }
                else
                {
                    intTemp++;
                }//ends if statement
            }//ends while loop
        }//ends for loop
        
    }//ends isMagicNum() method
    

    /*
     * Calculates the LCM
     * 
     * Pre: Needs parameters
     * Param: int intNum1, int intNum2
     * Return: Void
     * Post: Prints out the LCM
     */
    public void getLCM ( int intNum1, int intNum2 )
    {
        int intLarger;
        int intSmaller;
        if ( intNum1 - intNum2 < 0)
        {
            intLarger = intNum2;
            intSmaller = intNum1;
            System.out.println("You choose " + intLarger + " and " + intSmaller);
        }
        else
        {
            intLarger = intNum1;
            intSmaller = intNum2;
            System.out.println("You choose " + intLarger + " and " + intSmaller);
        }
        
        int intRemainder = intLarger % intSmaller;
        
        if (intRemainder == 0)
        {
            System.out.println("The LCM is : " + (intLarger));    
        }
        else
        {
            System.out.println("The LCM is : " + ((intLarger * intSmaller)/intRemainder));
        }
        
    }
}//ends FunLoop class
