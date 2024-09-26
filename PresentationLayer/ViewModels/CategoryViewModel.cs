using BusinessLogicLayer.ServiceContracts.DTO;
using DataAccessLayer.Entities;

namespace PresentationLayer.ViewModels
{
    public class CategoryViewModel
    {
        public Category? Category { get; set; }
        public List<Category>? Categories { get; set; }
        public CategoryAddRequest? categoryAddRequest { get; set; }
        public List<CategoryResponse?> categoryResponse { get; set; }
        public CategoryUpdateRequest? categoryUpdateRequest { get; set; }
    }
}
