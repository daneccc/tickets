using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tickets.API.Models;
using Tickets.API.Repositories;

namespace Tickets.API.Controllers {
    [Route("api/tickets")]
    [ApiController]
    public class TicketsController : ControllerBase {
        private readonly DataContext _context;
        ITicketRepository _ticketRepository;

        public TicketsController(DataContext context, ITicketRepository ticketRepository) {
            _context = context;
            _ticketRepository = ticketRepository;
        }

        // GET: api/tickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTickets() {
            var tickets = _ticketRepository.GetTickets();
            return tickets;
        }

        // GET: api/tickets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetTicket(long id) {
            var ticket = _ticketRepository.Get(id);

            if (ticket == null) {
                return NotFound();
            }

            return ticket;
        }

        // PUT: api/Tickets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicket(long id, Ticket ticket) {
            try {
                _ticketRepository.Update(id, ticket);
            }
            catch (DbUpdateConcurrencyException) {
                if (!TicketExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Tickets
        [HttpPost]
        public async Task<ActionResult<Ticket>> PostTicket(Ticket ticket) {
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTicket", new { id = ticket.Id }, ticket);
        }

        // DELETE: api/Tickets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Ticket>> DeleteTicket(long id) {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null)
                return NotFound();

            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();

            return ticket;
        }

        private bool TicketExists(long id) {
            return _context.Tickets.Any(e => e.Id == id);
        }
    }
}
