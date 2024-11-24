using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SHNgms.Models;
using SHNgms.Data;

namespace SHNgms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly SHNgmsContext _context;

        public NotificationsController(SHNgmsContext context)
        {
            _context = context;
        }

        // GET: api/notifications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Notification>>> GetNotifications()
        {
            return await _context.Notifications.ToListAsync();
        }

        // GET: api/notifications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Notification>> GetNotification(int id)
        {
            var notification = await _context.Notifications.FindAsync(id);

            if (notification == null)
            {
                return NotFound();
            }

            return notification;
        }

        // POST: api/notifications
        [HttpPost]
        public async Task<ActionResult<Notification>> PostNotification(Notification notification)
        {
            _context.Notifications.Add(notification);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetNotification), new { id = notification.Id }, notification);
        }

        // PUT: api/notifications/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotification(int id, Notification notification)
        {
            if (id != notification.Id)
            {
                return BadRequest();
            }

            _context.Entry(notification).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotificationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/notifications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotification(int id)
        {
            var notification = await _context.Notifications.FindAsync(id);
            if (notification == null)
            {
                return NotFound();
            }

            _context.Notifications.Remove(notification);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // New method to get urgent or overdue notifications for the Dashboard
        [HttpGet("urgent")]
        public async Task<ActionResult<IEnumerable<Notification>>> GetUrgentNotifications()
        {
            // Assuming you have a field 'IsUrgent' or 'DueDate' to identify urgent notifications
            var urgentNotifications = await _context.Notifications
                .Where(n => n.IsUrgent || n.DueDate <= DateTime.Now)  // Customize as needed
                .ToListAsync();

            return urgentNotifications;
        }

        // New method to get notifications by status (e.g., for pending reviews or approvals)
        [HttpGet("pending")]
        public async Task<ActionResult<IEnumerable<Notification>>> GetPendingNotifications()
        {
            // Assuming 'Status' field indicates the status of notifications, like Pending or Approved
            var pendingNotifications = await _context.Notifications
                .Where(n => n.Status == "Pending")
                .ToListAsync();

            return pendingNotifications;
        }

        private bool NotificationExists(int id)
        {
            return _context.Notifications.Any(e => e.Id == id);
        }
    }
}
