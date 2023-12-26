using Microsoft.AspNetCore.Mvc;
using AnkaraEventsDeneme.Models;



namespace AnkaraEventsDeneme.Controllers
{
    public class UserController : Controller
    {
    

        public IActionResult ToggleFavorite(int eventId)
        {
            bool isFavorited = CheckIfEventIsFavoritedByUser(eventId);

            if (isFavorited)
            {
           
                RemoveEventFromFavorites(eventId);
            }
            else
            {
                AddEventToFavorites(eventId);
            }

            return RedirectToAction("EventList"); 
        }

        public bool CheckIfEventIsFavoritedByUser(int eventId)
        {
            using (var context = new AnkaraEventsDenemeContext())
            {
                return context.FavoriteEvents.Any(e => e.EventId == eventId);
            }
        }

        public void RemoveEventFromFavorites(int eventId)
        {
            using (var context = new AnkaraEventsDenemeContext())
            {
                var favoriteEvent = context.FavoriteEvents.FirstOrDefault(e => e.EventId == eventId);
                if (favoriteEvent != null)
                {
                    context.FavoriteEvents.Remove(favoriteEvent);
                    context.SaveChanges();
                }
            }
        }

        public void AddEventToFavorites(int eventId)
        {
            using (var context = new AnkaraEventsDenemeContext())
            {
                var favoriteEvent = new FavoriteEvent { EventId = eventId};
                context.FavoriteEvents.Add(favoriteEvent);
                context.SaveChanges();
            }
        }
        public IActionResult EventList(string category = null)
        {
            List<Event> eventsList;

            using (var context = new AnkaraEventsDenemeContext())
            {
                if (!string.IsNullOrEmpty(category))
                {
                    eventsList = context.Events.Where(e => e.Category == category).ToList();
                }
                else
                {
                    eventsList = context.Events.ToList();
                }
            }

            return View(eventsList);
        }


        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            return RedirectToAction("Login", "Account");
        }

    }
}
