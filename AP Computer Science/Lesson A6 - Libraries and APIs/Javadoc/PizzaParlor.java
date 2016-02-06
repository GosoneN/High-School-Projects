/**
 	* class PizzaParlor - a class used to demonstrate
 	* the construction of a class, including
	* constructors, methods and instance variables
 	* @author P. Pie
 	* @version 1.1
 	*/


class PizzaParlor 
{
  // instance variables
  
  /** holds the name of the restaurant owner*/
  private String myName;
  /** # of cheese pizzas ordered*/
  private int myNumCheesePizzas; 
  /** # of pepperoni pizzas ordered*/
  private int myNumPeppPizzas;
  /** # of veggie pizzas ordered */
  private int myNumVegPizzas;
  /** ounces of cheese in the inventory */
  private int myCheeseSupply;
  /** ounces of pepperoni in the inventory*/
  private int myPepperoniSupply;
  /** ounces of veggies in the inventory*/
  private int myVeggieSupply;
  /** dollars collected */
  private double myRevenue;
  /** dollars in bank account */ 
  private double myBankAccount;

  // constructor
 /**
 	* constructor PizzaParlor - a class used to demonstrate
 	* the construction of a class, including
	* constructors, methods and instance variables
 	* 
 	*/ 
  PizzaParlor(String name)
  {
    myName = name;
    myNumCheesePizzas = 0;
    myNumPeppPizzas = 0;
    myNumVegPizzas = 0;
    myCheeseSupply = 400;  
    myPepperoniSupply = 200;
    myVeggieSupply = 200;
    myRevenue = 0; 
    myBankAccount = 1000;
  }


  /**
  	* <b>summary</b>: provides a method ordering cheese pizzas -
  	* this updates myRevenue, myBankAccount and 
  	* maintains the cheese inventory (myCheeseSupply).
  	* 
  	*/  
   
  void orderCheese()
  {
    myNumCheesePizzas++;
   
    myRevenue += 8; //cheese pizza price:$8
    myBankAccount += 8;
    myCheeseSupply -= 12;//cheese needed per cheese pizza
  }
  
/**
  	* <b>summary</b>: provides a method ordering pepperoni pizzas -
  	* this updates myRevenue, myBankAccount and 
  	* maintains the cheese inventory (myCheeseSupply) as well
  	* as the pepperoni inventory (myPepperoniSupply)
  	*/
  	
  void orderPepperoni()
  {
    myNumPeppPizzas++;
    myRevenue += 10;//pepperoni pizza price:$10
    myBankAccount +=10;
    myCheeseSupply -= 8;//cheese needed per pepp pizza
    myPepperoniSupply -= 6;//pepperoni needed per pepp pizza
  }

  void orderVeggie()
  {
    myNumVegPizzas++;
    myRevenue += 11;//veggie pizza price:$11
    myBankAccount += 11;
    myCheeseSupply -= 8;//cheese needed per veggie pizza
    myVeggieSupply -= 12;//veggies needed per veggie pizza
  }

  String getName()
  {
    return myName;
  }

  int getNumCheesePizzas()
  {
    return myNumCheesePizzas;
  }
/**
  	* <b>summary</b>: provides a method for obtaining the number
  	* of pepperoni pizzas ordered by returning the instance variable
  	* myNumPeppPizzas
  	* 
  	* @return myNumPeppPizzas the total # of pepp pizzas ordered
  	*/
  int getNumPepperoniPizzas()
  {
    return myNumPeppPizzas;
  }

  int getNumVeggiePizzas()
  {
    return myNumVegPizzas;
  }

  int getCheeseSupply()
  {
    return myCheeseSupply;
  }

  int getPepperoniSupply()
  {
    return myPepperoniSupply;
  }

  int getVeggieSupply()
  {
    return myVeggieSupply;
  }

  double getRevenueTotal()
  {
    return myRevenue;
  }

  double getBankAccountBalance()
  {
    return myBankAccount;
  }
}

