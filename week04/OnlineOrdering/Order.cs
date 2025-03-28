class Order
{
    private List<Product> products;
    private Customer customer;

    // Constructor
    public Order(List<Product> products, Customer customer)
    {
        this.products = products;
        this.customer = customer;
    }

    // Method to calculate total price of the order
    public double GetTotalPrice()
    {
        double totalProductCost = 0;
        foreach (Product product in products)
        {
            totalProductCost += product.GetTotalCost();
        }

        double shippingCost = customer.IsInUSA() ? 5 : 35;
        return totalProductCost + shippingCost;
    }

    // Method to get the packing label
    public string GetPackingLabel()
    {
        string packingLabel = "";
        foreach (Product product in products)
        {
            packingLabel += product.GetPackingLabel() + "\n";
        }
        return packingLabel.Trim();  // Remove last newline
    }

    // Method to get the shipping label
    public string GetShippingLabel()
    {
        return $"{customer.GetName()}\n{customer.GetAddress()}";
    }
}
