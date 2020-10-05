using System.Collections.Generic;
using Tickets.API.Models;

namespace Tickets.API.Repositories {
    public interface ITicketRepository {
        List<Ticket> GetTickets();
        Ticket Get(long id);
        long Update(long id, Ticket ticket);
    }
}