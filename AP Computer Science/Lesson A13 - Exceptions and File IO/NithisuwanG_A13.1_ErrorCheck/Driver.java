
/**
 * Write a description of class Driver here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class Driver
{
    // instance variables - replace the example below with your own
    public static void main (String [] args)
    {
        
        CheckingAccount myAcc = new CheckingAccount(-500, 1234);
        myAcc.deposit(-100);
        myAcc.withdraw(200);
    }
}
