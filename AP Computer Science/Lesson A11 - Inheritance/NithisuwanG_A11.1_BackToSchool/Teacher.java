
/**
 * 
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class Teacher extends Person
{
   private String strMySubject;
   private double dblMySalary;

    /**
     * Constructs the class
     * 
     * Pre: strMySubject, dblMySa
     * Param: strName, intAge, strGender, strSubject, dblSalary
     * Return: None
     * Post: strMySubject, dblMySalary
     */
   public Teacher ( String strName, int intAge, String strGender, String strSubject, double dblSalary )
   {
       super(strName, intAge, strGender);
       
       strMySubject = strSubject;
       dblMySalary = dblSalary;
    }//ends Student() constructor
    
   /**
     * Getter method for strMySubject
     * 
     * Pre: strMySubject
     * Param: None
     * Return: String
     * Post: strMySubject
     */
   public String getSubject()
   {
       return strMySubject;
    }//ends getSubject() method
   
   /**
     * Getter method for dblMySalary
     * 
     * Pre: dblMySalary
     * Param: None
     * Return: double
     * Post: dblMySalary
     */
   public double getSalary()
   {
       return dblMySalary;
    }//ends getSalary() method
    
   /**
     * Setter method for strMySubject
     * 
     * Pre: strMySubject
     * Param: strSubject
     * Return: Void
     * Post: strMySubject
     */
   public void setSubject(String strSubject)
   {
       strMySubject = strSubject;
    }//ends set() method
    
   /**
     * Setter method for dblMySalary
     * 
     * Pre: dblMySalary
     * Param: dblSalary
     * Return: Void
     * Post: dblMySalary
     */
   public void setSalary(double dblSalary)
   {
       dblMySalary = dblSalary;
    }//ends setSalary() method
    
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
        return super.toString() + " , Subject: " + strMySubject + " , Salary: " + dblMySalary;
   }//ends toString() method
}//ends Teacher class
