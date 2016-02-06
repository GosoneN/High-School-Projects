
import java.util.*;

/**
 * Calculates the date of Easter during any year.
 * 
 * @Gosone Nithisuwan 
 * @P5
 * Modify : Yes
 */
public class Easter
{
    // instance variables - replace the example below with your own
    int intYear;
    Scanner myScanner;

    /**
     * Constructor for objects of class Easter
     */
    public Easter()
    {
        // initialise instance variables
       intYear = 0; 
       myScanner = new Scanner(System.in);
    }//ends Easter constructor

    /**
     * Gets the year from the User
     * 
     * @param  None
     * @return     intYear 
     */
    public int getYear()
    {
        // put your code here
        System.out.print("Please enter a year: ");
        intYear = myScanner.nextInt();
        
        
        return intYear;
    }//ends getYear method
    
    /**
     * Calculates the date Easter falls on
     * Return: Void
     * Parameters : N/A
     * 
     */
    public void calculateYear()
    {
        //Local Variables
        int a;
        int b;
        int c;
        int d;
        int e;
        int f;
        int g;
        int h;
        int i;
        int k;
        int r;
        int m; 
        int n;
        int p;
        
        
        
        //Calculation
        a = intYear % 19;
        System.out.println("a = " + a);
        b = intYear / 100;
        System.out.println("b = " + b);
        c = intYear % 100;
        System.out.println("c = " + c);
        d = b / 4;
        System.out.println("d = " + d);
        e = b % 4;
        System.out.println("e = " + e);
        f = (b + 8) / 25;
        System.out.println("f = " + f);
        g = (b - f + 1) / 3;
        System.out.println("g = " + g);
        h = (19 * a + b - d - g + 15) % 30;
        System.out.println("h = " + h);
        i = c / 4;
        System.out.println("i = " + i);
        k = c % 4;
        System.out.println("k = " + k);
        r = (32 + 2 * e + 2 * i - h - k) % 7;
        System.out.println("r = " + r);
        m = ( a + 11 * h + 22 * r) / 451;
        System.out.println("m = " + m);
        n = (h + r - 7 * m + 114) / 31;
        System.out.println("n = " + n);
        p = ((h + r - 7 * m + 114) % 31)+1;
        System.out.println("p = " + p);
        
        //Prints out the date
        System.out.println("Easter in " + intYear + " falls on " + n+ "/"+ p);
    }//ends calculateYear method
}//ends Easter class
