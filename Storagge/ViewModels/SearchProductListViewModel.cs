namespace Storagge.ViewModels
{
    public class SearchProductListViewModel
    {
        public Category? Category { get; set; }
        public string? Query { get; set; }
        public IEnumerable<ProductViewModel> Products { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }

        public SearchProductListViewModel()
        {
            Products = new List<ProductViewModel>();
            Categories = new List<SelectListItem>();
        }
    }
}
