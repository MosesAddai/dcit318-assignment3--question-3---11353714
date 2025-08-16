using System;

class Program
{
    static void Main()
    {
        // i. Instantiate WareHouseManager
        var warehouse = new WareHouseManager();

        // ii. Call SeedData()
        warehouse.SeedData();

        // iii. Print all grocery items
        Console.WriteLine("=== Grocery Inventory ===");
        warehouse.PrintAllItems(warehouse.Groceries);

        // iv. Print all electronic items
        Console.WriteLine("\n=== Electronics Inventory ===");
        warehouse.PrintAllItems(warehouse.Electronics);

        // v. Try invalid operations
        Console.WriteLine("\n=== Testing Exceptions ===");

        // 1. Add a duplicate item
        try
        {
            Console.WriteLine("\nAdding duplicate Electronics item (ID = 1)...");
            warehouse.Electronics.AddItem(new ElectronicItem(1, "Laptop", 10, "Dell", 24));
        }
        catch (DuplicateItemException ex)
        {
            Console.WriteLine($"Caught DuplicateItemException: {ex.Message}");
        }

        // 2. Remove a non-existent item
        try
        {
            Console.WriteLine("\nRemoving non-existent Grocery item (ID = 99)...");
            warehouse.RemoveItemById(warehouse.Groceries, 99);
        }
        catch (ItemNotFoundException ex)
        {
            Console.WriteLine($"Caught ItemNotFoundException: {ex.Message}");
        }

        // 3. Update with invalid quantity
        try
        {
            Console.WriteLine("\nUpdating Electronics item (ID = 2) with negative quantity...");
            warehouse.Electronics.UpdateQuantity(2, -5);
        }
        catch (InvalidQuantityException ex)
        {
            Console.WriteLine($"Caught InvalidQuantityException: {ex.Message}");
        }

        Console.WriteLine("\n=== Final Inventory State ===");
        Console.WriteLine("\nGrocery Inventory:");
        warehouse.PrintAllItems(warehouse.Groceries);

        Console.WriteLine("\nElectronics Inventory:");
        warehouse.PrintAllItems(warehouse.Electronics);
    }
}
