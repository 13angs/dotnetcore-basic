namespace EmailSender.Common.Interfaces
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
    }
}