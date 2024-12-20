using System.Diagnostics;
using Asp.net_core_Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Newtonsoft.Json.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Asp.net_core_Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentDbContext studentDb;

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Checkbox()
        {
            var model = new ViewModel()
            {
                CheckBoxes = new List<CheckBoxOption> 
                { 
                  new CheckBoxOption()
                  {
                      isChecked = true,
                      Text = "Cricket",
                      Value = "Cricket"
                  },
                  new CheckBoxOption()
                  {
                      isChecked = false,
                      Text = "Football",
                      Value = "Football"
                  },
                  new CheckBoxOption()
                  {
                      isChecked = true,
                      Text = "Hockey",
                      Value = "Hockey"
                  }
                }
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Checkbox(ViewModel model)
        {
             return View();
        }

        public HomeController(StudentDbContext studentDb)
        {
              this.studentDb = studentDb;
        }

        public async Task<IActionResult> Index()
        {
            HttpContext.Session.SetString("key", "Asp.net core mvc");
            var stdData = await studentDb.Students.ToListAsync();
            return View(stdData);
        }

        public IActionResult Create()
        {

            List<SelectListItem> Gender = new()
             {
                 new SelectListItem{Value = "Male" , Text="Male"},
                 new SelectListItem{Value = "Female" , Text="Female"}
             };

            ViewBag.Gender = Gender;

            if (HttpContext.Session.GetString("key")!=null)
            {
                ViewBag.key = HttpContext.Session.GetString("key").ToString();
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student std)
        {
            if (ModelState.IsValid)
            {
                await studentDb.Students.AddAsync(std);
                await studentDb.SaveChangesAsync();
                TempData["insert_success"] = "Inserted...";
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var studentDetail = await studentDb.Students.Where(item => item.Id == id).FirstAsync();

            return View(studentDetail);
        }

        public async Task<IActionResult> Edit(int id)
        {
            List<SelectListItem> Gender = new()
             {
                 new SelectListItem{Value = "Male" , Text="Male"},
                 new SelectListItem{Value = "Female" , Text="Female"}
             };

            ViewBag.Gender = Gender;

            var updateData = await studentDb.Students.FindAsync(id);

            return View(updateData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Student std)
        {

            if (ModelState.IsValid)
            {
                studentDb.Students.Update(std);
                TempData["edit_success"] = "Updated...";
                await studentDb.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {

            var stdData = await studentDb.Students.FindAsync(id);

            if(stdData!= null)
            {
                studentDb.Students.Remove(stdData); 
            }
            await studentDb.SaveChangesAsync();
            TempData["delete_success"] = "Deleted...";
            return RedirectToAction("Index", "Home");
        }

        public IActionResult StudentView()
        {
            StudentModel model = new StudentModel();
            model.StudentList = new List<SelectListItem>();

            var data = studentDb.Students.ToList();

            model.StudentList.Add(new SelectListItem
            {
                Text = "Select Name",
                Value = ""
            });

            foreach (var item in data)
            {
                model.StudentList.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult StudentView(StudentModel std)
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
