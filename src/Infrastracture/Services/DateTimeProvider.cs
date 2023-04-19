using Application.Common.Interfaces.Services;


namespace Infrastracture.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.Now;
    }
}
