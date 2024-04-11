namespace Storagge.Controllers
{
    public class ProductController : Controller
    {
        private StorageeDbContext _context;

        public ProductController(StorageeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _context.Products.Select(x => new ProductViewModel
            {
                Name = x.Name,
                Price = x.Price,
                Count = x.Count,
                InventoryValue = x.Price * x.Count
            }).ToListAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DetailedList()
        {
            var products = await _context.Products.ToListAsync();

            return View(products);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateOrEditProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var product = new Product
            {
                Name = model.Name,
                Price = model.Price,
                OrderDate = model.OrderDate,
                Category = model.Category,
                Shelf = model.Shelf,
                Count = model.Count,
                Description = model.Description
            };

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }
    }
}
