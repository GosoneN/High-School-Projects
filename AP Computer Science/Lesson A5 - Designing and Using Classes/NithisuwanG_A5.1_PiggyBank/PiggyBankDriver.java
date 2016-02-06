
/**
 * Tests the PiggyBank Class
 * 
 * @Gosone Nithisuwan 
 * @P5
 */
public class PiggyBankDriver
{
    /**
     * Runs the program
     * 
     * @Pre: 
     * @Parameters: 
     * @Return: Void
     * @Post: 
     */
    public static void main (String [] args)
    {
        PiggyBank myBank = new PiggyBank();
        myBank.getDeposit();
        myBank.getBalance();
        myBank.getDeposit();
        myBank.getBalance();
    }//ends main method
}//ends PiggyBankDriver class
