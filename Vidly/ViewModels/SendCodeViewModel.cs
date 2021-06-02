﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using System.Web;

namespace Vidly.ViewModels
{
     public class SendCodeViewModel
     {
         public string SelectedProvider { get; set; }
         public ICollection<SelectListItem> Providers { get; set; }
         public string ReturnUrl { get; set; }
         public bool RememberMe { get; set; }
     }

}