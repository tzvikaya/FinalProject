using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartCalendar.API.Controllers;
using SmartCalendar.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace SmartCalendar.API.Controllers.Tests
{
    [TestClass()]
    public class EventsControllerTests
    {
        [TestMethod()]
        public void GetEventsTest()
        {
            EventsController ec = new EventsController();
            var res = ec.GetEvents(1);

            OkNegotiatedContentResult<List<Events>> contentResult = res as OkNegotiatedContentResult<List<Events>>;
            Assert.IsNotNull(contentResult);

            Assert.AreEqual(contentResult.Content.Count, 2);
            Assert.AreEqual(contentResult.Content[0].event_name, "הכוכב הירושלמי");
        }

        [TestMethod()]
        public void PutEventsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PostEventsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteEventsTest()
        {
            Assert.Fail();
        }
    }
}