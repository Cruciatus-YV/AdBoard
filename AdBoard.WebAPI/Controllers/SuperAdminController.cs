using AdBoard.AppServices.Contexts.Category.Services;
using AdBoard.AppServices.Contexts.Product.Services;
using AdBoard.AppServices.Contexts.Store.Repositories;
using AdBoard.AppServices.Contexts.User.Services;
using AdBoard.AppServices.Exceptions;
using AdBoard.Contracts.Enums;
using AdBoard.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AdBoard.WebAPI.Controllers
{
    public class SuperAdminController : AdBoardBaseController
    {
        private readonly IUserService _userService;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly UserManager<UserEntity> _userManager;
        private readonly IStoreRepository _storeRepository;

        public SuperAdminController(IUserService userService,
                                    IProductService productService,
                                    ICategoryService categoryService,
                                    UserManager<UserEntity> userManager,
                                    IStoreRepository storeRepository)
        {
            _userService = userService;
            _productService = productService;
            _categoryService = categoryService;
            _userManager = userManager;
            _storeRepository = storeRepository;
        }

        [HttpPost("change-user-role/{id}")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> ChangeUserRole(string id, string newRole, CancellationToken cancellationToken)
        {
            var ctx = GetUserContextLigth();

            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                throw new NotFoundException("Пользователь не найден");
            }

            var roles = await _userManager.GetRolesAsync(user);

            await _userManager.RemoveFromRolesAsync(user, roles);

            await _userManager.AddToRoleAsync(user, newRole);

            return Ok();
        }

        [HttpPost("change-store-status/{id}")]
        [Authorize(Roles = "SuperAdmin, SuperManager")]
        public async Task<IActionResult> ChangeStoreStatus(long id, StoreStatus newStoreStatus, CancellationToken cancellationToken)
        {
            var store = await _storeRepository.GetByIdAsync(id, cancellationToken);

            if (store == null)
            {
                throw new NotFoundException("Магазин не найден");
            }

            store.Status = newStoreStatus;

            await _storeRepository.UpdateAsync(store, cancellationToken);

            return Ok();
        }
    }
}
