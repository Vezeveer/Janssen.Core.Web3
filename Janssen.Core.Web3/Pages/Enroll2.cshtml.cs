﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Janssen.Core.Web3.Pages
{
    public class Enroll2Model : PageModel
    {
        public ActionResult OnPost()
        {
            return RedirectToPage("/login/index");
        }
    }
}