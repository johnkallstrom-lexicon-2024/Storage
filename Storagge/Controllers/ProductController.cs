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
            var model = await _context.Products.OrderByDescending(x => x.Id).Select(x => new ProductViewModel
            {
                Id = x.Id,
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
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateOrEditProductViewModel model)
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

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product is null)
            {
                return NotFound();
            }

            var model = new CreateOrEditProductViewModel
            {
                Name = product.Name,
                Price = product.Price,
                OrderDate = product.OrderDate,
                Category = product.Category,
                Shelf = product.Shelf,
                Count = product.Count,
                Description = product.Description
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CreateOrEditProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View();
        }
    }
}
