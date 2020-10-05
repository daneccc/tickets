using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Tickets.API.Models;
using Dapper;
using System.Linq;

namespace Tickets.API.Repositories {
    public class TicketRepository : ITicketRepository {
        IConfiguration _configuration;
        DataContext _context;
        public TicketRepository(IConfiguration configuration, DataContext context) {
            _configuration = configuration;
            _context = context;
        }
        public string GetConnection() {
            var connection = _configuration.GetSection("ConnectionString").
                GetSection("Default").Value;
            return connection;
        }
        public Ticket Get(long id) {
            var connectionString = this.GetConnection();
            Ticket ticket = new Ticket();

            using (var c = new SqlConnection(connectionString)) {
                try {
                    c.Open();
                    var query = "SELECT * FROM Tickets WHERE Id = @Id";
                    ticket = c.Query<Ticket>(query, new { Id = id }).FirstOrDefault();
                }
                catch (Exception ex) {
                    throw ex;
                }
                finally {
                    c.Close();
                }
                return ticket;
            }
        }

        public List<Ticket> GetTickets() {
            var connectionString = this.GetConnection();
            List<Ticket> tickets = new List<Ticket>();

            using (var c = new SqlConnection(connectionString))
            {
                try {
                    c.Open();
                    var query = "SELECT * FROM Tickets";
                    tickets = c.Query<Ticket>(query).ToList();
                }
                catch (Exception ex) {
                    throw ex;
                }
                finally {
                    c.Close();
                }
                return tickets;
            }
        }

        public long Update(long id, Ticket ticket) {
            var ticketSaved = _context.Tickets.Find(id);

            if (ticket.Description != null) {
                ticketSaved.Description = ticket.Description;
            }
            if (ticket.AuthorName != null) {
                ticketSaved.AuthorName = ticket.AuthorName;
            }
            if (ticket.Date != null) {
                ticketSaved.Date = ticket.Date;
            }

            _context.Entry(ticketSaved).State = EntityState.Modified;
            _context.SaveChangesAsync();

            return ticketSaved.Id;
        }
    }
}