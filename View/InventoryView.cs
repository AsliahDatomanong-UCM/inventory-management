public class InventoryView
{
    private InventoryService _inventoryService;

    public InventoryView()
    {
        _inventoryService = new InventoryService();
    }

    public void Run()
    {
        bool running = true;

        while (running)
        {
            DisplayMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ViewInventory();
                    break;
                case "2":
                    UpdateStock();
                    break;
                case "3":
                    ResetInventory();
                    break;
                case "4":
                    running = false;
                    Console.WriteLine("Exiting program. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please select 1-4.");
                    break;
            }

            Console.WriteLine();
        }
    }

    private void DisplayMenu()
    {
        Console.WriteLine("=== Inventory Management System ===");
        Console.WriteLine("1. View Inventory");
        Console.WriteLine("2. Update Stock");
        Console.WriteLine("3. Reset Inventory");
        Console.WriteLine("4. Exit");
        Console.Write("Select an option: ");
    }

    private void ViewInventory()
    {
        string[,] products = _inventoryService.GetInventory();
        int productCount = _inventoryService.GetProductCount();

        Console.WriteLine("\n--- Current Inventory ---");
        for (int i = 0; i < productCount; i++)
        {
            Console.WriteLine($"Product: {products[0, i],-10} | Stock: {products[1, i]}");
        }
        Console.WriteLine("-------------------------");
    }

    private void UpdateStock()
    {
        string[,] products = _inventoryService.GetInventory();
        int productCount = _inventoryService.GetProductCount();

        Console.WriteLine("\n--- Update Stock ---");
        Console.WriteLine("Select a product:");

        for (int i = 0; i < productCount; i++)
        {
            Console.WriteLine($"{i + 1}. {products[0, i]} (Current Stock: {products[1, i]})");
        }

        Console.Write("Enter product number: ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int productNumber) &&
            productNumber >= 1 && productNumber <= productCount)
        {
            int index = productNumber - 1;
            Console.Write($"Enter new stock quantity for {products[0, index]}: ");
            string newQuantity = Console.ReadLine();

            _inventoryService.UpdateStock(index, newQuantity);
            Console.WriteLine($"Stock for {products[0, index]} updated to {newQuantity}.");
        }
        else
        {
            Console.WriteLine("Invalid product selection.");
        }
    }

    private void ResetInventory()
    {
        _inventoryService.ResetInventory();
        Console.WriteLine("\nInventory has been reset to original values.");
        ViewInventory();
    }
}
