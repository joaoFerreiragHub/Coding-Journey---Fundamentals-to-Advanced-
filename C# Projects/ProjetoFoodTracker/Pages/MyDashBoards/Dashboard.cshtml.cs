using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetoFoodTracker.Services.UserServices;


namespace ProjetoFoodTracker.Pages.MyDashBoards
{
    [Authorize(Roles = "Admin")]
    public class DashboardModel : PageModel
    {
        private readonly IUserService _userService;
        public DashboardModel(IUserService userService)
        {
            _userService = userService;
        }

        public int AppUser { get; set; }
        public int MealsCount { get; set; }
        public string TopFoods { get; set; }  
        public List<string> TopUsersMeals { get; set; }

        public async Task<IActionResult> OnGet()
        {
            AppUser = await _userService.GetTotalCustomersCount();
            MealsCount = await _userService.GetTotalMealsCount();
            TopFoods = await _userService.GetTopFoods();
            TopUsersMeals = await _userService.GetTopUsersMeals();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {

                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}


