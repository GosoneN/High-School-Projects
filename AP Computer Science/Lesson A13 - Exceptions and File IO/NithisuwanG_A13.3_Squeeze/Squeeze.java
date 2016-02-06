
/**
 * Reads lines from a file and replaces the spaces in the beginning of the line with the number of spaces
 * 
 * @Gosone Nithisuwan 
 * @P5
 */

import java.util.*;
import java.io.*;

public class Squeeze
{
    Scanner myScan;
    File myFile;
    FileWriter writeMyFile;
    String strMySpaces;

    public Squeeze()
    {
        
        try
        {
            myFile = new File("squeeze.txt");
            myScan = new Scanner(myFile);
        }catch (Exception e)
        {
            System.out.println("The files does not exist.");
        }//ends catch statement
        
        spaces();
    }//ends Squeeze constructor
    
    public void spaces()
    {
        String strTemp;
        int intCount = 0;
        while(myScan.hasNext())
        {
            strTemp = myScan.nextLine();
            
            for (int i = 0; i < strTemp.length(); i++)
            {
                if( strTemp.charAt(i) == (' '))
                {
                    intCount++;
                }
                if( strTemp.charAt(i) != (' '))
                {
                    break;
                }
            }
            
            System.out.println(strTemp);
        }
    }
}
