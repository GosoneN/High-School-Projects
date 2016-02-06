
/**
 * Solves the Towers of Hanoi puzzle
 * 
 * @Author: Gosone Nithisuwan
 * Period:3
 */

import java.util.*; //imports java.util for the scanner

public class ToH
{
    private final Scanner myScan; //A new scanner
    private int intMyDisc;  //the number of discs to have

    /**
     * Constructor
     */
    public ToH()
    {
        myScan = new Scanner(System.in); //Creates a new scanner
        intMyDisc = 0; //Default disc is 0
    }//ends ToH() constructor

    /**
     * Has the user input info
     */
    public void getInfo()
    {
        System.out.print("Enter the number of discs: "); //Prompts the user for intMyDisc
        intMyDisc = myScan.nextInt(); //intMyDisc is the next number
        moveDisc(intMyDisc,1,2,3); //Calls the moveDisc() method
    }//ends getInfo() method

    /**
     * Moves the discs from pole to pole recursively
     *
     * @param intDisc - The current disc
     * @param intPole1 - The first pole
     * @param intPole2 - The second pole
     * @param intPole3 - The third pole
     */
    private void moveDisc(int intDisc, int intPole1, int intPole2, int intPole3)
    {
       if (intDisc == 1) //Base Case
       {
           System.out.println("Moved Disc " + intDisc + " from Pole " + intPole1 + " to Pole " + intPole2); //Moves disc
        }//ends if statement
       else if (intDisc <= 0) //If no discs
        {
            System.out.println("No disc to move"); //Prints out that there are no discs
        }//ends if-else statement
        else //if intDisc is greater than one
        {
            moveDisc(intDisc-1, intPole1, intPole3, intPole2); //Calls the method recursively
            System.out.println("Moved Disc " + intDisc + " from Pole " +intPole1+ " to Pole " + intPole2); //Moves disc
            moveDisc(intDisc-1, intPole3, intPole2, intPole1); //Calls the method recursively
        }//ends else statement

    }//ends moveDisc() method

}//ends ToH()
