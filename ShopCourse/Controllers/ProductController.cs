using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ShopCourse.Interfaces;
using ShopCourse.Models;
using ShopCourse.ViewModel;
using System.Net;

namespace ShopCourse.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IPhotoService _photoService;

        public ProductController(IProductRepository productRepository, IPhotoService photoService)
        {
            _productRepository = productRepository;
            _photoService = photoService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Product> products = await _productRepository.GetAll();
            return View(products);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Product product = await _productRepository.GetByIdAsync(id);
            return View(product);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductViewModel productVM)
        {
            if (User.IsInRole("admin"))
            {
                if (ModelState.IsValid)
                {
                    var result = await _photoService.AddPhotoAsync(productVM.Image);
                    var product = new Product
                    {
                        Name = productVM.Name,
                        Discription = productVM.Discription,
                        Image = result.Url.ToString(),
                        Price = productVM.Price,
                        Quantity = productVM.Quantity,
                    };
                    _productRepository.Add(product);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Photo upload failder");
                }
            }

            return View(productVM);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var productD = await _productRepository.GetByIdAsync(id);
            if (productD == null)
            {
                return View("Error");
            }
            if (!string.IsNullOrEmpty(productD.Image)) 
            {
                    _ = _photoService.DeletePhotoAsunc(productD.Image);
            }
            _productRepository.Delete(productD);
            return RedirectToAction("Index");

    
        }
        public async Task<IActionResult> Buy(int id)
        {
            var productId = await _productRepository.GetByIdAsync(id);
            if (productId == null)
            {
                return View("Error");
            }
            else return View(productId);


        }
    }
}
