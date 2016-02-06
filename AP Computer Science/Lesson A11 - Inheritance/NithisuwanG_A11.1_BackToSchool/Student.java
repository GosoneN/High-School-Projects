
/**
 * Write a description of class Student here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class Student extends Person
{

   private String strMyID;
   private double dblMyGPA;

   /**
     * Constructs the class
     * 
     * Pre: strMyID, dblMyGPA
     * Param: strName, intAge, strGender, strID, dblGPA
     * Return: None
     * Post: strMyID, dblMyGPA
     */
   public Student ( String strName, int intAge, String strGender, String strID, double dblGPA )
   {
       super(strName, intAge, strGender);
       
       strMyID = strID;
       dblMyGPA = dblGPA;
    }//ends Student() constructor
   
   /**
     * Getter method for strMyID
     * 
     * Pre: strMyID
     * Param: None
     * Return: String
     * Post: strMyID
     */
   public String getID()
   {
       return strMyID;
    }//ends getID() method
   
    /**
     * Getter method for dblMyGPA
     * 
     * Pre: dblMyGPA
     * Param: None
     * Return: Double
     * Post: dblMyGPA
     */
   public double getGPA()
   {
       return dblMyGPA;
    }//ends getGPA() method
    
   /**
     * Setter method for strMyID
     * 
     * Pre: strMyID
     * Param: strID
     * Return: Void
     * Post: strMyID
     */
   public void setID(String strID)
   {
       strMyID = strID;
    }//ends setID() method
    
    /**
     * Setter method for dblMyGPA
     * 
     * Pre: dblMyGPA
     * Param: dblGPA
     * Return: Void
     * Post: dblMyGPA
     */
   public void setGPA(double dblGPA)
   {
       dblMyGPA = dblGPA;
    }//ends setGPA() method
    
    /**
     * Prints out what is needed
     * 
     * Pre: strMyID, dblMyGPA
     * Param: None
     * Return: String
     * Post: String
     */
   public String toString()
   {
        return super.toString() + " ,ID: " + strMyID + " ,GPA: " + dblMyGPA;
   }//ends toString() method
}//ends Student class
