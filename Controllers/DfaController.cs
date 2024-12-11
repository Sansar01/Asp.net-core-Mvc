using Asp.net_core_Mvc.Models.DFA;
using Microsoft.AspNetCore.Mvc;

namespace Asp.net_core_Mvc.Controllers
{
    public class DfaController : Controller
    {
        private readonly DotNetDbContext dotNetDbContext;

        public IActionResult List()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> List(Student std)
        {
            if (ModelState.IsValid)
            {
                await dotNetDbContext.Students.AddAsync(std);
                await dotNetDbContext.SaveChangesAsync();
            }

            return View();
        }
    }
}
