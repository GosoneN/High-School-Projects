/**
 * Creates a loan table with monthly progress
 * Gosone Nithisuwan
 * P5
 * 
 */

import java.util.Scanner;

public class LoanTable
{
        
    Scanner myScan;
    
    double dblMyLoan;
    double dblMyYears;
    double dblMyLInterest;
    double dblMyHInterest;
    double dblMyAnnualRate;
    double dblMyMonthPay;

    /*
     * Constructor
     */
    public LoanTable()
    {
        // instance variables
        myScan = new Scanner(System.in);
        dblMyLoan = 0;
        dblMyYears = 0;
        dblMyLInterest = 0;
        dblMyHInterest = 0;
        dblMyAnnualRate = 0;
        dblMyMonthPay = 0;
    }//ends the constructor
    
    /*
     * Gets user info
     * 
     * Pre:Varaibles
     * Param: None
     * Return: Void
     * Post: Variables changed
     */
    public void getInfo()
    {
        System.out.print("Enter loan: ");
        dblMyLoan = myScan.nextDouble();
        
        System.out.print("Low Interest rate: ");
        dblMyLInterest = myScan.nextDouble();
        
        System.out.print("High Interest rate: ");
        dblMyHInterest = myScan.nextDouble();
        
        System.out.print("How long are you planning to use your loan: ");
        dblMyYears = myScan.nextInt();
        
        calcLoan();
    }//ends the getInfo method

    /*
     * Calculates the loan table
     * 
     * Pre: Varaibles
     * Param: None
     * Return: Void
     * Post: Prints out loan table
     */
    public void calcLoan()
    {
        double dblTemp1;
        double dblTemp2;
        double dblTemp3;
        
        dblMyAnnualRate = dblMyLInterest;

        System.out.println("Rate     Monthly Payment\n");

        while ( dblMyAnnualRate <= dblMyHInterest )
        {
            dblMyAnnualRate *= 0.01;
            dblMyHInterest *= 0.01;

            dblTemp1 = dblMyAnnualRate / 12.0;
            dblTemp2 = dblMyYears * 12;
            dblTemp3 = Math.pow ( ( 1 + dblTemp1 ), dblTemp2 );

            dblMyMonthPay = ( ( dblMyLoan * dblTemp1 * dblTemp3 ) / ( dblTemp3 - 1 ) );

            dblMyAnnualRate /= 0.01;
            dblMyHInterest /= 0.01;

            System.out.printf ( "%.2f  ", dblMyAnnualRate );
            System.out.printf ( " " + "%.2f\n", dblMyMonthPay );

            dblMyAnnualRate += .25;
        }//ends while loop
    }//ends the Payments method
    
}//ends the LoanTable class