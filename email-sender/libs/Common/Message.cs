using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Http.Internal;
using MimeKit;

namespace EmailSender.Common
{
    public class Message
    {
        public List<MailboxAddress>? To { get; set; }
        public string? Subject { get; set; }
        public string? Content { get; set; }
        public IFormFileCollection? Attachments { get; set; }

        public Message(IEnumerable<string> to, string subject, string content)
        {
            To = new List<MailboxAddress>();
            To.AddRange(to.Select(x => new MailboxAddress("email", x)));
            Subject = subject;
            Content = content;  
            // Attachments = new FormFileCollection();
        }
        public Message(IEnumerable<string> to, string subject, string content, IFormFileCollection attachments)
        {
            To = new List<MailboxAddress>();
            To.AddRange(to.Select(x => new MailboxAddress("email", x)));
            Subject = subject;
            Content = content;  
            Attachments = attachments;
        }
    }
}