
/**
 * Write a description of class Driver here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class Driver
{
    /**
     * Runs the Taxes class
     * 
     * @Pre: Taxes
     * @Parameters: Array
     * @Return: void
     * @Post: Taxes
     */
    public static void main (String [] args)
    {
        Taxes myTax = new Taxes();
        myTax.getWork();
        myTax.deductTaxes();
        
    }
}
