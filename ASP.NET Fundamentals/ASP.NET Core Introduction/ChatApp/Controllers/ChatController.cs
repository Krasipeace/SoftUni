namespace ChatApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using ChatApp.Models.Message;

    public class ChatController : Controller
    {
        private static readonly List<KeyValuePair<string, string>> s_messages = new();

        [HttpGet]
        public IActionResult Show()
        {
            if (s_messages.Count < 1)
            {
                return View(new ChatViewModel());
            }

            ChatViewModel chatModel = new()
            {
                Messages = s_messages
                    .Select(m => new MessageViewModel()
                    {
                        Sender = m.Key,
                        MessageText = m.Value
                    }).ToList()
            };

            return View(chatModel);
        }

        [HttpPost]
        public IActionResult Send(ChatViewModel chat)
        {
            MessageViewModel newMessage = chat.CurrentMessage;

            s_messages.Add(new KeyValuePair<string, string>(newMessage.Sender, newMessage.MessageText));

            return RedirectToAction("Show");
        }
    }
}
