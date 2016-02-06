
/**
 * Users input in grades and prints out eligiblity
 * 
 * @Gosone Nithisuwan
 * @P5
 */

import java.util.*;

public class Grades
{
    Scanner myScan;
    double dblMyGPA;
    String strMyGrade;
    char charMyGrade;
    boolean blnMyF;
    int intMyCount;
    
    /*
     * Constructor
     * 
     * Pre: Declared Variables
     * Param: None
     * Return: None
     * Post: Initialize Variables
     */
    public Grades()
    {
        myScan = new Scanner ( System.in );
        dblMyGPA = 0;
        strMyGrade = "";
        charMyGrade = ' ';
        int intMyCount = 0;
        blnMyF = false;
    }//ends Grades() constructor
    
    /*
     * Calculates grades
     * 
     * Pre: Variables and Methods
     * Param: None
     * Return: Void
     * Post: Prints out GPA
     */
    public void getGrades()
    {
        System.out.println("Enter in your grades, enter in a non-grade character to stop : ");
        
        strMyGrade = myScan.next();
        strMyGrade = strMyGrade.toLowerCase();
        charMyGrade = strMyGrade.charAt(0);
        
        while ((charMyGrade <= 'd') && (charMyGrade >= 'a') || (charMyGrade == 'f'))
        {
            intMyCount++;
            if (charMyGrade == 'a')
            {
                dblMyGPA += 4;
            }
            if (charMyGrade == 'b')
            {
                dblMyGPA += 3;
            }
            if (charMyGrade == 'c')
            {
                dblMyGPA += 2;
            }
            if (charMyGrade == 'd')
            {
                dblMyGPA += 1;
            }
            if( charMyGrade == 'f')
            {
               dblMyGPA += 0;
               blnMyF = this.hasF();
            }
            
            strMyGrade = myScan.next();
            strMyGrade = strMyGrade.toLowerCase();
            charMyGrade = strMyGrade.charAt(0);
        }
        dblMyGPA = dblMyGPA / intMyCount;
        
        if (intMyCount < 4)
        {
            System.out.println("Ineligible, taking less than 4 classes");
        }
        
        System.out.println("Your GPA is: " + dblMyGPA);
        this.calcEligible();

    }//ends getGrades() method
    
    /*
     * If the user has an user, return true
     * 
     * Pre: None
     * Param: None
     * Return: Boolean
     * Post: Returns true
     */
    public boolean hasF()
    {
        return true;
    }//ends hasF() method
    
    /*
     * Prints out Ineligiblitiy
     * 
     * Pre: Variables
     * Param: None
     * Return: Void
     * Post: Prints out a line
     */
    public void getF()
    {
        if (dblMyGPA >= 2.0)
        {
            System.out.println("Ineligible, gpa above 2.0 but has F grade.");
        }
        if (dblMyGPA < 2.0)
        {
            System.out.println("Ineligible, gpa below 2.0 and has F grade.");
        }
    }//ends getF() method

    /*
     * Sees if the user is eligible
     * 
     * Pre: Variables
     * Param: None
     * Return: Void
     * Post: Prints out eligibility
     */
    public void calcEligible()
    {
        if (blnMyF == true)
        {
            getF();
        }
        else if (dblMyGPA >= 2.0 && blnMyF == false)
        {
           System.out.println("Eligible"); 
        }//ends if-else
    }//ends calcEligible() method
}//ends Grades class
