using System.Diagnostics;
using Asp.net_core_Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public HomeController(StudentDbContext studentDb)
        {
            this.studentDb = studentDb;
        }

        public async Task<IActionResult> Index()
        {
            var stdData = await studentDb.Students.ToListAsync();
            return View(stdData);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student std)
        {
            if (ModelState.IsValid)
            {
                await studentDb.Students.AddAsync(std);
                await studentDb.SaveChangesAsync();
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
            var updateData = await studentDb.Students.Where(item => item.Id == id).FirstAsync();

            return View(updateData);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,Student std)
        {
           if(ModelState.IsValid)
            {
                await studentDb.Students.Where(item=>item.Id == std.Id).ExecuteUpdateAsync(item=>item.SetProperty(item=>item.Name,std.Name).SetProperty(item=>item.Gender,std.Gender).SetProperty(item=>item.Age,std.Age).SetProperty(item=>item.Branch,std.Branch));
                await studentDb.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await studentDb.Students.Where(item => item.Id == id).ExecuteDeleteAsync();
            await studentDb.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
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
