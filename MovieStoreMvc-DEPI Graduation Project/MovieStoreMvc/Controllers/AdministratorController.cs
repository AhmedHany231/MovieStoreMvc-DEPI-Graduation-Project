using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieStoreMvc.Models.ViewModels.Adminstration;

namespace WebApplication1.Controllers
{
	[Authorize(Roles = "AdminsRole")]
	public class AdministratorController : Controller
	{
		private RoleManager<IdentityRole> _roleManager;
		private UserManager<IdentityUser> _userManager;

		public AdministratorController(RoleManager<IdentityRole> roleManager,
			UserManager<IdentityUser> userManager)
		{
			_roleManager = roleManager;
			_userManager = userManager;
		}
		#region Role
		public async Task<IActionResult> GetAllRoles()
		{
			var roles = await _roleManager.Roles.Select(r => new RoleViewModel
			// de tareqa tanya brdo ashl
			{
				Id = r.Id,
				RoleName = r.Name
			}).ToListAsync();
			// de tareqet l mapping wa tb3n fe l return view htrg3 l rolelist
			//List<RoleViewModel> rolelist = new List<RoleViewModel>();
			//         foreach (var role in roles)
			//         {
			//	RoleViewModel roleviewmodel = new RoleViewModel { Id = role.Id, RoleName = role.Name };
			//	rolelist.Add(roleviewmodel);
			//         }

			return View("Roles", roles);
		}
		public async Task<IActionResult> CreateRole()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateRole(RoleViewModel item)
		{
			if (ModelState.IsValid)
			{
				var newrole = new IdentityRole()
				{
					Id = Guid.NewGuid().ToString(),
					Name = item.RoleName
				};
				var result = await _roleManager.CreateAsync(newrole);
				if (result.Succeeded)
				{
					return RedirectToAction("GetAllRoles");
				}
				foreach (var errors in result.Errors)
				{
					ModelState.AddModelError(string.Empty, errors.Description);
				}
			}
			return View(item);
		}
		#endregion

		#region User
		public async Task<IActionResult> GetAllUsers()
		{
			var user = await _userManager.Users.Select(u => new UserViewModel()
			{
				Id = u.Id,
				UserName = u.UserName,
				Email = u.Email,
				Roles = _userManager.GetRolesAsync(u).Result
			}).ToListAsync();
			return View("UsersList", user);
		}
		public async Task<IActionResult> ManageRoles(string userId)
		{
			var user = await _userManager.FindByIdAsync(userId);
			if (user == null)
			{
				return RedirectToAction("GetAllUsers");
			}
			var roles = await _roleManager.Roles.ToListAsync();

			var model = new UserRolesViewModel()
			{
				UserId = user.Id,
				UserName = user.UserName,
				Email = user.Email,
				UserRoles = roles.Select(r => new RolesCheckedViewModel()
				{
					Role = r.Name,
					isSelected = _userManager.IsInRoleAsync(user, r.Name).Result
				}).ToList()
			};
			return View(model);
		}

		public async Task<IActionResult> UpdateRoles(UserRolesViewModel model)
		{
			var user = await _userManager.FindByIdAsync(model.UserId);
			if (user == null)
			{
				return RedirectToAction("GetAllUsers");
			}
			var userroles = await _userManager.GetRolesAsync(user);
			await _userManager.RemoveFromRolesAsync(user, userroles);
			await _userManager.AddToRolesAsync(user, model.UserRoles.Where(r => r.isSelected).Select(n => n.Role).ToList());
			return RedirectToAction("GetAllUsers");
		}
		public async Task<IActionResult> ChangePassword()
		{
			return View();
		}
		#endregion
	}
}
