
/**
 * Manipulates a string to reverse it, check if its a palindrome, convert it to piglatin, and convert it to shorthand
 * 
 * @Gosone Nithisuwan
 * @P5
 * Feedback: Yes
 */

import java.util.*;

public class StringUtil
{
    static Scanner myScan; //User input
    static String strMyString; //User's inputted string
    static Scanner scMyscMyWord; //Gets the next word in a string
    static String strMyReversed; //Reversed string
    static String strMyShortHand; //String converted into shorthand
    static String strMyPigLatin; //String for converted pigLatin
    
    /**
     * Constructor for StringUtil class
     * 
     * Pre:strMyString, strMyPigLatin, strMyString, strMyReversed
     * Param: None
     * Return: None
     * Post: strMyString, strMyPigLatin, strMyString, strMyReversed
     */
    public StringUtil()
    {
        //intializes variables
        myScan = new Scanner ( System.in ); 
        strMyString = null;
        strMyPigLatin = null;
        strMyString = null;
        strMyReversed = null;
    }//ends StringUtil() constructor
    
    /**
     * Gets and prints outs info of the string
     * 
     * Pre:strMyString, strMyReversed, scMyscMyWord
     * Param: None
     * Return: Void
     * Post: StringUtil
     */
    public void getInfo()
    {
        //Gets the user's input
        System.out.print("Enter in a string: ");
        strMyString = myScan.nextLine();
        
        //Sets variable equal to reversed with no extras
        strMyReversed = removeExtraR(strMyString.length(), strMyString).toLowerCase();
        
        //Prints out the reversed string
        System.out.println("Reversed: " + reverseStr(strMyString.length(), strMyString).toLowerCase());
        
        //Prints out string with no extras 
        System.out.println("Removed Extras: " + removeExtra(strMyReversed.length(), strMyReversed));
        
        //Prints out string with no extras reversed
        System.out.println("Removed Extras Reversed: " + strMyReversed);
        
        //Print outs if it is a Palindrome
        System.out.println("Is it a Palindrome: " + ifPalindrome());
        
        //Prints outs Pig Latin conversion
        System.out.print("Pig Latin: ");
        scMyscMyWord = new Scanner(strMyString);
        goString();
        
        //Shorthand Conversion Print
        strMyShortHand = hasAnd(strMyString);
        strMyShortHand = hasTo(strMyShortHand);
        strMyShortHand = hasFor(strMyShortHand);
        strMyShortHand = hasYou(strMyShortHand);
        System.out.println("\nShort Hand: " + shortHand(reverseStr(strMyShortHand.length(), strMyShortHand).length(), reverseStr(strMyShortHand.length(), strMyShortHand)));
        
    }//ends getInfo() method
    
    /**
     * Reverses the string
     * 
     * Pre: None
     * Param: intLength, strString
     * Return: String
     * Post: strTemp
     */
    public static String reverseStr(int intLength, String strString)
    {
        String strTemp = "";
        if (intLength <= 1)
        {
            return strString.substring( 0,1 );
        }
        else
        {
            return strTemp += strString.substring(intLength - 1, intLength) + reverseStr(intLength - 1, strString);
        }
    }//ends reverseStr() method
    
    /**
     * Removes all the punctuation and spaces in the string and reverses it
     * 
     * Pre: None
     * Param: intLength, strString
     * Return: String
     * Post: strTemp
     */
    public static String removeExtraR(int intLength, String strString )
    {
        String strTemp = "";
        if (intLength <= 1)
        {
            return strString.substring( 0,1 );
        }
        else
        {
            if (!isLetter(strString.charAt(intLength-1)))
            {
              return strTemp += removeExtraR(intLength - 1 , strString);
            }
            else
            {
              return strTemp += strString.substring(intLength - 1, intLength) + removeExtraR(intLength - 1, strString);
            }
        }
    }//ends removeExtraR() method
    
    /**
     * Removes all the punctuation and spaces in the string in forward position
     * 
     * Pre: None
     * Param: intLength, strString
     * Return: String
     * Post: strTemp
     */
    public static String removeExtra(int intLength, String strString )
    {
        String strTemp = "";
        if (intLength <= 1)
        {
            return strString.substring( 0,1 );
        }
        else
        {
            if (!isLetter(strString.charAt(intLength-1)))
            {
              return strTemp += removeExtra(intLength - 1 , strString);
            }
            else
            {
              return strTemp += strString.substring(intLength - 1, intLength) + removeExtra(intLength - 1, strString);
            }
        }
    }//ends removeExtra() method
    
