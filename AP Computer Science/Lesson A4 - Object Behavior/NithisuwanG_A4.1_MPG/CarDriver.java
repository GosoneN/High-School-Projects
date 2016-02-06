
/**
 * Tests the Car class
 * 
 * @Gosone Nithisuwan
 * @P5
 * Feedback:Yes
 */
public class CarDriver
{
  /**
     * Tests the program
     * 
     * @Pre: 
     * @Parameters: 
     * @Return: Void
     * @Post: 
     */
  public static void main (String [] args)
  {
      Car auto = new Car(15);
      System.out.println("New Car odometer reading: " + auto.intMyStartMiles);
      auto.fillUp(150,8);
      System.out.println("Miles per gallon: " + auto.calculateMPG());
      System.out.println("Miles per gallon: " + auto.calculateMPG());
      auto.resetMPG();
      auto.fillUp(350, 10);
      auto.fillUp(450, 20);
      System.out.println("Miles per gallon: " + auto.calculateMPG());
      auto.resetMPG();
      auto.fillUp(603, 25.5);
      System.out.println("Miles per gallon: " + auto.calculateMPG());
        

      
    }//ends main method
}//ends CarDriver class
