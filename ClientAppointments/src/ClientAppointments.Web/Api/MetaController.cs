﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ClientAppointments.Web.Api
{
    public class MetaController : BaseApiController
    {
        /// <summary>
        /// A sample API Controller. Consider using API Endpoints (see Endpoints folder) for a more SOLID approach to building APIs
        /// https://github.com/ardalis/ApiEndpoints
        /// </summary>
        [HttpGet("/info")]
        public ActionResult<string> Info()
        {
            var assembly = typeof(Startup).Assembly;

            var creationDate = System.IO.File.GetCreationTime(assembly.Location);
            var version = FileVersionInfo.GetVersionInfo(assembly.Location).ProductVersion;

            return Ok($"Version: {version}, Last Updated: {creationDate}");
        }
    }
}
