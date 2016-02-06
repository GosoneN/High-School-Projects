import java.util.*;

/**
 * Asks the user for an integer and converts the integer into number of coins
 * 
 * @Gosone Nithisuwan
 * @P5
 * feedback: yes
 */
public class Coins
{
    
    Scanner myScanner;
    int intUserCoin;
    int intQuarter;
    int intDime;
    int intNickel;
    int intPenny;

    /**
     * Constructor for objects of class Coins
     */
    public Coins()
    {
        myScanner = new Scanner(System.in);
    }//ends Coin method

    /**
     * Gets the number of cents the user has.
     * 
     * @param  None
     * @return     intUserCoin
     */
    public int getUserCoin()
    {
        // put your code here
        System.out.print("Enter amount of cents you have: ");
        intUserCoin = myScanner.nextInt();
        
        System.out.println(intUserCoin + " cents =>");
        
        return intUserCoin;
    }//ends getUserCoin method
    
    /**
     *Calculates the number of coins the user has.
     * 
     * @param  None
     * @return   Void
     */
    public void calculate()
    {
        intQuarter = intUserCoin / 25;
        intUserCoin = intUserCoin % 25;
        intDime = intUserCoin / 10;
        intUserCoin = intUserCoin % 10;
        intNickel = intUserCoin / 5;
        intUserCoin = intUserCoin % 5;
        intPenny = intUserCoin / 1;
        intUserCoin = intUserCoin % 1;
    }//ends calculate method
    
    /**
     * Prints out the results of how many coins the user has.
     * 
     * @param  None
     * @return   Void
     */
    public void draw()
    {
        System.out.printf("%-10s","Quarter(s)");
        System.out.printf("%10s",intQuarter+"\n");
        System.out.printf("%-10s","Dime(s)");
        System.out.printf("%10s",intDime+"\n");
        System.out.printf("%-10s","Nickel(s)");
        System.out.printf("%10s",intNickel+"\n");
        System.out.printf("%-10s","Penny(s)");
        System.out.printf("%10s",intPenny+"\n");
        
    }//ends draw method
}//ends Coins class
