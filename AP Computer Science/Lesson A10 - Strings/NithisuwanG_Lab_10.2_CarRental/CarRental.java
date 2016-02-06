
/**
 * Has the user enter in a car model and a lincense plate and prints out the rental code
 * 
 * @Gosone Nithisuwan 
 * @P5
 * Feedback:Yes
 */

import java.util.*;

public class CarRental
{
    // instance variables - replace the example below with your own
    private String strMyMake; //the car maker
    private String strMyModel; //the car model
    private String strMyPlate; //the car's license plate
    private int intMyPlate; //the car's license int plate
    private int intMyRent; //the rental code
    
    Scanner myScan; //User input

    /**
     * Constructor for objects of class CarRental
     */
    public CarRental()
    {
        // initialise instance variables
        strMyMake = null; //No maker 
        strMyModel = null; //No model 
        strMyPlate = null; //No license plate
        intMyPlate = 0;
        intMyRent = 0;
        
        myScan = new Scanner ( System.in ); //Initialize Scanner
    }//ends CarRental method

    /**
     * User enters in make, model, and license plater
     * 
     * @Pre: strMyMake, strMyModel, strMyPlate, intMyPlate
     * @Parameter: None
     * @Return: Void
     * @Post: strMyMake, strMyModel, strMyPlate, intMyPlate   
     */
    public void userInfo()
    {
        //Get the car's maker
        System.out.print("Enter in the car's maker: ");
        strMyMake = myScan.next();
        
        //Get the car's model
        System.out.print("Enter in the car's model: ");
        strMyModel = myScan.next();
        
        //Get the car's license plate
        System.out.print("Enter in three letters of the car's license plate: ");
        strMyPlate = myScan.next();
        
        System.out.print("Enter in three integers of the car's license plate: ");
        intMyPlate = myScan.nextInt();
        
    }//ends userInfo method
    
    /**
     * Calculates the rental code
     * 
     * @Pre: strMyPlate, intMyRent, intMyPlate, strMyMake, strMyModel
     * @Parameter: Return 
     * @Return: Void
     * @Post: intMyRent
     */
    public void getRental()
    {
        
        int intASCII = strMyPlate.codePointAt(0)+ strMyPlate.codePointAt(1) + strMyPlate.codePointAt(2);
        intMyRent = intASCII + intMyPlate;
        
        char charTemp =(char)((intMyRent % 26) + 65); 
        
        System.out.println("Maker: " + strMyMake);
        System.out.println("Model: " + strMyModel);
        System.out.print("Rental Code: " + charTemp);
        System.out.println(intMyRent);
    }//ends getRental method
}//ends CarRental class
