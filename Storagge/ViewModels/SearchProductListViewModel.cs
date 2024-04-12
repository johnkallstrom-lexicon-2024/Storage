namespace Storagge.ViewModels
{
    public class SearchProductListViewModel
    {
        public string? Query { get; set; }
        public IEnumerable<ProductViewModel> Products { get; set; }

        public SearchProductListViewModel()
        {
            Products = new List<ProductViewModel>();
        }
    }
}
