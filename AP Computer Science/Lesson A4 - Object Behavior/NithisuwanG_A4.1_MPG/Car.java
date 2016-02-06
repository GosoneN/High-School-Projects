
/**
 * Simulates a car with miles and gallons used
 * 
 * @Gosone Nithisuwan
 * @P5
 * Feedback: Yes
 */
public class Car
{
    // instance variables - replace the example below with your own
    int intMyStartMiles;
    int intMyEndMiles;
    double dblMyGallonsUsed;

    /**
     * Constructor for objects of class MPG
     */
    public Car(int odometerReading)
    {
        // initialise instance variables
        intMyStartMiles = odometerReading;
        intMyEndMiles = 0;
        dblMyGallonsUsed = 0;
    }//ends Car constructor

    /**
     * Fills up the car's gas
     * 
     * @Pre: 
     * @Parameters: odometerReading , gallons
     * @Return: Void
     * @Post: 
     */
    public void fillUp(int odometerReading, double gallons)
    {
        // put your code here
        intMyEndMiles = odometerReading;
        dblMyGallonsUsed += gallons;
    }//ends fillUp method
    
    /**
     * Calculate the MPG
     * 
     * @Pre: 
     * @Parameters: None
     * @Return: MPG: (intMyEndMiles - intMyStartMiles) / dblMyGallonsUsed
     * @Post: 
     */
    public double calculateMPG()
    {
        // put your code here
        return (double) (intMyEndMiles - intMyStartMiles) / dblMyGallonsUsed;
    }//ends calcuateMPG method
    
    /**
     * Resets the MPG
     * 
     * @Pre: 
     * @Parameters: None
     * @Return: intMyStartMiles
     * @Post: 
     */
    public double resetMPG()
    {
        // put your code here
        intMyStartMiles = intMyEndMiles;
        dblMyGallonsUsed = 0;
        return intMyStartMiles;
    }//ends resetMPG method
}//ends Car class
