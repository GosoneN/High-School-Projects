
/**
 * Write a description of class CollegeStudent here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class CollegeStudent extends Student
{
   private String strMyMajor;
   private int intMyYear;

   /**
     * Constructs the class
     * 
     * Pre: strMyMajor, intMyYear
     * Param: strName, intAge, strGender, strID, dblGPA, intYear, strMajor
     * Return: None
     * Post: strMyMajor, intMyYear
     */
   public CollegeStudent ( String strName, int intAge, String strGender, String strID, double dblGPA, int intYear, String strMajor)
   {
       super(strName, intAge, strGender, strID, dblGPA);
       
       strMyMajor = strMajor;
       intMyYear = intYear;
    }//ends Student() constructor
    
   /**
     * Getter method for strMyMajor
     * 
     * Pre: strMyMajor
     * Param: None
     * Return: String
     * Post: strMyMajor
     */
   public String getMajor()
   {
       return strMyMajor;
    }//ends getID() method
    
   /**
     * Getter method for intMyYear
     * 
     * Pre: intMyYear
     * Param: None
     * Return: int
     * Post: intMyYear
     */
   public int getYear()
   {
       return intMyYear;
    }//ends getGPA() method
    
   /**
     * Setter method for strMyMajor
     * 
     * Pre: strMyMajor
     * Param: strMajor
     * Return: Void
     * Post: strMyMajor
     */
   public void setMajor(String strMajor)
   {
       strMyMajor = strMajor;
    }//ends setID() method
    
   /**
     * Setter method for intMyYear
     * 
     * Pre: intMyYear
     * Param: intYear
     * Return: Void
     * Post: intMyYear
     */
   public void setYear(int intYear)
   {
       intMyYear = intYear;
    }//ends setGPA() method
    
   /**
     * Prints out what is needed
     * 
     * Pre: strMyMajor, intMyYear
     * Param: None
     * Return: String
     * Post: String
     */
   public String toString()
   {
        return super.toString() + " ,Major: " + strMyMajor + " ,Year : " + intMyYear;
   }//ends toString() method
}//ends CollegeStudent class
