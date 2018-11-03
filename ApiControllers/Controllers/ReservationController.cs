using ApiControllers.Models;
using ApiControllers.Models.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiControllers.Controllers
{
    [Route("api/[controller]")]
    public class ReservationController : Controller
    {
        private readonly IRepository _repository;

        public ReservationController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Reservation> Get() => _repository.Reservations;

        [HttpGet("{id}")]
        public Reservation Get(int id) => _repository[id];

        [HttpPost]
        public Reservation Post([FromBody] Reservation reservation) => _repository.AddReservation(new Reservation
        {
            ClientName = reservation.ClientName,
            Location = reservation.Location
        });

        [HttpPut]
        public Reservation Put([FromBody] Reservation reservation) => _repository.UpdateReservation(reservation);

        [HttpPatch]
        public StatusCodeResult Patch(int id, [FromBody] JsonPatchDocument<Reservation> reservationPatch)
        {
            var reservation = Get(id);
            if (reservation != null)
            {
                reservationPatch.ApplyTo(reservation);
                return Ok();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public void Delete(int id) => _repository.DeleteReservation(id);
    }
}
