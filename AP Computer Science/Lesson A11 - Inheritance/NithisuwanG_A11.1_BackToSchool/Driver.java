
/**
 * Write a description of class Driver here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class Driver
{
    /**
     * Runs the program
     * 
     * @Pre: 
     * @Parameters: 
     * @Return: Void
     * @Post: 
     */
    public static void main (String [] args)
    {
        Person bob = new Person("Pur Son", 27, "M");
        System.out.println(bob);
        
        Student lynne = new Student("Stew Dent", 16, "F", "HS95129", 3.5);
        System.out.println(lynne);
        
        Teacher mrJava = new Teacher("Tea cher", 34, "M", "Computer Science", 50000);
        System.out.println(mrJava);
        
        CollegeStudent ima = new CollegeStudent("Coll age", 18, "F", "UCB123", 4.0, 1, "English");
        System.out.println(ima);

    }//ends main method
}//ends Driver Class
