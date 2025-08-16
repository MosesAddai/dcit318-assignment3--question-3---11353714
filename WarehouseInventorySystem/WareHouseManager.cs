using System;

public class WareHouseManager
{
    private InventoryRepository<ElectronicItem> _electronics = new InventoryRepository<ElectronicItem>();
    private InventoryRepository<GroceryItem> _groceries = new InventoryRepository<GroceryItem>();

    // Seed sample data
    public void SeedData()
    {
        try
        {
            // Add Electronics
            _electronics.AddItem(new ElectronicItem(1, "Laptop", 10, "Dell", 24));
            _electronics.AddItem(new ElectronicItem(2, "Smartphone", 5, "Samsung", 12));
            _electronics.AddItem(new ElectronicItem(3, "Tablet", 7, "Apple", 18));

            // Add Grocery
            _groceries.AddItem(new GroceryItem(1, "Milk", 50, DateTime.Now.AddDays(7)));
            _groceries.AddItem(new GroceryItem(2, "Bread", 30, DateTime.Now.AddDays(3)));
            _groceries.AddItem(new GroceryItem(3, "Eggs", 100, DateTime.Now.AddDays(14)));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error seeding data: {ex.Message}");
        }
    }

    // Print all items in a repository
    public void PrintAllItems<T>(InventoryRepository<T> repo) where T : IInventoryItem
    {
        var items = repo.GetAllItems();
        foreach (var item in items)
        {
            if (item is ElectronicItem e)
            {
                Console.WriteLine($"[Electronics] ID: {e.Id}, Name: {e.Name}, Qty: {e.Quantity}, Brand: {e.Brand}, Warranty: {e.WarrantyMonths} months");
            }
            else if (item is GroceryItem g)
            {
                Console.WriteLine($"[Grocery] ID: {g.Id}, Name: {g.Name}, Qty: {g.Quantity}, Expiry: {g.ExpiryDate.ToShortDateString()}");
            }
        }
    }

    // Increase stock quantity
    public void IncreaseStock<T>(InventoryRepository<T> repo, int id, int quantity) where T : IInventoryItem
    {
        try
        {
            var item = repo.GetItemById(id);
            repo.UpdateQuantity(id, item.Quantity + quantity);
            Console.WriteLine($"Successfully increased stock of ID {id} by {quantity}.");
        }
        catch (DuplicateItemException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (ItemNotFoundException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (InvalidQuantityException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }

    // Remove item by ID
    public void RemoveItemById<T>(InventoryRepository<T> repo, int id) where T : IInventoryItem
    {
        try
        {
            repo.RemoveItem(id);
            Console.WriteLine($"Successfully removed item with ID {id}.");
        }
        catch (ItemNotFoundException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }

    // Access repositories
    public InventoryRepository<ElectronicItem> Electronics => _electronics;
    public InventoryRepository<GroceryItem> Groceries => _groceries;
}
