using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using HubCoreMini.Controllers;
using HubCoreMini.Providers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HubCoreMini
{
    [Route("api/[controller]")]
    public class InfoController : Controller
    {
        private readonly IInfoQueryProvider _infoQueryProvider;
        private const char SLASH_DELIMITER = '/';

        public InfoController(IInfoQueryProvider infoQueryProvider)
        {
            _infoQueryProvider = infoQueryProvider;
        }
        // GET: api/<controller>
        [HttpGet("getInfo/{sourceApi}/{infoProviderName}/{*infoParams}")]
        public IActionResult GetInfo(string sourceApi, string infoProviderName, string infoParams)
        {
            var infoParamsAsArray= infoParams.Split(SLASH_DELIMITER, StringSplitOptions.RemoveEmptyEntries);
            var infoResponse = _infoQueryProvider.GetQueryResult(sourceApi, infoProviderName, infoParamsAsArray);
            return Json(infoResponse);

        }
    }
}
