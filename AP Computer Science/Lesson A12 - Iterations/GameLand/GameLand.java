
/**
 * Write a description of class GameLand here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */

import java.util.*;

public class GameLand
{
    // instance variables - replace the example below with your own
    private final int intMyStart; 
    private final int intMyFinish;
    
    int intMyPlayer1;
    int intMyPlayer2;
    
    Random randomDice;
    
    /*
     * Constructor
     * 
     * Pre: Decalre variables
     * Param: None
     * Return: None
     * Post: Initialize Variables
     */
    public GameLand()
    {
        intMyStart = 0;
        intMyFinish = 100;
        randomDice = new Random();
        
        intMyPlayer1 = intMyStart;
        intMyPlayer2 = intMyStart;
        
        playerTurn();
    }//ends GameLand Constructor
   
    /*
     * Does both of the player's turns
     * 
     * Pre:Methods and Variables
     * Param: None
     * Return: Void
     * Post: Game Finishes
     */
    public void playerTurn()
    {

        while((intMyPlayer1 < intMyFinish) && (intMyPlayer2 < intMyFinish))
        {
            playerOne();
            System.out.println("Player 1 is at " + intMyPlayer1);
            playerTwo();
            System.out.println("Player 2 is at " + intMyPlayer2);
        }//ends while loop
        
        if ( intMyPlayer1 >= intMyFinish)
        {
            System.out.println("Player 1 has won!");
        }//ends if statement
        if ( intMyPlayer2 >= intMyFinish)
        {
            System.out.println("Player 2 has won!");
        }//ends if statement
    }//ends playerTurn() method
    
    /*
     * Player 1's turn
     * 
     * Pre: Variable and rollDice()
     * Param: None
     * Return: Int
     * Post: Player 1 has moved
     */
    public int playerOne()
    {
        int intTempDice = rollDice();
        System.out.println("Player 1's turn!");
        System.out.println("Player 1 rolls a " + intTempDice + ".");
        
        if (intTempDice == 2 || intTempDice == 12)
        {
           System.out.println("Player 1 lost a turn."); 
        }
        else if (intTempDice == 7)
        {
            System.out.println("Player 1 moves back 7 spaces.");
        }
        else
        {
            System.out.println("Player 1 moves " + intTempDice + " spaces.");
            intMyPlayer1 += intTempDice;
        }//ends if-else statement
        
        if (intMyPlayer1 == intMyPlayer2)
        {
            intMyPlayer2 = intMyStart;
        }//ends if statement
        
        return intMyPlayer1;
    }//ends playerOne() method
    
    /*
     * Player 2's turn
     * 
     * Pre: Variable and rollDice()
     * Param: None
     * Return: Int
     * Post: Player 2 has moved
     */
        public int playerTwo()
    {
        int intTempDice = rollDice();
        System.out.println("Player 2's turn!");
        System.out.println("Player 2 rolls a " + intTempDice + ".");
        
        if (intTempDice == 2 || intTempDice == 12)
        {
           System.out.println("Player 2 lost a turn."); 
        }
        else if (intTempDice == 7)
        {
            System.out.println("Player 2 moves back 7 spaces.");
        }
        else
        {
            System.out.println("Player 2 moves " + intTempDice + " spaces.");
            intMyPlayer2 += intTempDice;
        }//ends if-else statement
        
        
        if (intMyPlayer2 == intMyPlayer1)
        {
            intMyPlayer1 = intMyStart;
        }//ends if statement
        
        return intMyPlayer2;
    }//ends playerTwo() method
    
    /*
     * Returns a random number beteeen 2 and 12
     * 
     * Pre: Needs Random variable
     * Param: None
     * Return: Int
     * Post: Returns random number
     */
    public int rollDice()
    {
        return (randomDice.nextInt(6) + 1) + (randomDice.nextInt(6) + 1);
    }//ends rollDcie() method
}
