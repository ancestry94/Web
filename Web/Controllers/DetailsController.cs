using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Data;

namespace Web.Controllers
{
    [Route("Contacts/Details")]
    public class DetailsController : Controller
    {
        private readonly FormsDbContext _context;
        public DetailsController(FormsDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Details(int id)
        {
            var contact = await _context.Contacts
                .Include(c => c.Messages) // Включаем связанные сообщения
                .FirstOrDefaultAsync(c => c.ContactId == id);

            if (contact == null)
            {
                return NotFound(); // Если контакт не найден, возвращаем 404
            }

            return View(contact); // Возвращаем представление с данными контакта
        }
    }
}
