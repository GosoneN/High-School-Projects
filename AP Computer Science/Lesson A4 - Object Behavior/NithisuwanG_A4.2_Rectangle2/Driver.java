
/**
 * Runs the Rectangle class
 * 
 * @Gosone Nithisuwan
 * @P5
 * Feedback: Yes
 */
public class Driver
{
    /**
     * Tests the Rectangle Class
     * 
     * @Pre: 
     * @Parameters: 
     * @Return: Void
     * @Post: 
     */
    public static void main (String [] args)
    {
        
        Rectangle rectA = new Rectangle(0,0,99,99);
        Rectangle rectB = new Rectangle(0,0,99,33);
        Rectangle rectC = new Rectangle(0,0,33,99);
        rectA.draw();
        rectB.draw();
        rectC.draw();

    }//ends the main method
}//ends the Driver class
