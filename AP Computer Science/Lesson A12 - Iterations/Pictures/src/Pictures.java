/**
 * Created with IntelliJ IDEA.
 * User: 308264
 * Date: 12/19/12
 * Time: 7:29 AM
 * To change this template use File | Settings | File Templates.
 */

import java.util.*;
import gpdraw.*;

public class Pictures
{
    Scanner myScanner;
    int row, col;
    int intLines;
    SketchPad myPaper = new SketchPad(500,500);
    DrawingTool myPen = new DrawingTool(myPaper);
    int maxRow1;
    int totals;
    int maxCol;

    public Pictures()
    {
        myScanner = new Scanner(System.in);
        intLines = 0;
        maxRow1 = 0;
    }

    public void drawTable ()
    {


        System.out.print("Enter the number of rows:");
        row = myScanner.nextInt();
        System.out.print("Enter the number of columns:");
        col = myScanner.nextInt();


        for(int maxRow = 0; maxRow < row; maxRow++)
        {
            totals = col * maxRow;
            System.out.printf("%5s", col);
            System.out.println();
           System.out.printf ("%4s", totals);
            maxRow1 = maxRow;
        }



        for (maxCol = 1; maxCol <= col; col++);
        {
            totals = maxCol * maxRow1;
            System.out.printf ("%4s", totals);
        }

        System.out.print(maxCol * maxRow1);
        System.out.println("");

    }


    public void drawPyramid()
    {
        System.out.print("Enter the number of lines that you want your pyramid to have:");
        intLines = myScanner.nextInt();


        for (int index = 0; index <= intLines; index++)
        {
            for (int j = 0; j <= (intLines - index); j++)
            {
                System.out.printf(" ");
            }
            for (int j = 0; j <= index; j++)
            {
                System.out.printf("*");
            }
            System.out.printf("\n");
        }
    }

    public void drawSunburst()
    {
       myPen.down();

       for(int index = 0; index <= 360; index++)
        {
          myPen.forward(350);
          myPen.backward(350);
          myPen.turnRight(1);
        }

    }



    public static void main (String [] args)
    {
        Pictures myPictures = new Pictures();
       // myPictures.drawTable();
       // myPictures.drawSunburst();
        myPictures.drawPyramid();

    }
}
