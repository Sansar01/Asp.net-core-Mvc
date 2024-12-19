using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Asp.net_core_Mvc.Controllers
{
    public enum Gender
    {
        Male = 0,
        Female = 1,
    }

    public class DropdownController : Controller
    {


        public IActionResult Index()
        {
             List<SelectListItem> Gender = new()
             {
                 new SelectListItem{Value = "Male" , Text="Male"},
                 new SelectListItem{Value = "Female" , Text="Female"}
             };

            ViewBag.Gender = Gender;

            return View();
        }
    }
}
