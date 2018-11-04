using ApiControllers.Models.Interfaces;
using System.Collections.Generic;

namespace ApiControllers.Models
{
    public class MemoryRepository : IRepository
    {
        private readonly Dictionary<int, Reservation> reservations;

        public MemoryRepository()
        {
            reservations = new Dictionary<int, Reservation>();
            new List<Reservation>
            {
                new Reservation{ ClientName = "Alice", Location = "Board Room" },
                new Reservation{ ClientName = "Bob", Location = "Lecture Hall" },
                new Reservation{ ClientName = "Joe", Location = "Meeting Room" }
            }.ForEach(r => AddReservation(r));
        }

        public IEnumerable<Reservation> Reservations => reservations.Values;

        public Reservation this[int id] => reservations.ContainsKey(id) ? reservations[id] : null;

        public Reservation AddReservation(Reservation reservation)
        {
            if (reservation.ReservationId == 0)
            {
                var key = reservations.Count;
                while (reservations.ContainsKey(key)) { key++; };
                reservation.ReservationId = key;
            }

            reservations[reservation.ReservationId] = reservation;
            return reservation;
        }

        public Reservation UpdateReservation(Reservation reservation) => AddReservation(reservation);

        public void DeleteReservation(int id) => reservations.Remove(id);
    }
}
