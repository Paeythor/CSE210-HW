using System;

class Program
{
    static void Main(string[] args)
    {
        // Create address instances
        Address address1 = new Address("16 Montana Dr", "Champion", "CA", "USA");
        Address address2 = new Address("8 Young Dr", "Champion", "CA", "USA");
        Address address3 = new Address("7 Flutie Dr", "Edmonton", "AB", "CA");

        // Create customer instances
        Customer customer1 = new Customer("Joe Montana", address1);
        Customer customer2 = new Customer("Steve Young", address2);
        Customer customer3 = new Customer("Doug Flutie", address3);

        // Create product instances
        Product product1 = new Product("Laptop", 101, 1200, 1);
        Product product2 = new Product("Mouse", 102, 25, 2);
        Product product3 = new Product("Keyboard", 103, 50, 1);

        // Create order instances
        List<Product> products1 = new List<Product> { product1 };
        List<Product> products2 = new List<Product> { product2 };
        List<Product> products3 = new List<Product> { product3 };

        Order order1 = new Order(products1, customer1);
        Order order2 = new Order(products2, customer2);
        Order order3 = new Order(products3, customer3);

        // Display the packing label, shipping label, and total price for both orders
        Console.WriteLine("Order 1:");
        Console.WriteLine("Packing Label:\n" + order1.GetPackingLabel());
        Console.WriteLine("Shipping Label:\n" + order1.GetShippingLabel());
        Console.WriteLine("Total Price: $" + order1.GetTotalPrice());

        Console.WriteLine("\nOrder 2:");
        Console.WriteLine("Packing Label:\n" + order2.GetPackingLabel());
        Console.WriteLine("Shipping Label:\n" + order2.GetShippingLabel());
        Console.WriteLine("Total Price: $" + order2.GetTotalPrice());

        Console.WriteLine("\nOrder 3:");
        Console.WriteLine("Packing Label:\n" + order3.GetPackingLabel());
        Console.WriteLine("Shipping Label:\n" + order3.GetShippingLabel());
        Console.WriteLine("Total Price: $" + order3.GetTotalPrice());
    }
}