using Janssen.Core.Web3.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

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