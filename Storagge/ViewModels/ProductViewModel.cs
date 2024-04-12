namespace Storagge.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
        [DisplayName("Amount")]
        public int Count { get; set; }
        public string? Category { get; set; }
        [DisplayName("Inventory value")]
        public int InventoryValue { get; set; }
    }
}
