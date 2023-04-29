using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using test_layout.Models;

namespace test_layout.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly DBManager dBManager;
        [BindProperty]
        public int user_Type { get; set; }
        //[BindProperty]
        //public string Password { get; set; }
        [BindProperty]
        [Required]
        public int user_ID { get; set; }
        [BindProperty]
        [Required]
        public string user_password { get; set; }
        public IndexModel(ILogger<IndexModel> logger, DBManager db)
        {
            _logger = logger;
            dBManager = db;

            user_Type = 1;
        }

        public void OnGet()
        {
            user_password = "123456";
        }
        public IActionResult OnPost()
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                //Password = dBManager.GetPassword(user.ID);
                //user.Type = dBManager.GetUserType(user.ID);

                if (true) //user_password == Password
                {
                    if (user_Type == 1)
                        return RedirectToPage("/Employee/Home", new { ID = user_ID });
                    else if (user_Type == 2)
                        return RedirectToPage("/PersonalMang/Home", new { ID = user_ID });
                    else if (user_Type == 3)
                        return RedirectToPage("/RecruitmentMang/Home", new { ID = user_ID });
                    else if (user_Type == 4)
                        return RedirectToPage("/TrainingMang/Home", new { ID = user_ID });
                    else
                        return Page();
                }
                else
                    return Page();
            }
            else
                return Page();
        }
    }
}