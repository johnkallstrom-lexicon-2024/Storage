namespace Storagge.Controllers
{
    public class ProductController : Controller
    {
        private StorageDbContext _context;

        public ProductController(StorageDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Search(string query, Category? category)
        {
            var products = _context.Products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query))
            {
                products = products.Where(x => x.Name!.Contains(query));
            }

            if (category is not null)
            {
                products = products.Where(x => x.Category.Equals(category));
            }

            var model = new SearchProductListViewModel
            {
                Query = query,
                Category = category,
                Products = await products.Select(x => new ProductViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Count = x.Count,
                    Category = x.Category,
                    InventoryValue = x.Price * x.Count
                }).ToListAsync(),
                Categories = products.Select(x => x.Category).Distinct().Select(c => new SelectListItem
                {
                    Text = c.ToString(),
                    Value = c.ToString()
                })
            };

            return View(nameof(Index), model);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new SearchProductListViewModel();

            model.Products = await _context.Products.Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Count = x.Count,
                Category = x.Category,
                InventoryValue = x.Price * x.Count
            }).ToListAsync();

            model.Categories = model.Products
                .Select(x => x.Category)
                .Distinct()
                .Select(c => new SelectListItem
                {
                    Text = c.ToString(),
                    Value = c.ToString()
                });

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
                Id = product.Id,
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

            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (product is null)
            {
                return NotFound();
            }

            product.Name = model.Name;
            product.Price = model.Price;
            product.OrderDate = model.OrderDate;
            product.Category = model.Category;
            product.Shelf = model.Shelf;
            product.Count = model.Count;
            product.Description = model.Description;

            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product is null)
            {
                return NotFound();
            }

            return View(new DeleteProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Category = product.Category
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(DeleteProductViewModel model)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (product is null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
