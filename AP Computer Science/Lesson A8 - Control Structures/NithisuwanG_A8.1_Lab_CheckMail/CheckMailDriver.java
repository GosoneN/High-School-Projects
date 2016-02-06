

/**
 * Tests the CheckMail Class
 * 
 * @Gosone Nithisuwan 
 * @P5
 */
public class CheckMailDriver
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
        CheckMail myMail = new CheckMail();
        myMail.getDimensions();
        myMail.girth();
        myMail.calculatePackage();
        
    }//ends main method
}//ends CheckMailDriver class