    /**
     * Checks to see if the string is a palindrome
     * 
     * Pre: None
     * Param: None
     * Return: String
     * Post: String
     */
    public static String ifPalindrome()
    {
        String strTemp = removeExtra(strMyString.length(), strMyString).toLowerCase();
        String strTempR = removeExtraR(strTemp.length(), strTemp).toLowerCase();
        
        if ( strTemp.equals( strTempR))
        {
            return "Yes";
        }
        else
        {
            return "No";
        }
    }//ends the ifPalindrome method.
    
    /**
     * Covnerts the string into piglatin
     * 
     * Pre: None
     * Param: strString
     * Return: String
     * Post: String in piglatin
     */
    public static String pigLatin(String strString)
    {
      String strTemp = ""; 
      int length = strString.length();
      if (isVowel(strString.charAt(0))) {
            return (strString + "-way"+" ");
         
        } else {
            char chrTemp = strString.charAt(0);
            String strEnd = strString.substring(1);
            return (strEnd + "-" + chrTemp+ "ay"+" ");
        }
    }//ends pigLatin() method
    
    /**
     *Converts string into shorthand
     * 
     * Pre: None
     * Param: intLength, strString
     * Return: String
     * Post: String in shorthand
     */
    public static String shortHand(int intLength, String strString )
    {
        String strTemp = "";
        if (intLength <= 1)
        {
            return strString.substring( 0,1 );
        }
        else
        {
            if (isVowel(strString.charAt(intLength-1)))
            {
              return strTemp += shortHand(intLength - 1 , strString);
            }
            else
            {
              return strTemp += strString.substring(intLength - 1, intLength) + shortHand(intLength - 1, strString);
            }
        }
    }//ends shortHand() method
    
    /**
     * Checks to see if character is a vowel
     * 
     * Pre: None
     * Param: c
     * Return: Boolean
     * Post: Boolean
     */
    private static boolean isVowel(char c)
    {
        if ((c == 'a') || (c == 'e') || (c == 'i') || (c == 'o') || (c == 'u'))
        {
            return true;
        }
        else
        {
            return false; 
        }
    }//ends isVowel() method
    
    /**
     * Checks to see if there is a certain string inside another string
     * 
     * Pre: None
     * Param: s
     * Return: String
     * Post: String
     */
    private static String hasAnd(String s)
    {
        if (s.contains("and"))
        {
            return s.replace("and","&");
        }
        return s;
    }//ends hasAnd() method
    
    /**
     * Checks to see if there is a certain string inside another string
     * 
     * Pre: None
     * Param: s
     * Return: String
     * Post: String
     */
        private static String hasTo(String s)
    {
        if (s.contains("to"))
        {
            return s.replace("to","2");
        }
        return s;
    }//ends hasTo() method
    
    /**
     * Checks to see if there is a certain string inside another string
     * 
     * Pre: None
     * Param: s
     * Return: String
     * Post: String
     */
        private static String hasFor(String s)
    {
        if (s.contains("for"))
        {
            return s.replace("for","4");
        }
        return s;
    }//ends hasFor() method
    
    /**
     * Checks to see if there is a certain string inside another string
     * 
     * Pre: None
     * Param: s
     * Return: String
     * Post: String
     */
        private static String hasYou(String s)
    {
        if (s.contains("you"))
        {
            return s.replace("you","U");
        }
        return s;
    }//ends hasYou() method
    
    /**
     * Checks to see if the character is a letter
     * 
     * Pre: None
     * Param: c
     * Return: Boolean
     * Post: Boolean
     */
    private static boolean isLetter(char c)
    {
        return ((c >= 'A' && c <= 'Z') || ( c>= 'a' && c <='z'));   
    }//ends isLetter() method
    
    /**
     * Converts each of in a string into piglatin
     * 
     * Pre: None
     * Param: None
     * Return: Void
     * Post: None
     */
    private static void goString()
    {
        if(scMyscMyWord.hasNext())
        {
            strMyPigLatin = scMyscMyWord.next();
            System.out.print(pigLatin(strMyPigLatin.toLowerCase()));
            goString();
        }
    }
}//ends StringUtil Class
