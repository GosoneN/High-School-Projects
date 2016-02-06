/**
 * This program draws pictures!
 * 
 * Gosone Nithisuwan
 * P5
 * Feedback: yes
 */

import java.util.*;
import gpdraw.*;

public class Pictures
{
    Scanner myScanner;
    int intMyRow;
    int intMyCol;
    
    SketchPad myPaper;
    DrawingTool myPen;
    
    /*
     * Constructor
     */
    public Pictures()
    {
        myScanner = new Scanner(System.in);

    }//ends Pictures() constructor

    /*
     * Draws a multiplication table
     * 
     * Pre: Scanner
     * Param: None
     * Return: Void
     * Post: Prints out table
     */
    public void drawTable()
    {
        System.out.print("Enter the number of rows:");
        intMyRow = myScanner.nextInt();
        System.out.print("Enter the number of columns:");
        intMyCol = myScanner.nextInt();
        
        for ( int i = 0; i < intMyRow; i++)
        {
            System.out.printf("%5s", "  " +(i + 1));
        }//ends for statement

        for ( int j = 1; j <= intMyCol; j++)
        {
            System.out.printf("%5s", " \n" + (j)); 
            
            for ( int i = 1; i <= intMyRow; i++ )
            {
              System.out.printf("%5d", (i*j));  
            }//ends for statement
        }//ends for statement
    }//ends drawTable() method

    /*
     * Draws a pyramid of asterisks
     * 
     * Pre: Variable and Scanners
     * Param: None
     * Return: Void
     * Post: Prints out pyramid
     */
    public void drawPyramid()
    {
        System.out.println("Enter the amount of lines:");
        int intLines = myScanner.nextInt();

        for (int i = 1; i <= intLines; i++)
        {
            for (int j = 0; j < (intLines - i); j++)
            {
               System.out.print(" ");
            }//ends for loop
            for (int j = 1; j <= i; j++)
            {
               System.out.print("*");
            }//ends for loop
            for (int k = 1; k < i; k++)
            {
               System.out.print("*");
            }//ends fop loop
 
            System.out.println();
        }//ends for loop
    }//ends drawPyramid() method

    /*
     * Draws a sunburst
     * 
     * Pre:Pen and Paper
     * Param: None
     * Return: Void
     * Post: Draws a sunburst
     */
    public void drawBurst()
    {
        myPaper = new SketchPad(500,500);
        myPen = new DrawingTool(myPaper);
        myPen.down();

        for(int i = 0; i <= 360; i++)
        {
          myPen.forward(350);
          myPen.backward(350);
          myPen.turnRight(1);
        }//ends for loop      
    }//ends drawBurst() method
}//ends Pictures class
