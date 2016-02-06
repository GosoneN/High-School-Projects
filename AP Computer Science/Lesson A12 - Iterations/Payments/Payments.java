
/**
 * Asks the user for a payment plan and prints it out.
 * 
 * @Gosone Nithisuwan
 * @P5
 * Feedback: Yes
 */

import java.util.*;

public class Payments
{
    double dblMyMInterest;
    double dblMyPrinciple;
    double dblMyPayments;
    double dblMyBalance;
    double dblMyInterest;
    
    Scanner myScan = new Scanner(System.in);

    /**
     * Constructor for objects of class Payments
     */
    public Payments()
    {
        // initialise instance variables
        dblMyMInterest = 0.0;
        dblMyBalance = 0.0;
        dblMyPrinciple = 0.0;
        dblMyPayments = 0.0;
        dblMyInterest = 0.0;
    }//ends Payments() constructor

    /**
     * Asks for userinput
     * 
     * Pre: Variables
     * Param:None
     * Return:Void
     * Post: Sets variables
     */
    public void makePayments()
    {
        System.out.print("Enter the loan amount:");
        dblMyPrinciple = myScan.nextDouble();

        System.out.print("Enter the payment amount:");
        dblMyPayments = myScan.nextDouble();

        System.out.print("Enter the interest per year:");
        dblMyMInterest = myScan.nextDouble() / 12;

        dblMyInterest = dblMyMInterest * 12;

        calc();
    }//ends makePayments() method
    
    /*
     * Caclulates the math
     * 
     * Pre: Variables
     * Param: None
     * Return: Void
     * Post: Prints out variables
     */
    public void calc()
    {
        while(dblMyPrinciple >= 0)
        {
            dblMyInterest = dblMyPrinciple * dblMyMInterest;
            dblMyPrinciple = dblMyPrinciple + dblMyMInterest - dblMyPayments;

            System.out.println("Your Principle: " + dblMyPrinciple);
            System.out.println("Your Payments: " + dblMyPayments);
            System.out.println("Your Monthly Interest: " + dblMyMInterest);
            System.out.println("Your New Balance: " + dblMyPrinciple);

        }//ends the while loop
    }//ends calc() method
}//ends Payment class
