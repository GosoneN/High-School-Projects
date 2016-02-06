public class CheckingAccount{
  private double myBalance;
  private int myAccountNumber;

  /**
   * Constructor
   */
  public CheckingAccount(){
    myBalance = 0.0;
    myAccountNumber = 0;
  }//ends CheckingAccount() 

  /**
   * Constructor
   */
  public CheckingAccount(double initialBalance, int acctNum){
    myBalance = initialBalance;
    myAccountNumber = acctNum;
    
    if (myBalance < 0)
    {
        try
        {
            throw new IllegalArgumentException("myBalance is less than zero");
        }//ends try statement
        catch (IllegalArgumentException e)
        {
            System.out.println("You cannot start with a negative balance");
        }//ends catch statement
    }//ends if statement
    
   }//ends CheckingAccount

  /**
   * Gets myBalance
   * 
   * @Pre: myBalance
   * @Parameter: None
   * @Return: Double
   * @Post: Returns myBalance
   */
  public double getBalance(){
    return myBalance;
  }//ends getBalance()
  
  /**
   * Adds an integer to balance
   * 
   * @Pre: myBalance
   * @Parameter: amount
   * @Return: Void
   * @Post: Adds to balance
   */
  public void deposit(double amount){
    if (amount < 0)
    {
        try
        {
            throw new IllegalArgumentException("Error!");
        }//ends try statement
        catch (IllegalArgumentException e)
        {
            System.out.println("Cannot add a negative number");
        }//ends catch statement
    }//ends if statement
      myBalance += amount;
  }//ends deposit() method

  /**
   * Withdraws an integer from the balance
   * 
   * @Pre: myBalance
   * @Parameter: amount
   * @Return: Void
   * @Post: Withdraw from balance
   */
  public void withdraw( double amount ){
    myBalance -= amount;
    
    if (myBalance < 0)
    {
        try
        {
            throw new IllegalArgumentException("Error!");
        }//ends try statement
        catch (IllegalArgumentException e)
        {
            System.out.println("Cannot overwithdraw");
        }//ends catch statement
    }//ends if statement
  }//ends withdraw() method
}//ends CheckingAccount class

