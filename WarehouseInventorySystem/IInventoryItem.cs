public interface IInventoryItem
{
    int Id { get; }          // Unique identifier
    string Name { get; }     // Name of the product
    int Quantity { get; set; } // Quantity in stock
}
