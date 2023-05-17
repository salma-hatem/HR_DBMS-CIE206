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
        public int? user_Type { get; set; }
        //[BindProperty]
        //public string Password { get; set; }
        [BindProperty]
        public int user_ID { get; set; }
        [BindProperty]
        [Required]
        public string user_email { get; set; }
        [BindProperty]
        [Required]
        public string user_password { get; set; }
        public IndexModel(ILogger<IndexModel> logger, DBManager db)
        {
            _logger = logger;
            dBManager = db;

            //user_Type = 1;
        }

        public void OnGet()
        {
            //user_password = "123456";
        }
        public IActionResult OnPost()
        {
            //user_Type = user_ID;
            /// for testing ///

            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                user_ID = dBManager.GetUserID(user_email);
                string Password = dBManager.GetPassword(user_ID);
                user_Type = dBManager.GetUserType(user_ID);
                Password = Password.Trim();
                user_password = user_password.Trim();
              
                if (user_password == Password) 
                {
                    dBManager.Login(user_ID);
                    if (user_Type == 1)
                     //   dBManager.CurrentUserID = user_ID;
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