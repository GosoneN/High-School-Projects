
 import java.util.*;
 
/**
 * Has the user enter a number and return a Fibonacci number
 * 
 * @Gosone Nithisuwan
 * @P5
 */
public class Fibonacci
{
    // instance variables - replace the example below with your own
    Scanner myScanner;
    int intMyPos;

    /**
     * Constructor for objects of class Fibonacci
     */
    public Fibonacci()
    {
        // initialise instance variables
        myScanner = new Scanner(System.in);
        intMyPos = 0;
    }//ends Fibonacci contructor

    public void getNum()
    {
        System.out.print("Enter a number greater than zero: ");
        intMyPos = myScanner.nextInt();
        
        this.calcFibonacci(intMyPos);
        System.out.println(calcFibonacci(intMyPos));
    }//ends getNum method
    
    public int calcFibonacci(int intNum)
    {
        if (intNum ==  0) 
            return 0;
        if (intNum == 1)
            return 1;
        return (calcFibonacci(intNum-1) + calcFibonacci(intNum-2));
    }//ends calcFibonacci method
}//ends Fibonacci class
