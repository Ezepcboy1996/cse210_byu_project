using System;
using System.Collections.Generic;

class Product
{
    private string name;
    private string productId;
    private double price;
    private int quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public string GetName() => name;
    public string GetProductId() => productId;
    public double GetPrice() => price;
    public int GetQuantity() => quantity;

    public double GetTotalCost()
    {
        return price * quantity;
    }
}

class Address
{
    private string street;
    private string city;
    private string stateOrProvince;
    private string country;

    public Address(string street, string city, string stateOrProvince, string country)
    {
        this.street = street;
        this.city = city;
        this.stateOrProvince = stateOrProvince;
        this.country = country;
    }

    public bool IsInNIGERIA()
    {
        return country.Trim().ToUpper() == "USA";
    }

    public string GetFullAddress()
    {
        return $"{street}\n{city}, {stateOrProvince}\n{country}";
    }
}

class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public string GetName() => name;
    public Address GetAddress() => address;

    public bool LivesInNIGERIA()
    {
        return address.IsInNIGERIA();
    }
}

class Order
{
    private List<Product> products = new List<Product>();
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public double GetTotalPrice()
    {
        double total = 0;
        foreach (var product in products)
        {
            total += product.GetTotalCost();
        }

        // Add shipping cost
        total += customer.LivesInNIGERIA() ? 5 : 35;
        return total;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in products)
        {
            label += $"{product.GetName()} (ID: {product.GetProductId()})\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{customer.GetName()}\n{customer.GetAddress().GetFullAddress()}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create addresses
        Address address1 = new Address("123 Ogba St", "Lagos", "LA", "Nigeria");
        Address address2 = new Address("45 Umukalika St", "Abia", "AB", "Nigeria");

        // Create customers
        Customer customer1 = new Customer("Prosper Eze", address1);
        Customer customer2 = new Customer("Alice Okon", address2);

        // Create orders
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("iphone17", "P001", 500000.00, 1));
        order1.AddProduct(new Product("shoes", "P002", 7500.00, 2));

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("T-Shirt", "P003", 3500.00, 3));
        order2.AddProduct(new Product("Headphones", "P004", 25000.00, 1));

        // Display results
        List<Order> orders = new List<Order> { order1, order2 };

        foreach (var order in orders)
        {
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"Total Price: ₦{order.GetTotalPrice():N2}");
            Console.WriteLine("=====================================\n");
        }
    }
}
