using System;

class Program
{
    static void Main(string[] args)
    {
        // --- Order 1: USA customer ---
        Address address1 = new Address("123 Elm Street", "Springfield", "IL", "USA");
        Customer customer1 = new Customer("Mila Daniels", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "L001", 899.99, 1));
        order1.AddProduct(new Product("Wireless Mouse", "M210", 19.99, 2));

        // --- Order 2: Non-USA customer ---
        Address address2 = new Address("45 Market Road", "Lagos", "LA", "Nigeria");
        Customer customer2 = new Customer("Kunle Ade", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Headphones", "H510", 59.99, 1));
        order2.AddProduct(new Product("Microphone", "MIC22", 85.00, 1));
        order2.AddProduct(new Product("USB Cable", "USB9", 5.50, 3));

        // Display orders
        DisplayOrder(order1);
        Console.WriteLine(new string('-', 40));
        DisplayOrder(order2);
    }

    static void DisplayOrder(Order order)
    {
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order.GetTotalCost():0.00}");
    }
}