using EmailSender.Common;
using EmailSender.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmailSender.EmailApp.Controllers;

[ApiController]
[Route("[controller]")]
public class EmailSenderController : ControllerBase
{
  private static readonly string[] Summaries = new[]
  {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

  private readonly ILogger<EmailSenderController> _logger;
  private readonly IEmailSender _emailSender;

  public EmailSenderController(ILogger<EmailSenderController> logger, IEmailSender emailSender)
  {
    _logger = logger;
    _emailSender = emailSender;
  }

  [HttpGet]
  public ActionResult Get()
  {
    Message message = new Message(new string[] { "romdhon.1998@gmail.com" }, "Test email", "This is the content");
    _emailSender.SendEmail(message);
    return Ok();
  }
}
