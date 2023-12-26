using AnkaraEventsDeneme.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnkaraEventsDeneme.Controllers
{
    public class AdminController : Controller
    {

        public IActionResult CreateEvent()
        {

            return View(new Event()); 
        }
        [HttpPost]
        public IActionResult CreateEvent(Event newEvent, IFormFile Image)
        {
            switch (newEvent.Category)
            {
                case "Cinema":
                    using (var cinemaContext = new AnkaraEventsDenemeContext())
                    {
                        var cinemaEvent = new Event
                        {
                            Name = newEvent.Name,
                            Date = newEvent.Date,
                            Time = newEvent.Time,
                            Venue = newEvent.Venue,
                            Details = newEvent.Details,
                            Category = newEvent.Category,
                            Tickets = newEvent.Tickets
                    };
                        cinemaContext.CinemaEvents.Add(cinemaEvent); 
                        cinemaContext.SaveChanges();
                    }
                    return RedirectToAction("EventList", "Admin");

                case "Theatre":
                    using (var theatreContext = new AnkaraEventsDenemeContext())
                    {
                        var theatreEvent = new Event
                        {
                            Name = newEvent.Name,
                            Date = newEvent.Date,
                            Time = newEvent.Time,
                            Venue = newEvent.Venue,
                            Details = newEvent.Details,
                            Category = newEvent.Category,
                            Tickets = newEvent.Tickets
                        };
                        theatreContext.TheatreEvents.Add(theatreEvent);
                        theatreContext.SaveChanges();
                    }
                    return RedirectToAction("EventList", "Admin");

                case "Concert":
                    using (var concertContext = new AnkaraEventsDenemeContext())
                    {
                        var concertEvent = new Event
                        {
                            Name = newEvent.Name,
                            Date = newEvent.Date,
                            Time = newEvent.Time,
                            Venue = newEvent.Venue,
                            Details = newEvent.Details,
                            Category = newEvent.Category,
                            Tickets = newEvent.Tickets
                        };
                        concertContext.ConcertEvents.Add(concertEvent);
                        concertContext.SaveChanges();
                    }
                    return RedirectToAction("EventList", "Admin");

                default:
                    return RedirectToAction("EventList", "Admin");
            }
        }


        public IActionResult EditEvent(int? id)
        {
            using (var context = new AnkaraEventsDenemeContext())
            {

                var eventItem = context.Events.Find(id);

                if (eventItem == null)
                {
                    return NotFound();
                }

                return View("CreateEvent", eventItem);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditEvent(int id, Event eventItem)
        {
            using (var context = new AnkaraEventsDenemeContext())
            {

                if (id != eventItem.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        context.Update(eventItem);
                        context.SaveChanges();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!EventExists(eventItem.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(EventList));
                }
                return View("CreateEvent", eventItem);
            }
        }

        public IActionResult DeleteEvent(int? id)
        {
            using (var context = new AnkaraEventsDenemeContext())
            {

                var eventItem = context.Events.Find(id);

                if (eventItem == null)
                {
                    return NotFound();
                }

                context.Events.Remove(eventItem);
                context.SaveChanges();

                return RedirectToAction(nameof(EventList));
            }
        }

        private bool EventExists(int id)
        {
            using (var context = new AnkaraEventsDenemeContext())
            {

                return context.Events.Any(e => e.Id == id);
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




    }
}
