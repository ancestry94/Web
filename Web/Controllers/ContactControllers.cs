using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Data;
using Web.Models;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Web.Controllers
{
    [Route("Contacts")]
    [Route("Contacts/Create")]
    public class ContactsController : Controller
    {
        private readonly FormsDbContext _context;
        public ContactsController(FormsDbContext context)
        {
            _context = context;
        }

        // GET: Contacts/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            int captchaValue = new Random().Next(1000, 10000);
            ViewBag.CaptchaValue = captchaValue; // Сохраняем значение капчи в ViewBag
            var topics = await _context.MessageTopics.ToListAsync();
            ViewBag.Topics = topics;
            return View();
        }

        // POST: Contacts/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Contact contact, int topicId, string Messages, int userCaptchaValue, int captchaValue)
        {
         

            if (ModelState.IsValid && userCaptchaValue == captchaValue)
            {
              
 // Проверяем существование контакта по email или номеру телефона
                var existingContact = await _context.Contacts
            .FirstOrDefaultAsync(c => c.ContactEmail == contact.ContactEmail && c.PhoneNumber == contact.PhoneNumber);

                if (existingContact != null)
                {
                    // Если контакт существует, добавляем только сообщение
                    var message = new Message
                    {
                        MessageText = Messages,
                        TopicId = topicId,
                        ContactId = existingContact.ContactId // Используем существующий контакт
                    };

                    _context.Messages.Add(message);
                    await _context.SaveChangesAsync();

                    TempData["Message"] = "Сообщение было добавлено для существующего контакта.";
                }
                else
                {
                    // Если контакт не существует, добавляем его в БД
                    _context.Contacts.Add(contact);
                    await _context.SaveChangesAsync();

                    // Теперь добавляем сообщение для нового контакта
                    var message = new Message
                    {
                        MessageText = Messages,
                        TopicId = topicId,
                        ContactId = contact.ContactId // Используем ID только что добавленного контакта
                    };

                    _context.Messages.Add(message);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction("Index", "Home"); // Перенаправление на список контактов или другую страницу
            }
            ModelState.AddModelError(string.Empty, "Неверное значение капчи.");

            // Генерация нового значения капчи при ошибке
            captchaValue = new Random().Next(1000, 10000);
            ViewBag.CaptchaValue = captchaValue;

            
            Debug.WriteLine($"Name {contact.ContactName} Message:{Messages}"); // Логирование ошибок в консоль



            // Если модель не валидна, возвращаемся к форме создания с темами сообщений
            ViewBag.Topics = await _context.MessageTopics.ToListAsync();
            return View(contact);
        }
    }
}
