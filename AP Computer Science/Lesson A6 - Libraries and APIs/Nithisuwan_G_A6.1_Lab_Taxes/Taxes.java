
/**
 * Calculates a user's gross pay and deducts the tax to find the net pay.
 * 
 * @Gosone Nithisuwan
 * @Period 5
 * @Feedback: Yes
 */

import java.util.*;

public class Taxes
{
    // instance variables - replace the example below with your own
    Scanner sc = new Scanner(System.in);
    double dblMyHoursWork; // the number of hours the user worked
    double dblMyHourRate; //the hourly rate the user gets paid
    double dblMyGrossPay; // total value before tax deduction
    double dblMyFedTax;//federal tax
    double dblMyFICATax;// FICA tax
    double dblMyStateTax;// State tax
    double dblNetPay;//the total value after tax deduction
    

    /**
     * Constructor for objects of class Taxes
     * 
     * @Pre: dblMyHoursWork, dblMyHourRate, dblMyGrossPay, dblMyFedTax, dblMyFICATax, dblMyStateTax, dblNetPay
     * @Parameters: None
     * @Return: None
     * @Post: dblMyHoursWork, dblMyHourRate, dblMyGrossPay, dblMyFedTax, dblMyFICATax, dblMyStateTax, dblNetPay
     */
    public Taxes()
    {
        // initialise instance variables
        dblMyHoursWork = 0.0;
        dblMyHourRate = 0.0;
        dblMyGrossPay = 0.0;
        dblMyFedTax = .154;
        dblMyFICATax = .0775;
        dblMyStateTax = .040;
        dblNetPay = 0.0;
        
    }//ends Tax method

    /**
     * Gets the hours worked and the hourly rate from the user.
     * 
     * @Pre: dblMyHoursWork, dblMyHourRate
     * @Parameters: None
     * @Return: dblMyGrossPay
     * @Post: dblMyHoursWork, dblMyHourRate, dblMyGrossPay
     */
    public double getWork()
    {
        // gets the hours worked
        System.out.print("Hours worked: ");
        dblMyHoursWork = sc.nextDouble();
        
        
        //gets the hourly rate 
        System.out.print("Hourly rate: ");
        dblMyHourRate = sc.nextDouble();
        
        //gets pay
        
        return dblMyGrossPay = dblMyHoursWork * dblMyHourRate;
    }//ends getWork method
    
    /**
     * Calculates the deduction from the pay
     * 
     * @Pre: dblMyFedTax, dblMyFICATax, dblMyStateTax, dblMyGrossPay
     * @Parameters: None
     * @Return: Void
     * @Post: dblMyGrossPay, dblNetPay
     */
    public void deductTaxes()
    {
        //dedcuts Federal Tax
        dblMyFedTax =  (dblMyFedTax * dblMyGrossPay);
        dblMyGrossPay = dblMyGrossPay - dblMyFedTax;
        System.out.println("Federal Tax deducted: $" + dblMyFedTax );
        
        //dedcuts FICA Tax
        dblMyFICATax = (dblMyFICATax * dblMyGrossPay);
        dblMyGrossPay = dblMyGrossPay - dblMyFICATax;
        System.out.println("FICA Tax deducted: $" + dblMyFICATax);
        
        //dedcuts State Tax
        dblMyStateTax = (dblMyStateTax * dblMyGrossPay);
        dblMyGrossPay = dblMyGrossPay - dblMyStateTax;
        System.out.println("State Tax deducted: $" + dblMyStateTax);
        
        //gets NetPay
        dblNetPay =  dblMyGrossPay;
        
        System.out.println("Your net pay is $" + dblMyGrossPay);
    }//ends deductTaxes
    
}//ends Taxes class
