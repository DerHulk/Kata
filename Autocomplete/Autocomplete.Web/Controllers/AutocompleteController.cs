using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Autocomplete.Web.Controllers
{
    public class AutocompleteController : Controller
    {
        [HttpPost]
        public ActionResult Propose(string input)
        {
            if (string.IsNullOrEmpty(input))
                input = string.Empty;

            var auto = new Autocomplete.AutocompleteParser();
            var result = auto.Propose(input);

            return Json(result);
        }
    }
}