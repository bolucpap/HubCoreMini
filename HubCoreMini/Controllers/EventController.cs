using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using HubCoreMini.Providers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace HubCoreMini.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : Controller
    {
        private const char SLASH_DELIMITER = '/';
        private IEventHandlerProvider _eventHandlerProvider;
        public EventController(IEventHandlerProvider eventHandlerProvider)
        {
            _eventHandlerProvider = eventHandlerProvider;
        }
        [HttpPost("sendEvent/{sourceApi}/{eventName}/{*parameters}")]
        public IActionResult SendEvent(string sourceApi, string eventName, [FromBody] JToken eventPayload, string parameters = null)
        {
            var parametersAsArray = (parameters == null) ? (new string[] { }) : parameters.Split(SLASH_DELIMITER, StringSplitOptions.RemoveEmptyEntries);
            var handleEventResult = _eventHandlerProvider.HandleEvent(sourceApi, eventName, eventPayload, parametersAsArray).ToString();
            return Json(handleEventResult);
        }
    }
}