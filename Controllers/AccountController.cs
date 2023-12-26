using Microsoft.AspNetCore.Mvc;
using AnkaraEventsDeneme.Models;



namespace AnkaraEventsDeneme.Controllers
{


    public class AccountController : Controller
    {


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.UserName == "admin" && model.Password == "1234") 
                {
                    return RedirectToAction("EventList", "Admin");
                }
                else
                {
                    return RedirectToAction("EventList", "User");
                }
            }

            return View(model);
        }

        public IActionResult EventList()
        {
            List<Event> eventsList;

            using (var context = new AnkaraEventsDenemeContext())
            {
                eventsList = context.Events.ToList();
            }
            return View(eventsList);
        }

        
    }

 
}
