import java.util.*;
/**
 * Asks the user for an inteeger and adds the totals of them.
 * 
 * @Gosone Nithisuwan
 * @P5
 * feedback: Yes
 */



public class GroceryList
{
    // instance variables - replace the example below with your own
    private Scanner sc;
    private double dblCost;

    /**
     * Constructor for objects of class GroceryList
     */
    public GroceryList()
    {
        // initialise instance variables
        sc = new Scanner(System.in);
        dblCost =0.0;
    }//ends GroceryList method.

    /**
     * Asks the user for the input and calculates the total.
     * 
     * @param  None
     * @return dbleCost
     */
    public double getCost()
    {
        double cost1;
        double cost2;
        double cost3;
        double cost4;
        double cost5;
        //asks the user input
        System.out.printf("%10s","Enter item #1: ");
        cost1 = sc.nextDouble();
        
        
        System.out.printf("%10s","Enter item #2: ");
        cost2 = sc.nextDouble();
        
        
        System.out.printf("%10s","Enter item #3: ");
        cost3 = sc.nextDouble();
        
        
        System.out.printf("%10s","Enter item #4: ");
        cost4 = sc.nextDouble();
        
        
        System.out.printf("%10s","Enter item #5: ");
        cost5 = sc.nextDouble();
        
        //prints out cost
        System.out.printf("%-10s","Item:");
        System.out.printf("%5s","Cost:");
        System.out.printf("%11s","Total:\n");
        System.out.printf("%-10s","#1");
        System.out.printf("%5s",cost1);
        System.out.printf("%10s",cost1+"\n");
        System.out.printf("%-10s","#2");
        System.out.printf("%5s",cost2);
        System.out.printf("%10s",cost1+cost2+"\n");
        System.out.printf("%-10s","#3");
        System.out.printf("%5s",cost3);
        System.out.printf("%10s",cost1+cost2+cost3+"\n");
        System.out.printf("%-10s","#4");
        System.out.printf("%5s",cost4);
        System.out.printf("%10s",cost1+cost2+cost3+cost4+"\n");
        System.out.printf("%-10s","#5");
        System.out.printf("%5s",cost5);
        System.out.printf("%10s",cost1+cost2+cost3+cost4+cost5+"\n");
        

        return dblCost;
    }//ends getCost() method
    
    

}//ends GroceryList class
