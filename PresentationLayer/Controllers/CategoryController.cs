using BusinessLogicLayer.ServiceContracts;
using BusinessLogicLayer.ServiceContracts.DTO;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.ViewModels;

namespace PresentationLayer.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoriesService _categoriesService;
        public CategoryController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        public async Task<IActionResult> Index()
        {
           

            List<CategoryResponse> categories = await _categoriesService.GetAllCategories();
            CategoryViewModel viewModel = new CategoryViewModel();

            viewModel.categoryResponse = categories;
            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CategoryAddRequest? categoryAddRequest)
        {
            if (categoryAddRequest != null)
            {
                CategoryResponse? response = await _categoriesService.AddCategory(categoryAddRequest);
            }

            return RedirectToAction ("Index");
        }



        [HttpGet]
        public async Task<IActionResult> Edit(Guid ID)
        {
            List<CategoryResponse> categories = await _categoriesService.GetAllCategories();

            CategoryResponse? categoryResponse = await _categoriesService.GetCategoryByID(ID);
            if(categoryResponse == null)return RedirectToAction("Index");

            CategoryUpdateRequest categoryUpdateRequest = categoryResponse.ToCategoryUpdateRequest();


            CategoryViewModel viewModel = new CategoryViewModel();

            viewModel.categoryResponse = categories;
            viewModel.categoryUpdateRequest = categoryUpdateRequest;

            return View(viewModel);
        }



        [HttpPost]
        public async Task<IActionResult> Edit(CategoryUpdateRequest categoryUpdateRequest)
        {

            CategoryResponse? categoryResponse = await _categoriesService.GetCategoryByID(categoryUpdateRequest.ID);

            if (categoryResponse == null) 
            {
                return RedirectToAction("Index");
            }

            CategoryResponse? updateCategory  = await _categoriesService.UpdateCategory(categoryUpdateRequest);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid ID)
        {
            await _categoriesService.DeleteCategoryByID(ID);
            return RedirectToAction("Index");
        }



    }
}
