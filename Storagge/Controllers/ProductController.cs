namespace Storagge.Controllers
{
    public class ProductController : Controller
    {
        private StorageeDbContext _context;

        public ProductController(StorageeDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.ToListAsync();

            return View(products);
        }
    }
}
