using DineTogather.Application.Common.Interfaces;

namespace DineTogather.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
