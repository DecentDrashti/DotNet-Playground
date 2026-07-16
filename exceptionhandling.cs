using System;

interface IInventoryManager
{
    void ManageStock(int quantity);
}

class GroceryStock : IInventoryManager
{
    public void ManageStock(int quantity)
    {
        if(quantity < 0)
        {
            throw new Exception(
                "Invalid Stock");
        }

        Console.WriteLine(
            "Grocery Stock Updated");
    }
}

class ElectronicStock : IInventoryManager
{
    public void ManageStock(int quantity)
    {
        if(quantity < 0)
        {
            throw new Exception(
                "Invalid Stock");
        }

        Console.WriteLine(
            "Electronic Stock Updated");
    }
}

class Program
{
    static void Main()
    {
        try
        {
            GroceryStock g =
                new GroceryStock();

            g.ManageStock(-5);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}






















try
{
    Console.Write("Enter Number 1: ");
    int num1 = Convert.ToInt32(Console.ReadLine());

    Console.Write("Enter Number 2: ");
    int num2 = Convert.ToInt32(Console.ReadLine());

    int result = num1 / num2;

    Console.WriteLine(result);
}
catch(DivideByZeroException)
{
    Console.WriteLine("Cannot divide by zero");
}