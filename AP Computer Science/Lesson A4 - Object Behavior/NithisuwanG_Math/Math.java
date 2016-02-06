//Gosone Nithisuwan
//P3
// The program generates two single-digit integers and displays a question using them in addition.

import java.util.*;

public class Math 
{
    int number1;
    int number2;
    Random number = new Random();
    Scanner getAnswer = new Scanner(System.in);
    int answer;
    
    public Math()
    {
        //sets number1 and number2 as a random number from 0 to 9.
        number1 = number.nextInt(10);
        number2 = number.nextInt(10);
        
    }
    
    
    public void draw()
    {
        //gets the user input   
        System.out.println("What is " + number1 + "+" + number2);
        try // Checsk if the user did not enter an integer
        {
            answer = getAnswer.nextInt();
        } catch ( InputMismatchException e)
        {
            System.out.println("You did not enter an integer");
        }
        
        //replies to the user input if they got the problem right or not
        if (answer == number1 + number2)
        {
            System.out.println("You got it right!");
            
        }
        else
        {
            System.out.println("You failed.");
            
        }
        
    }
}


