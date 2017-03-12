using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OurHome.Web.Models.Profile;
using OurHome.Web.Models.Sensors;

namespace OurHome.Web.Controllers
{
    public class ProfileController : Controller
    {

        private IList<BriefSensorViewModel> Sensors = new BriefSensorViewModel[]
        {
            new BriefSensorViewModel()
            {
                Id = 0,
                Type = new SensorType()
                {
                    SensorTypeName = "Горячая вода",
                    Unit = "л"
                },
                LastUpdate = DateTime.Now,
                Status = new SensorStatus()
                {
                    BatteryLevel = 90,
                    Status = StatusLevel.GOOD
                },
                ResourcesPerMonth = 400,
                MoneyPerMonth = 200,
                Debt = 0
            },
            new BriefSensorViewModel()
            {
                Id = 1,
                Type = new SensorType()
                {
                    SensorTypeName = "Холодная вода",
                    Unit = "л"
                },
                LastUpdate = DateTime.Now,
                Status = new SensorStatus()
                {
                    BatteryLevel = 60,
                    Status = StatusLevel.GOOD
                },
                ResourcesPerMonth = 600,
                MoneyPerMonth = 180,
                Debt = 0
            },
            new BriefSensorViewModel()
            {
                Id = 2,
                Type = new SensorType()
                {
                    SensorTypeName = "Газ",
                    Unit = "м3"
                },
                LastUpdate = DateTime.Now,
                Status = new SensorStatus()
                {
                    BatteryLevel = 40,
                    Status = StatusLevel.GOOD
                },
                ResourcesPerMonth = 50,
                MoneyPerMonth = 250,
                Debt = 0
            },
            new BriefSensorViewModel()
            {
                Id = 3,
                Type = new SensorType()
                {
                    SensorTypeName = "Электричество",
                    Unit = "квт/ч"
                },
                LastUpdate = DateTime.Now,
                Status = new SensorStatus()
                {
                    BatteryLevel = 25,
                    Status = StatusLevel.WARNING,
                    Messages = new SensorMessage[]
                    {
                        new SensorMessage()
                        {
                            Status = StatusLevel.ERROR,
                            Message = "Внимание! Замените батарею!"
                        }
                    }
                },
                ResourcesPerMonth = 150,
                MoneyPerMonth = 600,
                Debt = 400
            }
    };


        // GET: Profile
        public ActionResult Index()
        {
            var model = new SummaryViewModel()
            {
                Fio = "Иванов Иван Иванович",
                Sensors = Sensors
            };

            return View(model);
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            return View(new DetailsViewModel()
            {
                Type = Sensors[id].Type
            });
        }
    }
}