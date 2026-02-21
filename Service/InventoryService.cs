public class InventoryService
{
    private string[,] products;
    private string[,] initialStock;

    public InventoryService()
    {
        products = new string[2, 5]
        {
            { "Apples", "Watermelon", "Pineapple", "Mangoes", "Bananas" },
            { "10",     "5",           "5",        "15",      "20"  }
        };

        initialStock = new string[2, 5]
        {
            { "Apples", "Watermelon", "Pineapple", "Mangoes", "Bananas" },
            { "10",     "5",           "5",        "15",      "20"  }
        };
    }

    public string[,] GetInventory()
    {
        return products;
    }

    public string GetStock(int productIndex)
    {
        return products[1, productIndex];
    }

    public void UpdateStock(int productIndex, string newQuantity)
    {
        products[1, productIndex] = newQuantity;
    }

    public void ResetInventory()
    {
        for (int col = 0; col < products.GetLength(1); col++)
        {
            products[0, col] = initialStock[0, col];
            products[1, col] = initialStock[1, col];
        }
    }

    public int GetProductCount()
    {
        return products.GetLength(1);
    }
}
