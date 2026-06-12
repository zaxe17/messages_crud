using messages_crud.Data;
using messages_crud.Models;
using messages_crud.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace messages_crud.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext DbContext;

        public HomeController(ApplicationDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(MessageViewModel viewModel)
        {
            if (string.IsNullOrWhiteSpace(viewModel.Content))
            {
                return View(viewModel);
            }

            var message = new Message
            {
                FullName = viewModel.FullName,
                Email = viewModel.Email,
                Content = viewModel.Content,
                CreatedAt = DateTime.Now,
                IsRead = false
            };

            await DbContext.Messages.AddAsync(message);
            await DbContext.SaveChangesAsync();

            return View("ThankYou", viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Messages()
        {
            var messages = await DbContext.Messages.ToListAsync();
            return View(messages);
        }

        [HttpPost]
        public async Task<IActionResult> MarkAsRead(Guid id)
        {
            var message = await DbContext.Messages.FindAsync(id);

            if (message != null)
            {
                message.IsRead = true;
                await DbContext.SaveChangesAsync();
            }

            return RedirectToAction("Messages");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteMessage(Guid id)
        {
            var message = await DbContext.Messages.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

            if (message is not null)
            {
                DbContext.Messages.Remove(message);
                await DbContext.SaveChangesAsync();
            }

            return RedirectToAction("Messages");
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
