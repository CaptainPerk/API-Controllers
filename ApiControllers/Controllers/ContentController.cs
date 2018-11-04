﻿using ApiControllers.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiControllers.Controllers
{
    [Route("api/[controller]")]
    public class ContentController : Controller
    {
        [HttpGet("string")]
        public string GetString() => "This is a string response";

        [HttpGet("object")]
        public Reservation GetObject() => new Reservation {ReservationId = 100, ClientName = "Joe", Location = "Board Room"};
    }
}
