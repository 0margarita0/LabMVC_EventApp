using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab04.Models;

namespace Lab04.Controllers
{
    public class EventController : Controller
    {
        private static List<EventModel> eventModel = new List<EventModel>()
        {
            new EventModel()
            {
                ID = 1,
                name = "",
                location = ""
            },
            new EventModel()
            {
                ID = 2,
                name = "",
                location = ""
            },
            new EventModel()
            {
                ID = 3,
                name = "",
                location = ""
            }
        };
        // GET: Event
        public ActionResult EventView()
        {
            Events events = new Events();
            events.eventModel = eventModel;

            return View(events);
        }

        public ActionResult AddNewEvent()
        {
            EventModel model = new EventModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult AddNewEvent(EventModel model)
        {
            if (ModelState.IsValid)
            {
                model.ID = eventModel.Count() + 1;
                eventModel.Add(model);

                return RedirectToAction("EventView", "Event");
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult UpdateEvent(int ID)
        {
            EventModel event_model = eventModel.Find(x => x.ID == ID);

            return View(event_model);
        }

        [HttpPost]
        public ActionResult UpdateEvent(EventModel model)
        {
            if (ModelState.IsValid)
            {
                EventModel event_model = eventModel.Find(x => x.ID == model.ID);
                event_model.name = model.name;
                event_model.location = model.location;

                return RedirectToAction("EventView", "Event");
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult DeleteEvent(int ID)
        {
            EventModel model = eventModel.Find(x => x.ID == ID);
            eventModel.Remove(model);

            return RedirectToAction("EventView", "Event");
        }
        public ActionResult Index()
        {

            return View();
        }
    }
}