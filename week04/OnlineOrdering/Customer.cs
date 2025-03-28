class Customer
{
    private string name;
    private Address address;

    // Constructor
    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    // Method to check if the customer is in the USA
    public bool IsInUSA()
    {
        return address.IsInUSA();
    }

    // Method to return customer name
    public string GetName()
    {
        return name;
    }

    // Method to return customer's address
    public string GetAddress()
    {
        return address.GetFullAddress();
    }
}