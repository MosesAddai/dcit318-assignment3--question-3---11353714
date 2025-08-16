using System;
using System.Collections.Generic;

public class InventoryRepository<T> where T : IInventoryItem
{
    private Dictionary<int, T> _items = new Dictionary<int, T>();

    // Add item to inventory
    public void AddItem(T item)
    {
        if (_items.ContainsKey(item.Id))
            throw new DuplicateItemException($"Item with ID {item.Id} already exists.");

        if (item.Quantity < 0)
            throw new InvalidQuantityException("Quantity cannot be negative.");

        _items[item.Id] = item;
    }

    // Get item by ID
    public T GetItemById(int id)
    {
        if (!_items.ContainsKey(id))
            throw new ItemNotFoundException($"Item with ID {id} not found.");

        return _items[id];
    }

    // Remove item
    public void RemoveItem(int id)
    {
        if (!_items.ContainsKey(id))
            throw new ItemNotFoundException($"Item with ID {id} not found.");

        _items.Remove(id);
    }

    // Get all items
    public List<T> GetAllItems()
    {
        return new List<T>(_items.Values);
    }

    // Update quantity
    public void UpdateQuantity(int id, int newQuantity)
    {
        if (!_items.ContainsKey(id))
            throw new ItemNotFoundException($"Item with ID {id} not found.");

        if (newQuantity < 0)
            throw new InvalidQuantityException("Quantity cannot be negative.");

        _items[id].Quantity = newQuantity;
    }
}
