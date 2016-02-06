
/**
 * Converts decimals to RomanNumerals and vice versa.
 * 
 * @Gosone Nithisuwan
 * @P5
 */

import java.util.*;

public class RomanNum
{
    Scanner myScan;
    int intToInt;
    String strMyInput;
    
    int intMyInput;
    String strToStr;

    /**
     * Constructor for RomanNum
     * 
     * Pre: Variables
     * Param: None
     * Return: None
     * Post: Initialize Variables
     */
    public RomanNum()
    {
       myScan = new Scanner(System.in);
       intToInt = 0;
       strMyInput = null;
       
       intMyInput = 0;
       strToStr = "";
    }//ends RomanNum constructor
    
    /**
     * Gets user input and prints out objective of program
     * 
     * Pre: strMyInput, intMyInput
     * Param: None
     * Return: Void
     * Post: Prints out converted numbers
     */
    public void getInfo()
    {
        System.out.print("Enter in a roman numeral: ");
        strMyInput = myScan.next();
        System.out.println(strToInt(strMyInput, strMyInput.length() ));
        
        System.out.print("Enter in a number: ");
        intMyInput = myScan.nextInt();
        System.out.println(intToStr(intMyInput));
    }//ends getInfo() method

    /**
     * Converts string to numbers
     * 
     * Pre: String
     * Param: strIn, intLength
     * Return: Int
     * Post: Returns converted integers
     */
    public int strToInt(String strIn, int intLength)
    {
        
        if (intLength <= 1)
        {
            switch (strIn.charAt(0))
            {
                case 'M':
                    intToInt +=1000;
                    break;
                case 'D':
                    intToInt +=500;
                    break;
                case 'C':
                    intToInt +=100;
                    break;
                case 'L':
                    intToInt +=50;
                    break;
                case 'X':
                    intToInt +=10;
                    break;
                case 'V':
                    intToInt +=5;
                    break;
                case 'I':
                    intToInt +=1;
                    break;
            }
        }
        else 
        {
            switch (strIn.charAt(intLength - 1))
            {
                case 'M':
                    intToInt +=1000;
                    break;
                case 'D':
                    intToInt +=500;
                    break;
                case 'C':
                    intToInt +=100;
                    break;
                case 'L':
                    intToInt +=50;
                    break;
                case 'X':
                    intToInt +=10;
                    break;
                case 'V':
                    intToInt +=5;
                    break;
                case 'I':
                    intToInt +=1;
                    break;
                    
            }
            strToInt(strIn, intLength - 1);
        }//ends if statement
        
        
        if (strIn.contains("IV"))
        {
            intToInt -= 1;
        }//ends if statement
        
        if (strIn.contains("IX"))
        {
            intToInt -= 1;
        }//ends if statement
        
        if (strIn.contains("XL"))
        {
            intToInt -= 10;
        }//ends if statement
        
        if (strIn.contains("XC"))
        {
            intToInt -= 10;
        }//ends if statement
        
        if (strIn.contains("CD"))
        {
            intToInt -= 100;
        }//ends if statement
        
        if (strIn.contains("CM"))
        {
            intToInt -= 100;
        }//ends if statement
        
        return intToInt;
    }//ends strToInt() method
    
    /**
     * Converts nubmers to strings
     * 
     * Pre: Int
     * Param: intNum
     * Return: String
     * Post: Returns converted strings
     */
    public String intToStr(int intNum)
    {
        
        if (intNum >= 1000)
        {
            strToStr += "M";
            intNum = (intNum - 1000);
        }//ends if statement
        if (intNum >= 900)
        {
            strToStr += "CM";
            intNum = (intNum - 900);
        }//ends if statement
        if (intNum >= 500)
        {
            strToStr += "D";
            intNum = (intNum - 500);
        }//ends if statement
        if (intNum >= 400)
        {
            strToStr += "CD";
            intNum = (intNum - 400);
        }//ends if statement
        if (intNum >= 100)
        {
            strToStr += "C";
            intNum = (intNum - 100);
        }//ends if statement
        if (intNum >= 90)
        {
            strToStr += "XC";
            intNum = (intNum - 90);
        }//ends if statement
        if (intNum >= 50)
        {
            strToStr += "L";
            intNum = (intNum - 50);
        }//ends if statement
        if (intNum >= 40)
        {
            strToStr += "XL";
            intNum = (intNum - 40);
        }//ends if statement
        if (intNum >= 10)
        {
            strToStr += "X";
            intNum = (intNum - 10);
        }//ends if statement
        if (intNum >= 9)
        {
            strToStr += "IX";
            intNum = (intNum - 9);
        }//ends if statement
        if (intNum >= 5)
        {
            strToStr += "V";
            intNum = (intNum - 5);
        }//ends if statement
        if (intNum >= 4)
        {
            strToStr += "IV";
            intNum = (intNum - 4);
        }//ends if statement
        if (intNum == 1)
        {
            strToStr += "I";
            intNum = (intNum - 1);
        }//ends if statement
        if (intNum < 1)
        {
           return strToStr; 
        }//ends if statement
        return strToStr;
        
    }//ends intToStr() method
}//ends RomanNum class
