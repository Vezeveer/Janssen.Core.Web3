using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Janssen.Core.Web3.Pages
{
    public class LogoutModel : PageModel
    {
        public ActionResult OnPost()
        {
            return RedirectToPage("/login/index");
        }
    }
}