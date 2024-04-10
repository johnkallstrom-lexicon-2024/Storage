using System.ComponentModel;

namespace Storagge.ViewModels
{
    public class ProductViewModel
    {
        public string? Name { get; set; }
        public int Price { get; set; }
        [DisplayName("Amount")]
        public int Count { get; set; }
        [DisplayName("Total inventory value")]
        public int InventoryValue { get; set; }
    }
}
