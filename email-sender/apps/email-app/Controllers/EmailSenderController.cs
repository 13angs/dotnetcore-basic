using EmailSender.Common;
using EmailSender.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmailSender.EmailApp.Controllers;

[ApiController]
[Route("api/emails")]
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

  [HttpPost]
  public async Task<ActionResult> Post([FromForm] IFormFileCollection form)
  {
    // IFormFileCollection files = Request.Form.Files.Any() ? Request.Form.Files : new FormFileCollection();
    IFormFileCollection files = form.Any() ? form : new FormFileCollection();
    Message message = new Message(new string[] { "romdhon.1998@gmail.com" }, "Test email with attachment", "This is the content with attachment", files);
    await _emailSender.SendEmailAsync(message);
    return Ok();
  }

  [HttpGet]
  public async Task<ActionResult> Get()
  {
    Message message = new Message(new string[] { "romdhon.1998@gmail.com" }, "Test email", "This is the content");
    await _emailSender.SendEmailAsync(message);
    return Ok();
  }
}
