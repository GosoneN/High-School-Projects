
/**
 * A person object
 * 
 * @Gosone Nithisuwan 
 * @P5
 */
public class Person
{
    private String strMyName;
    private int intMyAge;
    private String strMyGender;
    
    /**
     * Constructs the class
     * 
     * Pre: strMyName, intMyAge, strMyGender
     * Param: strName, intAge, strGender
     * Return: None
     * Post: strMyName, intMyAge, strMyGender
     */
    public Person( String strName, int intAge, String strGender)
    {
        strMyName = strName;
        intMyAge = intAge;
        strMyGender = strGender;
    }//ends Person() constructor
    
    /**
     * Getter method for strMyName
     * 
     * Pre: strMyName
     * Param: None
     * Return: String
     * Post: strMyName
     */
    public String getName()
    {
        return strMyName;
    }//ends getName() method
    
    /**
     * Getter method for intMyAge
     * 
     * Pre: intMyAge
     * Param: None
     * Return: int
     * Post: intMyAge
     */
    public int getAge()
    {
        return intMyAge;
    }//ends getAge() method
    
    /**
     * Getter method for strMyGenderyAge
     * 
     * Pre: strMyGender
     * Param: None
     * Return: String
     * Post: strMyGender
     */
    public String getGender()
    {
        return strMyGender;
    }//ends getGender() method
    
    /**
     * Setter method for strMyName
     * 
     * Pre: strMyName
     * Param: strName
     * Return: Void
     * Post: strMyName
     */
    public void setName(String strName)
    {
        strMyName = strName;
    }//ends setName() method
    
     /**
     * Setter method for intMyAge
     * 
     * Pre: intMyAge
     * Param: intAge
     * Return: Void
     * Post: intMyAge
     */
    public void setAge(int intAge)
    {
        intMyAge = intAge;
    }//ends setAge() method
    
    /**
     * Setter method for strMyGender
     * 
     * Pre: strMyGender
     * Param: strGender
     * Return: Void
     * Post: strMyGender
     */
    public void setGender(String strGender)
    {
        strMyGender = strGender;
    }//ends setGender() method
    
    /**
     * Prints out what is needed
     * 
     * Pre: strMyName, intMyAge, strMyGender
     * Param: None
     * Return: String
     * Post: String
     */
    public String toString()
    {
        return "Name: " + strMyName + ", Age: " + intMyAge + " , Gender: " + strMyGender;
    }//ends toString() method
}//ends Person class
