class Product
{
    private string name;
    private int productId;
    private double price;
    private int quantity;

    // Constructor
    public Product(string name, int productId, double price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    // Method to calculate total cost for this product
    public double GetTotalCost()
    {
        return price * quantity;
    }

    // Method to return the product info for packing label
    public string GetPackingLabel()
    {
        return $"{name} (ID: {productId})";
    }
}