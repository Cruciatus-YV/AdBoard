using AdBoard.AppServices.Contexts.Category.Services;
using AdBoard.AppServices.Contexts.Product.Services;
using AdBoard.AppServices.Contexts.User.Services;
using AdBoard.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace AdBoard.WebAPI.Controllers
{
    public class SuperAdminController : AdBoardBaseController
    {
        private readonly IUserService _userService;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public SuperAdminController(IUserService userService,
                                    IProductService productService,
                                    ICategoryService categoryService)
        {
            _userService = userService;
            _productService = productService;
            _categoryService = categoryService;
        }
    }
}
