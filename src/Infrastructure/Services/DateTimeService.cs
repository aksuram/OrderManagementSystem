using OrderManagementSystem.Application.Common.Interfaces;

namespace OrderManagementSystem.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.UtcNow;
    }
}
