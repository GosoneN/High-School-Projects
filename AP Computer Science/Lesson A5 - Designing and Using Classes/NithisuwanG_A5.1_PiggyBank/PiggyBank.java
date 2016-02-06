
/**
 * Asks the user to insert coins and prints out the number of coins and the fltTotal amount of money.
 * 
 * @Gosone Nithisuwan
 * @P5
 * @feedback:yes
 */

import java.util.*;

public class PiggyBank
{
    // instance variables - replace the example below with your own
    Scanner sc;
    int intMyQuarter; // Number of quarters in bank
    int intMyDime;// Number of dimes in bank
    int intMyNickel; // Number of nickels in bank
    int intMyPenny; // Number of penny in bank
    int intDepositQuarter; // Number of quarters to deposit
    int intDepositDime; // Number of dime to deposit
    int intDepositNickel; // Number of nickel to deposit
    int intDepositPenny; // Number of penny to deposit
    float fltTotal; // Total amount of money in the bank
    
    
    

    /**
     * Constructor for objects of class PiggyBank
     */
    public PiggyBank()
    {
        // initialise instance variables
        sc = new Scanner(System.in);
        
    }//ends PiggyBank constructor
    
    /**
     * Constructor for objects of class PiggyBank
     */
    public PiggyBank(int intMyQuarters, int intMyDimes, int intMyNickels, int intPennie)
    {
        // initialise instance variables
        sc = new Scanner(System.in);
        
    }//ends PiggyBank constructor

    /**
     * Asks the user to insert coins
     * 
     * @param  None
     * @return     void
     */
    public void getDeposit()
    {
        //Asks the user to insert coins
        
        System.out.print("Enter the amount of quarter(s) to insert : ");
        intDepositQuarter = sc.nextInt();
        System.out.print("Enter the amount of dime(s) to insert : ");
        intDepositDime = sc.nextInt();
        System.out.print("Enter the amount of nickel(s) to insert : ");
        intDepositNickel = sc.nextInt();
        System.out.print("Enter the amount of penny(s) to insert : ");
        intDepositPenny = sc.nextInt();
        
    }//ends getDeposit method
    
    /**
     * Asks the user to insert coins
     * 
     * @param  None
     * @return    void
     */
    public void getBalance()
    {
        //calculates the balances of the bank
        intMyQuarter += intDepositQuarter;
        intMyDime += intDepositDime;
        intMyNickel += intDepositNickel;
        intMyPenny += intDepositPenny;
        fltTotal = (intMyQuarter*25) + (intMyDime * 10) + (intMyNickel*5) + (intMyPenny * 1);
        fltTotal = (fltTotal / 100) ;
        //Prints out the number of coins in the banks
        System.out.println("\nThe number of quarters in the bank is: " + intMyQuarter);
        System.out.println("The number of dimes in the bank is: " + intMyDime);
        System.out.println("The number of nickel in the bank is: " + intMyNickel);
        System.out.println("The number of penny in the bank is: " + intMyPenny+"\n");
        System.out.println("The Total amount of money you have is: " + fltTotal);
    }//ends getBalance method
}//ends PiggyBank class
